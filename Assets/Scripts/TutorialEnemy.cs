using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : Enemy
{
	private Rigidbody2D body= null;
	public GameObject boom;
	public GameObject box;
	public GameObject proj;
	private Vector2 targetPos;
	private float tfire;
	private Vector2 startPos;
	private float oscilate;
	Animator animator;
	private int bocs;
	public GameObject sprk;
    Transform dialu;
    private Transform spawn;
    private Transform playe;
    private bool encounter=false;
    bool firsthalf=false;

    // Start is called before the first frame update
    void Start()
    {
		animator=GetComponent<Animator>();
        maxhp=90;
		base.Start();
		tfire= atacc/2;
        //body.velocity = new UnityEngine.Vector2(-1,0);
        spawn=GameObject.FindWithTag("spawner").transform;
        dialu=GameObject.FindWithTag("dialog").transform;
        playe = GameObject.FindWithTag("Player").transform;
        playe.GetComponent<Ship>().dialog=true;
        hp=4;
        //if(playe.GetComponent<Ship>().wave==1) clasa=0;
    }

    // Update is called once per frame
    void Update()
    {
        base.isded();
			startPos= new Vector2(transform.position.x-0.91f, transform.position.y-0.08f);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
		if (transform.position.x<8) speed=0;
		// destroy
		if (hp<=0)
		{
            player.GetComponent<Ship>().overheat += 2*maxhp;
			Instantiate(boom, transform.position, Quaternion.identity);
			if(playe.GetComponent<Ship>().wave==1)Instantiate(box, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		if(transform.position.x<-16 )
			Destroy(gameObject);
        if (transform.position.x<=9 & encounter==false) 
            {
                playe.GetComponent<Ship>().dialog=true;
                encounter=true;
                dialu.GetComponent<Dialog_Comp>().turnon();
                dialu.GetComponent<Dialog>().reset();
                dialu.GetComponent<Dialog>().type();
            }
        if(hp<=2 && firsthalf==false && playe.GetComponent<Ship>().wave==1)
        {
            firsthalf=true;
            playe.GetComponent<Ship>().dialog=true;
            dialu.GetComponent<Dialog_Comp>().turnon();
            dialu.GetComponent<Dialog>().reset();
            dialu.GetComponent<Dialog>().type();
        }
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("Player"))
        {
			//Destroy(gameObject);
			hp-=5;
			other.GetComponent<Ship>().hp -= 10;
		}
	}
	public void atac()
	{
		Instantiate(proj, startPos, Quaternion.identity);
		Instantiate(sprk, startPos, Quaternion.identity);
        tfire = atacc;
		animator.ResetTrigger("atac");
	}
}
