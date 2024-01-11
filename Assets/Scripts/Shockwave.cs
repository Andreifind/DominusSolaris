using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
	public int damage = 20;
	public int speed=1;
	private Transform player;
	private Rigidbody2D body;
	private int nr;
	bool dial;
	[ColorUsage(true, true)]
	[SerializeField] private Color purple;
    // Start is called before the first frame update
    void Start()
    {
		player=GameObject.FindWithTag("Player").transform;
		//damage=20;
		//speed=1;
        body = this.GetComponent<Rigidbody2D>();
        player.GetComponent<Ship>().energy=0;
    }

    // Update is called once per frame
    void Update()
    {
		if(player.GetComponent<Ship>().planet<2) damage=15;
        else if(player.GetComponent<Ship>().planet>3) damage=35;
        else if(player.GetComponent<Ship>().planet==2 || player.GetComponent<Ship>().planet==3) damage=25;
			body.velocity = UnityEngine.Vector2.right*speed;	
		if (transform.position.x>16 || player.GetComponent<Ship>().hp<5)
			Destroy(gameObject);
    }
	void FixedUpdate()
	{
		dial=player.GetComponent<Ship>().dialog;
		if(dial)
			Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("enemy"))
	{
		other.GetComponent<Enemy>().hp -= damage;
		//other.GetComponent<Enemy>().ishit=1;
		if(other.GetComponent<Enemy>().clasa==2 && player.GetComponent<Ship>().overheat<90) player.GetComponent<Ship>().overheat+=player.GetComponent<Ship>().tax*0.7f;
		DamagePopup.Create(transform.position, damage);
	}
	if (other.gameObject.tag==("Projectile"))Destroy(other.gameObject);
	}
}
