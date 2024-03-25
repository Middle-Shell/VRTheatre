using System.Collections;
using System.Collections.Generic;
using AmazingAssets.DynamicRadialMasks;
using UnityEngine;
using AmazingAssets.DynamicRadialMasks;

public class AudioSyncScale : AudioSyncer
{

	[SerializeField] private GameObject DrmGameObject;

	public float radius;
	private IEnumerator MoveToScale(float _target)
	{
		float _curr = DrmGameObject.GetComponent<DRMGameObject>().radius;
		print(_curr);
		float _initial = _curr;
		float _timer = 0;

		while (_curr != _target)
		{
			_curr = Mathf.Lerp(_initial, _target, _timer / timeToBeat);
			_timer += Time.deltaTime;

			//DrmGameObject.GetComponent<DRMGameObject>().ChangeRadius(_curr);
			radius = _curr;

			yield return null;
		}

		m_isBeat = false;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		print(DrmGameObject.name);

		if (m_isBeat) return;

		//DrmGameObject.ChangeRadius(Mathf.Lerp(DrmGameObject.radius, restScale, restSmoothTime * Time.deltaTime));
		radius = Mathf.Lerp(DrmGameObject.GetComponent<DRMGameObject>().radius, restScale, restSmoothTime * Time.deltaTime);
	}

	public override void OnBeat()
	{
		base.OnBeat();

		StopCoroutine("MoveToScale");
		StartCoroutine("MoveToScale", beatScale);
	}

	public float beatScale;
	public float restScale;
}
