using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float frequency;
    public float intensity;
    private Rigidbody2D body;
    private Vector2 startPos;
	private float igrec;
	private bool top=false;
	private bool bot=true;
    // Start is called before the first frame update
    void Start()
    {
        igrec=transform.position.y;
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<=igrec+0.5f && bot)
			transform.Translate(Vector2.up*Time.deltaTime);
			else if (transform.position.y>=igrec-0.5f && top)
				transform.Translate(Vector2.down*Time.deltaTime);
				else if (transform.position.y>=igrec+0.5f && bot)
				{
					bot=false;
					top=true;
				}
					else if (transform.position.y<=igrec-0.5f && top)
					{
						bot=true;
						top=false;
					}
    }
}
