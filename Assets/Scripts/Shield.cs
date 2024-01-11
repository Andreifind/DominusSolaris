using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	private Transform player;
	private Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos= new Vector2(player.position.x-1.3f, player.position.y);
		transform.position=targetPos;
		if (player.GetComponent<Ship>().energy<=0f)
		{
			player.GetComponent<Ship>().shieldsdown=1;
			Sounds.PlaySound ("shieldd");
			Destroy(gameObject);
		}
		else 
			player.GetComponent<Ship>().energy-=.2f;
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("enemy"))
	{
		other.GetComponent<Enemy>().hp-=20;
	}
	if (other.gameObject.tag==("Projectile"))
	{
		Destroy(other.gameObject);
	}
	}
}
