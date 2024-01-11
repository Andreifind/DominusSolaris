using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : Enemy
{
    private Rigidbody2D body;
	public GameObject boom;
	public GameObject box;
	private int bocs;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (hp<=0)
		{
                player.GetComponent<Ship>().overheat += 2*maxhp;
			Instantiate(boom, transform.position, Quaternion.identity);
			
			bocs=Random.Range(0, 10);
			if(bocs==5)
				Instantiate(box, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
    }
}
