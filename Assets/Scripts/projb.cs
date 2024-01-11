using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projb : MonoBehaviour
{
	public int damage = 2;
	private int speed = 11;
	private Rigidbody2D body;
	private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
		player=GameObject.Find("ship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Ship>().dialog==false) body.velocity = UnityEngine.Vector2.left*speed;
		if (transform.position.x<-16)
			Destroy(gameObject);
    }
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("pew") || other.gameObject.tag==("shield"))
        {
			Destroy(gameObject);
		}
	if (other.gameObject.tag==("Player"))
	{
		other.GetComponent<Ship>().hp -= damage;
		Destroy(gameObject);
	}
	}
}

