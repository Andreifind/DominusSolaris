using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidmare : Enemy
{
    // Start is called before the first frame update
    private float oscilate;
    private Vector2 targetPos;
    public GameObject boom;
    public GameObject box;
    private Transform spawn;
    private Transform playe;
    int bocs;
    void Start()
    {
        playe = GameObject.FindWithTag("Player").transform;
        maxhp=playe.GetComponent<Ship>().damage*180;
        hp=maxhp;
        spawn=GameObject.FindWithTag("spawner").transform;
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
        if (playe.GetComponent<Ship>().hp<5 || playe.GetComponent<Ship>().justloaded || spawn.GetComponent<Spawner>().nr==0)
        {
           // Debug.Log("ded");
            spawn.GetComponent<Spawner>().aspawned=false;    
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
		//SLIDE
		if (oscilate==0 || transform.position.y+oscilate/2 > 1f || transform.position.y+oscilate/2<-1)
			oscilate=Random.Range(-1, 2);
		else
			if (transform.position.x<8)
			do
			{
				targetPos= new Vector2(transform.position.x, transform.position.y+(oscilate/Mathf.Abs(oscilate))/640);
				transform.position=targetPos;
			}while(transform.position.y==oscilate);
		// destroy
		if (hp<=0)
		{
                player.GetComponent<Ship>().overheat += 2*maxhp;
                base.award();
			Instantiate(boom, transform.position, Quaternion.identity);
			bocs=Random.Range(0, 10);
            spawn.GetComponent<Spawner>().bossded=1;
			if(bocs==5)
				Instantiate(box, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
    }
}
