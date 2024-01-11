using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProj : Projectile
{
	public int damage = 2;
	public int speed = 7;
	private Rigidbody2D body;
	private Transform player;
	private Transform spawn;
    public int p;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
		player=GameObject.Find("ship").transform;
		spawn=GameObject.FindWithTag("spawner").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //body.velocity = UnityEngine.Vector2.left*speed;
		if (player.GetComponent<Ship>().dialog==false) transform.Translate(Vector2.right * speed * Time.deltaTime);
		if (player.GetComponent<Ship>().dialog) body.velocity = new Vector2 (0,0);
		if (transform.position.x<-16 || player.GetComponent<Ship>().hp<5 || spawn.GetComponent<Spawner>().planet!=p)
			Destroy(gameObject);
    }
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("shield")||other.gameObject.tag==("laserpew"))
        {
			Destroy(gameObject);
		}
    if (other.gameObject.tag==("pew"))
		{
			if(other.GetComponent<PewPew>().IsPiercing)
                Destroy(gameObject);
			else
				Destroy(other.gameObject);
		}
	if (other.gameObject.tag==("Player"))
	{
		other.GetComponent<Ship>().hp -= damage;
		Destroy(gameObject);
	}
	}
}
