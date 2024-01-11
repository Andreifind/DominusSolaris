using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energybar : MonoBehaviour
{
	private Transform player;
	public Slider slider;
    public Image fill;
    public Image border;
    // Start is called before the first frame update
    void Start()
    {
		player=GameObject.Find("ship").transform;
        slider.maxValue=100;
		slider.value=100;
    }
    IEnumerator FadeImage()
    {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                if(slider.value<100) break; 
                // set color with i as alpha
                fill.color = new Color(1, 1, 1, i);
                border.color = new Color(1, 1, 1, i);
                yield return null;
            }
    }
    // Update is called once per frame
    void Update()
    {
        if(slider.value>=100) 
            StartCoroutine(FadeImage());
        else
        {
            fill.color = new Color(1, 1, 1, 1);
            border.color = new Color(1, 1, 1, 1);
        }
        slider.value=player.GetComponent<Ship>().energy;
    }
}
