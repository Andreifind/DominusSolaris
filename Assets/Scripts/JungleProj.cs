using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleProj : Projectile
{
	public int damage = 2;
	public int speed = 7;
	private Rigidbody2D body;
	private Transform player;
	private Transform spawn;
    public int plan;
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
        if (player.GetComponent<Ship>().dialog==false) transform.Translate(Vector2.left * speed * Time.deltaTime);
		//if (player.GetComponent<Ship>().dialog) body.velocity = new Vector2 (0,0);
		if (transform.position.x<-16 || player.GetComponent<Ship>().hp<5 || spawn.GetComponent<Spawner>().planet==plan)
			Destroy(gameObject);
    }
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("pew") || other.gameObject.tag==("shield"))
        {
			if(spawn.GetComponent<Spawner>().planet==3)
			Destroy(other.gameObject);
			else Destroy(gameObject);
		}
	if (other.gameObject.tag==("Player"))
	{
		other.GetComponent<Ship>().hp -= damage;
		Destroy(gameObject);
	}
	}
}
