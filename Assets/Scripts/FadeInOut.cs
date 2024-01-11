using UnityEngine;
using System;

public class FadeInOut : MonoBehaviour
{
    private Color tmp;
    private void Start()
    {
        tmp = this.GetComponent<SpriteRenderer>().color;
    }
    private void Update()
    {
        tmp.a=Math.Abs(Mathf.Sin(Time.time*4.5f));
        this.GetComponent<SpriteRenderer>().color=tmp;
        //Debug.Log(200*Mathf.PingPong(Time.deltaTime, 1f)-0.2);
    }
}