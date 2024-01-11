using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	private Transform player;
	private Vector2 targetPos;
	Animator animator;
	float tfire;
	float atacc;
	public float ics;
	public bool hit=false;
	public GameObject inv;
	private SpriteRenderer spriteRenderer;
	Vector2 poss;
	//public int damage=20;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship").transform;
		animator=GetComponent<Animator>();
		atacc=.02f;
		spriteRenderer = GetComponent<SpriteRenderer>();
      	spriteRenderer.drawMode = SpriteDrawMode.Tiled;
      	spriteRenderer.size = new Vector2(22.3f,.45f);
		player.GetComponent<Ship>().laseron=true;
		
    }

    // Update is called once per frame
    void Update()
    {
		poss= new Vector2(transform.position.x-7f, transform.position.y-.12f);
		if (tfire <= 0)
                {
                    Instantiate(inv, poss, Quaternion.identity);
                    tfire = atacc;
                }
                else
                    tfire -= Time.deltaTime;

		if (player.GetComponent<Ship>().hp<5)
            Destroy(gameObject);
        targetPos= new Vector2(player.position.x+1f, player.position.y-0.12f);
		transform.position=targetPos;
		if (player.GetComponent<Ship>().energy<=0f)
		{
			player.GetComponent<Ship>().laserdown=1;
			Sounds.PlaySound ("laserend");
			animator.SetTrigger("out");
			player.GetComponent<Ship>().laseron=false;
			Destroy(gameObject);
			player.GetComponent<Ship>().lass=true;
		}
		else 
			player.GetComponent<Ship>().energy-=50*Time.deltaTime;
    }
	void OnTriggerEnter2D(Collider2D other)
	{
	// if (other.gameObject.tag==("enemy"))
	// {
	// 	DamagePopup.Create(other.GetComponent<Enemy>().transform.position, player.GetComponent<Ship>().laserdamage);
	// 	other.GetComponent<Enemy>().hp-=player.GetComponent<Ship>().laserdamage;
	// }
	if (other.gameObject.tag==("enemy"))
	{
		spriteRenderer.size = new Vector2(other.transform.position.x-player.transform.position.x-1.5f,.45f);
		Debug.Log(player.transform.position.x-other.transform.position.x);
	}
	else spriteRenderer.size = new Vector2(22.3f,.45f);
 	//transform.localScale = lTemp;	
	if (other.gameObject.tag==("Projectile"))
	{
		Destroy(other.gameObject);
	}
	}
	void FixedUpdate()
	{
		if(hit)
		{
			spriteRenderer.size = new Vector2(ics-player.transform.position.x-1.5f,.45f);
		}
		
	}
		
	

}
