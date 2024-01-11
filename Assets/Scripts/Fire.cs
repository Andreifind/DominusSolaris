using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
	public Transform player;
	private Vector2 targetPos;
    Animator animator;
    bool tr1=false;
    bool tr2=false;
    // Start is called before the first frame update
    void Start()
    {
        //player=GameObject.Find("ship").transform;
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Ship>().scenechange && tr1==false)
        {
            animator.ResetTrigger("normal");
            animator.SetTrigger("boost");
            tr1=true;
            tr2=false;
        }
            
        if(player.GetComponent<Ship>().transform.position.x>16 && tr2==false)
        {
            animator.ResetTrigger("boost");
            //animator.Play("flamenormal");
            animator.SetTrigger("normal");
            Debug.Log("reset");
            tr2=true;
            tr1=false;
        }
            
    }
}
