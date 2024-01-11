using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruleta : MonoBehaviour
{
    Animator animator;
    public Transform ship;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if(ship.GetComponent<Ship>().lasers==0 && ship.GetComponent<Ship>().rokets==0 && ship.GetComponent<Ship>().shields==0) animator.Play("empty");
         if(ship.GetComponent<Ship>().lasers>=1) animator.Play("laser");
         if(ship.GetComponent<Ship>().rokets>=3) animator.Play("rockets3");
         if(ship.GetComponent<Ship>().rokets==2) animator.Play("rockets2");
         if(ship.GetComponent<Ship>().rokets==1) animator.Play("rockets1");
         if(ship.GetComponent<Ship>().shields>=1) animator.Play("shockwave");
    }
}
