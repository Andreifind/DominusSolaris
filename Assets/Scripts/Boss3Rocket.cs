using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Rocket : Enemy
{
    private Transform Target;
    public float distance; //distance to target
    public float maxDistance = 8.0f;
    private Rigidbody2D bode;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player= GameObject.Find("ship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
        if (player.GetComponent<Ship>().hp<5 || player.GetComponent<Ship>().dialog)
            Destroy(gameObject);
        Target = player;
        transform.Translate(Vector2.left * 8 * Time.deltaTime);
         distance = Vector2.Distance(transform.position, Target.transform.position);
        if(transform.position.y>Target.transform.position.y) 
        {
            //bode.velocity = UnityEngine.Vector2.down * 3;
             transform.Translate(Vector2.down * 3 * Time.deltaTime);
        }
        else if(transform.position.y<Target.transform.position.y) 
        {
            //bode.velocity = UnityEngine.Vector2.up * 3;
             transform.Translate(Vector2.up * 3 * Time.deltaTime);
        }
        if(hp<=0 || player.GetComponent<Ship>().justloaded)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("Player"))
        {
			//
			other.GetComponent<Ship>().hp -= 5;
            Sounds.PlaySound ("bum");
            Destroy(gameObject);
		}
    }
}
