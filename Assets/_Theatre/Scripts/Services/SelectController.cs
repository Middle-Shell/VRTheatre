using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class SelectController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Slider slider;
    [SerializeField] private float timerDuration = 30f;

    private readonly Vector3 _rayStartPosition = new(Screen.width / 2, Screen.height / 2, 0);
    private GameObject _currentHit = null;
    private Ray _ray;

    private float _timerCircle;
    private float _timerRay;


    public delegate void SelectHandler(GameObject gameObject);
    public static event SelectHandler SelectHandlerEvent;
    private void OnSelectHandler(GameObject gameObject)
    {
        SelectHandlerEvent?.Invoke(gameObject);
    }

    
    private void Start()
    {
        _camera = Camera.main;
        _timerCircle = timerDuration;
    }

    void Update()
    {
        _ray = _camera.ScreenPointToRay(_rayStartPosition);
        if (XRSettings.enabled)
        {
            // Получить данные о глазах
            List<XRNodeState> xrNodeStates = new List<XRNodeState>();
            InputTracking.GetNodeStates(xrNodeStates);

            foreach (var xrNodeState in xrNodeStates)
            {
                if (xrNodeState.nodeType == XRNode.RightEye)
                {
                    // Получить позицию и направление правого глаза
                    Vector3 rightEyePosition;
                    xrNodeState.TryGetPosition(out rightEyePosition);

                    Quaternion rightEyeRotation;
                    xrNodeState.TryGetRotation(out rightEyeRotation);

                    // Отправить луч из центра экрана правого глаза
                    _ray = new Ray(rightEyePosition, rightEyeRotation * Vector3.forward);
                }
            }
        }
        
        Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.red);

        Physics.Raycast(_ray, out var firstHit, Mathf.Infinity, layerMask);

        if (firstHit.transform == null)
        {
            _timerRay = 0f;
            ResetTimer();
            return;
        }

        if (firstHit.transform.gameObject == _currentHit)
        {
            _timerRay += Time.deltaTime;
            TimerUpdate();
            if (_timerRay >= timerDuration)
            {
                _timerRay = 0f;
                OnSelectHandler(firstHit.transform.gameObject);
            }

            return;
        }

        _timerRay = 0f;
        _currentHit = firstHit.transform.gameObject;
        ResetTimer();

    }

    void TimerUpdate()
    {
        _timerCircle -= Time.deltaTime;
        float normalizedTime = 1 - Mathf.Clamp01(_timerCircle / timerDuration);
        slider.value = normalizedTime;
        if (_timerCircle <= 0)
        {
            _timerCircle = timerDuration;
        }
    }

    void ResetTimer()
    {
        _timerCircle = timerDuration;
        slider.value = 0;
    }
}
