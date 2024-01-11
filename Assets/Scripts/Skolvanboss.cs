using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skolvanboss : Enemy
{
    int oscilate;
    Rigidbody2D body;
    Vector2 targetPos;
    public GameObject boom;
    Vector2 lpos;
    Animator animator;
    public GameObject projectile;
    private float tfire;
    private Transform spawn;
    private Transform playe;
    private bool firsthalf=false;
    private bool secondhalf=false;
    private bool encounter=false;
    private bool CanFire = true;
    [SerializeField] private HealthBar _healthBar;
    int act=0;
    Transform dialu;
    public int rand;
    void Start()
    {
        rand=Random.Range(-20000,20000);
        body = this.GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        //a=Random.Range(-4,2);
        clasa = 2;
        hp=maxhp;
        spawn=GameObject.FindWithTag("spawner").transform;
        dialu=GameObject.FindWithTag("dialog").transform;
        playe = GameObject.FindWithTag("Player").transform;
        playe.GetComponent<Ship>().dialog=true;
        _healthBar.SetMaxHealth(maxhp);
    }
    public void shoot()
    {
        //Debug.Log("Atac");
        lpos= new Vector2();
        lpos.x=transform.position.x-1.05f;
        lpos.y=transform.position.y+0.12f;
        Instantiate(projectile,lpos,Quaternion.identity);
        Sounds.PlaySound ("bossfire");
    }
    void Update()
    {
        _healthBar.SetHealth(hp);
        base.isded();
        if(hp<maxhp/2 && firsthalf==false)
        {
            firsthalf=true;
            playe.GetComponent<Ship>().dialog=true;
            dialu.GetComponent<Dialog_Comp>().turnon();
            dialu.GetComponent<Dialog>().reset();
            dialu.GetComponent<Dialog>().type();
        }
         if (playe.GetComponent<Ship>().hp<5 || playe.GetComponent<Ship>().justloaded)
        {
           // Debug.Log("ded");
            spawner.GetComponent<Spawner>().nr=0;    
            Destroy(gameObject);
        }
        
        if (hp<=0)
        {
            animator.SetTrigger("Death");
        }
            if (transform.position.x<=9 & encounter==false) 
            {
                playe.GetComponent<Ship>().dialog=true;
                encounter=true;
                dialu.GetComponent<Dialog_Comp>().turnon();
                dialu.GetComponent<Dialog>().reset();
                dialu.GetComponent<Dialog>().type();
            }
            if (transform.position.x>8) transform.Translate(Vector2.left * 4 * Time.deltaTime);
            if (oscilate==0 || transform.position.y+oscilate > 5 || transform.position.y+oscilate<-5)
                oscilate=Random.Range(-1, 2);
            else
                if (transform.position.x<8 && playe.GetComponent<Ship>().dialog==false)
                do
                {
                    targetPos= new Vector2(transform.position.x, transform.position.y+(4*oscilate*Time.deltaTime));
                    transform.position=targetPos;
                }while(transform.position.y==oscilate);
                //foc
        if (tfire <= 0 && playe.GetComponent<Ship>().dialog==false && CanFire)
                {
                   // act=Random.Range(0,101);
                    if (act%5==0)
                    {
                        animator.SetTrigger("Radar");
                        StartCoroutine(HoldHoldFire());
                        //Debug.Log("Radar");
                    }
                    else
                    {
                        animator.SetTrigger("Atac");
                        //shoot();
                    }
                    tfire = atacc;
                    act++;
                }
                else if (playe.GetComponent<Ship>().dialog==false)
                {
                    tfire -= Time.deltaTime;
                    //animator.ResetTrigger("Atac");
                    //animator.ResetTrigger("Radar");
                }
        
         
    }
    public void bum()
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        //base.perish();
        spawn.GetComponent<Spawner>().bossded=1;
        playe.GetComponent<Ship>().marebos=true;
        Sounds.PlaySound ("bossboom");
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.name==("SkolvanBoss(Clone)"))
			if(rand>other.GetComponent<Skolvanboss>().rand) Destroy(gameObject);
	}
    private IEnumerator HoldFire()
    {
        yield return new WaitForSeconds(7);
        CanFire = true;
    }
    private IEnumerator HoldHoldFire()
    {
        yield return new WaitForSeconds(5);
        CanFire = false;
        StartCoroutine(HoldFire());
    }
}
