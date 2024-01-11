using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Pixellate : MonoBehaviour {

	public Material effectMat;

	void OnRenderImage(RenderTexture src, RenderTexture dst){
		Graphics.Blit (src, dst, effectMat);
	}
}
