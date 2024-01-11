using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjFall : MonoBehaviour
{
    public int speed;
    private Rigidbody2D body= null;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        player=GameObject.Find("ship").transform;
        transform.Rotate(0,0,45);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Ship>().dialog==false) transform.Translate(Vector2.left * Time.deltaTime *speed);
        if(transform.position.x<-18) Destroy(gameObject);
        if (player.GetComponent<Ship>().hp<5)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
		{
			if(other.gameObject.tag==("Player"))
            {
                other.GetComponent<Ship>().hp-=10;
                Destroy(gameObject);
            }
		}
}
