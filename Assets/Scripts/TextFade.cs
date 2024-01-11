using UnityEngine;
using System;
using UnityEngine.UI;
public class TextFade : MonoBehaviour
{
    public Text i;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Ship>().points>0 || player.GetComponent<Ship>().planet==8) i.color = new Color(i.color.r, i.color.g, i.color.b, Math.Abs(Mathf.Sin(Time.time*3)));
        else if(player.GetComponent<Ship>().planet!=8) i.color = new Color(i.color.r, i.color.g, i.color.b,0);
    }
}
