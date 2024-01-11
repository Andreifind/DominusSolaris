using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
	public int damage = 2;
	public int speed=3;
	private Transform player;
	private Rigidbody2D body;
	public GameObject boom;
	private int nr;
	bool dial;
	[ColorUsage(true, true)]
	[SerializeField] private Color purple;
	public bool IsPiercing=false;
    // Start is called before the first frame update
    void Start()
    {
		player=GameObject.FindWithTag("Player").transform;
		damage=player.GetComponent<Ship>().damage;
		speed=player.GetComponent<Ship>().speed;
        body = this.GetComponent<Rigidbody2D>();
		nr=Random.Range(0, 100);
		if (nr>player.GetComponent<Ship>().crit)
		{
			GetComponent<Renderer>().material.SetColor("_Color", purple);
			damage*=2;
		}
		if (player.GetComponent<Ship>().pierce == 1) IsPiercing = true;
    }

    // Update is called once per frame
    void Update()
    {
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
	if (other.gameObject.name==("poc") || other.gameObject.tag==("enemy"))
        {
			Instantiate(boom, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	if (other.gameObject.tag==("Projectile"))
	{
		player.GetComponent<Ship>().hitted++;
		if (player.GetComponent<Ship>().pierce==0)
			{
			Instantiate(boom, transform.position, Quaternion.identity);
			Destroy(gameObject);
			}
		else Instantiate(boom, transform.position, Quaternion.identity);
	}
		
	if (other.gameObject.tag==("enemy"))
	{
		player.GetComponent<Ship>().hitted++;
		other.GetComponent<Enemy>().hp -= damage;
		//other.GetComponent<Enemy>().ishit=1;
		if(other.GetComponent<Enemy>().clasa==2 && player.GetComponent<Ship>().overheat<90 || other.GetComponent<Enemy>().maxhp>30) player.GetComponent<Ship>().overheat+=player.GetComponent<Ship>().tax*0.7f;
		DamagePopup.Create(transform.position, damage);
	}
		
	}
}
