using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class TextFading : MonoBehaviour
{
    public Text i;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
    }

    // Update is called once per frame
    void Update()
    {
        if (i.color.a<=0.01f)
        {
            StartCoroutine(FadeTextToFullAlpha(5f, GetComponent<Text>()));
        }
        if (i.color.a>=0.99f)
        {
            StartCoroutine(FadeTextToZeroAlpha(5f, GetComponent<Text>()));
        }
    }
     public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime ));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime ));
            yield return null;
        }
    }
}
