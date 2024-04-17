using System.Collections;
using System.Collections.Generic;
using AmazingAssets.DynamicRadialMasks;
using UnityEngine;
using AmazingAssets.DynamicRadialMasks;

public class AudioSyncScale : AudioSyncer
{

	[SerializeField] private DRMGameObject drmGameObject;
	[SerializeField] private MeshRenderer actorRenderer;

	[SerializeField] public bool play;
	private bool _isDown = false;

	public float radius;
	private IEnumerator MoveToScale(float target)
	{
		float curr = drmGameObject.radius;
		float initial = curr;
		float timer = 0;

		while (Mathf.Abs(curr - target) > 0.1f)
		{
			curr = Mathf.Lerp(initial, target, timer / timeToBeat);
			timer += Time.deltaTime;

			radius = curr;
			drmGameObject.radius = radius;

			yield return null;
		}

		drmGameObject.radius = beatScale;
		m_isBeat = false;
	}
	
	private IEnumerator DownToScale()
	{
		while (Mathf.Abs(drmGameObject.radius - restScale) > 0.2f)
		{
			radius = Mathf.Lerp(drmGameObject.radius, restScale, restSmoothTime * Time.deltaTime);
			drmGameObject.radius = radius;
			yield return null;
		}

		drmGameObject.radius = restScale;
		_isDown = false;
		this.enabled = false;
		actorRenderer.enabled = false;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();

		if (m_isBeat) return;
		if (_isDown) return;
		
		if (!play && !_isDown)
		{
			StopCoroutine("MoveToScale");
			StopCoroutine("DownToScale");
			StartCoroutine("DownToScale", beatScale);
			_isDown = true;
			return;
		}
		
		radius = Mathf.Lerp(drmGameObject.radius, restScale, restSmoothTime * Time.deltaTime);
		drmGameObject.radius = radius;
	}

	public override void OnBeat()
	{
		base.OnBeat();

		if (play)
		{
			StopCoroutine("DownToScale");
			_isDown = false;
			StopCoroutine("MoveToScale");
			StartCoroutine("MoveToScale", beatScale);
		}
	}

	public float beatScale;
	public float restScale;
}
