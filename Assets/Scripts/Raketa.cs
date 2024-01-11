using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raketa : MonoBehaviour
{
    private Transform Target;
    private Transform player;
    GameObject spawner;
    public float distance; //distance to target
    public float maxDistance = 8.0f;
    private Rigidbody2D bode;
    private int damage;
    void Start()
    {
        player=GameObject.Find("ship").transform;
        damage=player.GetComponent<Ship>().roketdmg;
        bode=this.GetComponent<Rigidbody2D>();
        spawner=GameObject.Find("Spawner");
    }
    void Update()
    {
        if(spawner.GetComponent<Spawner>().bossded!=0) Destroy(gameObject);
        if(player.GetComponent<Ship>().planet<2) damage=10;
        else if(player.GetComponent<Ship>().planet>3) damage=30;
        else if(player.GetComponent<Ship>().planet==2 || player.GetComponent<Ship>().planet==3) damage=20;

        if (player.GetComponent<Ship>().hp<5)
            Destroy(gameObject);
        Target = GameObject.FindGameObjectWithTag("enemy").transform;
        if (Target==null) Destroy(gameObject);
        //Debug.Log(Target);
        transform.Translate(Vector2.right * 4 * Time.deltaTime);
         distance = Vector2.Distance(transform.position, Target.transform.position);
        if(transform.position.y>Target.transform.position.y) 
        {
            //bode.velocity = UnityEngine.Vector2.down * 3;
             transform.Translate(Vector2.down * 6 * Time.deltaTime);
        }
        else if(transform.position.y<Target.transform.position.y) 
        {
            //bode.velocity = UnityEngine.Vector2.up * 3;
             transform.Translate(Vector2.up * 6 * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("enemy"))
        {
			//
			other.GetComponent<Enemy>().hp -= damage;
            DamagePopup.Create(transform.position, damage);
            Sounds.PlaySound ("bum");
            Destroy(gameObject);
		}
    if (other.gameObject.tag==("Projectile"))
    {
        Destroy(other.gameObject);
    }
	}
	}

