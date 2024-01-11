using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astero : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    private Transform player;
    public GameObject exclam;
    private Vector2 poz;
    void Start()
    {
        player=GameObject.Find("ship").transform;
        poz= new Vector2(12,transform.position.y);
        Instantiate(exclam,poz,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.position.x<-48) Destroy(gameObject);
        if(transform.position.x<=16 &&transform.position.x>=15) player.GetComponent<Ship>().passby=true;
    }
    void OnTriggerEnter2D(Collider2D other)
		{
			if(other.gameObject.tag==("Player"))
                other.GetComponent<Ship>().hp-=10;
		}
}
