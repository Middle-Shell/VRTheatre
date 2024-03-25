using System.Collections;
using System.Collections.Generic;
using AmazingAssets.DynamicRadialMasks;
using UnityEngine;
using AmazingAssets.DynamicRadialMasks;

public class AudioSyncScale : AudioSyncer
{

	[SerializeField] private DRMGameObject DrmGameObject;

	[SerializeField] private bool play;
	private bool isDown = false;

	public float radius;
	private IEnumerator MoveToScale(float _target)
	{
		float _curr = DrmGameObject.radius;
		float _initial = _curr;
		float _timer = 0;

		while (Mathf.Abs(_curr - _target) > 0.2f)
		{
			_curr = Mathf.Lerp(_initial, _target, _timer / timeToBeat);
			_timer += Time.deltaTime;

			radius = _curr;
			DrmGameObject.radius = radius;

			yield return null;
		}

		m_isBeat = false;
	}
	
	private IEnumerator DownToScale()
	{
		while (DrmGameObject.radius > .5f)
		{
			print("Down");
			radius = Mathf.Lerp(DrmGameObject.radius, restScale, restSmoothTime * Time.deltaTime);
			DrmGameObject.radius = radius;
			yield return null;
		}

		isDown = false;
		this.enabled = false;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();

		if (m_isBeat) return;
		if (isDown) return;
		
		if (!play && !isDown)
		{
			StopCoroutine("MoveToScale");
			StopCoroutine("DownToScale");
			StartCoroutine("DownToScale", beatScale);
			isDown = true;
			return;
		}
		
		radius = Mathf.Lerp(DrmGameObject.radius, restScale, restSmoothTime * Time.deltaTime);
		DrmGameObject.radius = radius;
	}

	public override void OnBeat()
	{
		base.OnBeat();

		if (play)
		{
			StopCoroutine("MoveToScale");
			StartCoroutine("MoveToScale", beatScale);
		}
	}

	public float beatScale;
	public float restScale;
}
