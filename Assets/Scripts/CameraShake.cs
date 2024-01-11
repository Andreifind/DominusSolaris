using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraShake : MonoBehaviour
{
	UnityEngine.Rendering.VolumeProfile profile;
	UnityEngine.Rendering.Universal.ChromaticAberration myChromaticAberration;
	float inten;
	void Start()
	{
		profile = GameObject.Find("Global Volume").GetComponent<UnityEngine.Rendering.Volume>().profile;
		profile.TryGet(out myChromaticAberration);
	}
	public IEnumerator Shake (float duration, float magnitude)
	{
			Vector2 originalpos = transform.localPosition;
			float elapsed = 0.0f;
			//inten=myChromaticAberration.intensity;
			myChromaticAberration.intensity.Override(0.7f);
			while (elapsed<duration)
			{
				float x = Random.Range (-1f,1f)*magnitude;
				float y = Random.Range (-1f,1f)*magnitude;
				transform.localPosition=new Vector2 (x,y);
				elapsed+= Time.deltaTime;
				yield return null;
				myChromaticAberration.intensity.value-=0.001f;
				if(Time.timeScale!=1) break;
			}
			transform.localPosition= originalpos;
			myChromaticAberration.intensity.Override(0.14f);
	}
	
}