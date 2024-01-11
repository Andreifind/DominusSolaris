using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
	private Transform ship;
	private Rigidbody2D body;
	public int speed;
	private int bon;
	private float oscilate;
	private Vector2 startPos;
	private float igrec;
	private bool top=false;
	private bool bot=true;
    // Start is called before the first frame update
    void Start()
    {
        ship=GameObject.Find("ship").transform;
		bon=Random.Range(0, 3);
		igrec=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
		if(ship.GetComponent<Ship>().dialog==false)
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		 if (transform.position.x<-9 || ship.GetComponent<Ship>().hp<5)
		 	Destroy(gameObject);
		if(transform.position.y<=igrec+0.2f && bot)
			transform.Translate(Vector2.up*Time.deltaTime);
			else if (transform.position.y>=igrec-0.2f && top)
				transform.Translate(Vector2.down*Time.deltaTime);
				else if (transform.position.y>=igrec+0.2f && bot)
				{
					bot=false;
					top=true;
				}
					else if (transform.position.y<=igrec-0.2f && top)
					{
						bot=true;
						top=false;
					}

		}
        
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag==("Player"))
		{
			//if(ship.GetComponent<Ship>().laseron==false) ship.GetComponent<Ship>().energy=100;
			ship.GetComponent<Ship>().pickup=true;	
			Sounds.PlaySound ("bonus");
			Destroy(gameObject);
		}
	}
	
}
