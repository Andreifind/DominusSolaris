using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biglasersound : MonoBehaviour
{
	public static AudioClip biglaser;
	static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        biglaser = Resources.Load<AudioClip> ("biglaser");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public static void PlaySound (string clip)
	{
		switch (clip)
			{
				case "biglaser":
				audioSrc.PlayOneShot(biglaser);
				break;
			}
	}
}
