using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class expbar : MonoBehaviour
{
	public Transform player;
	public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
		//player=GameObject.Find("ship").transform;
		slider.value=100;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue=player.GetComponent<Ship>().targetexp;
        slider.value=player.GetComponent<Ship>().exp;
    }
}
