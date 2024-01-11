using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien1 : Enemy
{
	private Rigidbody2D body= null;
	public GameObject boom;
	public GameObject box;
	public GameObject proj;
	private Vector2 targetPos;
	private float tfire;
	private Vector2 startPos;
	private float oscilate;
	private int bocs;
	public CameraShake cam;
    // Start is called before the first frame update
    void Start()
    {
		tfire= atacc/2;
        //body.velocity = new UnityEngine.Vector2(-1,0);
    }

    // Update is called once per frame
    void Update()
    {
		startPos= new Vector2(transform.position.x-2, transform.position.y);
		if (tfire <= 0)
                {
                    Instantiate(proj, startPos, Quaternion.identity);
                    tfire = atacc;
                }
                else
                    tfire -= Time.deltaTime;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
		
		//SLIDE
		if (oscilate==0 || transform.position.y+oscilate > 5 || transform.position.y+oscilate<-5)
			oscilate=Random.Range(-3, 3);
		else
			if (transform.position.x<6)
			do
			{
				targetPos= new Vector2(transform.position.x, transform.position.y+(oscilate/Mathf.Abs(oscilate))/32);
				transform.position=targetPos;
			}while(transform.position.y==oscilate);
		// destroy
		if (hp<=0)
		{
			StartCoroutine(cam.Shake(1.35f,1.4f));
			//hp-=1;
			Instantiate(boom, transform.position, Quaternion.identity);
			
			bocs=Random.Range(0, 11);
			if(bocs==5)
				Instantiate(box, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		if(transform.position.x<-16 )
			Destroy(gameObject);
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("Player"))
        {
			//Destroy(gameObject);
			hp-=5;
			other.GetComponent<Ship>().hp -= 10;
		}
	/*if (other.gameObject.tag==("shield"))
	{
		Instantiate(boom, transform.position, Quaternion.identity);
			Destroy(gameObject);
	}*/
	}
	
	
	//other.GetComponent<Player>().health -= 1;
	//Debug.Log(other.GetComponent<Player>().health);
	
}
