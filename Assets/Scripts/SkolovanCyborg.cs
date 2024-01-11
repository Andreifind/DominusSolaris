using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkolovanCyborg : Enemy
{
    int oscilate;
    int launched=0;
    Rigidbody2D body;
    Vector2 targetPos;
    public GameObject boom;
    Vector2 lpos;
    Animator animator;
    public GameObject projectile;
    public GameObject projUP;
    public GameObject projFALL;
    public GameObject Raiders;
    private float tfire;
    //private Transform spawn;
    private Transform playe;
    private bool firsthalf=false;
    private bool secondhalf=false;
    private bool encounter=false;
    private bool CanFire = true;
    int act=0;
    int rst=0;
    Transform dialu;
    public int rand;
    [SerializeField] private HealthBar _healthBar;
    void Start()
    {
        rand=Random.Range(-20000,20000);
        body = this.GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        clasa = 2;
        hp=maxhp;
        spawner=GameObject.FindWithTag("spawner").transform;
        dialu=GameObject.FindWithTag("dialog").transform;
        playe = GameObject.FindWithTag("Player").transform;
        playe.GetComponent<Ship>().dialog=true;
        _healthBar.SetMaxHealth(maxhp);
    }
    public void shoot()
    {
        //Debug.Log("Atac");
        lpos= new Vector2();
        lpos.x=transform.position.x;
        lpos.y=transform.position.y+0.324f;
        Instantiate(projectile,lpos,Quaternion.identity);
        Sounds.PlaySound ("bossfire");
    }
    void Update()
    {
        _healthBar.SetHealth(hp);
        base.isded();
        if(playe.GetComponent<Ship>().justloaded==true) Destroy(gameObject);
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
            animator.SetTrigger("death");
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
            if (oscilate==0 || transform.position.y+oscilate > 3 || transform.position.y+oscilate<-3)
                oscilate=Random.Range(-1, 2);
            else
                if (transform.position.x<8 && playe.GetComponent<Ship>().dialog==false)
                do
                {
                    targetPos= new Vector2(transform.position.x, transform.position.y+(2*oscilate*Time.deltaTime));
                    transform.position=targetPos;
                }while(transform.position.y==oscilate);
                //foc
        if (tfire <= 0 && playe.GetComponent<Ship>().dialog==false && CanFire)
                {
                   // act=Random.Range(0,101);
                    if (act==6 && rst%2==1) 
                    {
                        animator.SetTrigger("armup");
                        animator.ResetTrigger("atac");
                        //Debug.Log("Radar");
                    }
                    else if (act==6 && rst%2==0)
                    {
                        animator.SetTrigger("push");
                        animator.ResetTrigger("atac");
                        StartCoroutine(HoldHoldFire());
                        //Debug.Log("Radar");
                    }
                    else if (act<6)
                    {
                        animator.SetTrigger("atac");
                        //shoot();
                        Debug.Log("atac");
                    }
                    else if(act>6)
                    {
                        animator.ResetTrigger("armup");
                        animator.ResetTrigger("shootup");
                        lpos= new Vector2(Random.Range(1, 9), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(9,25), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(9,25), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(9,25), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
                        lpos= new Vector2(Random.Range(9,25), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(1,9), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(1,9), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
                        lpos= new Vector2(Random.Range(1, 9), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(9,25), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(9,25), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(9,25), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
                        lpos= new Vector2(Random.Range(9,25), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(1,9), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
						lpos= new Vector2(Random.Range(1,9), 10+Random.Range(0, 10));
						Instantiate(projFALL,lpos,Quaternion.identity);
                        act++;
                    }
                    if(act<=6)
                    {
                        if(hp>maxhp/2)
                            tfire = atacc;
                        else tfire=atacc*.56f;
                    }
                    else tfire=atacc/2;
                    if(act<6 && rst%2==0)
                    act++;
                    else if((rst%2==1 && act==10) || (rst%2==0 && act==6))
                    {
                        act=0;
                        rst++;
                    }
                    else if(act<10 && rst%2==1) act++;
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
        spawner.GetComponent<Spawner>().bossded=1;
        playe.GetComponent<Ship>().marebos=true;
        Sounds.PlaySound ("bossboom");
        Destroy(gameObject);
    }
    public void shootup()
    {
        lpos=new Vector2(transform.position.x+0.323f, transform.position.y+1.497f);
        Instantiate(projUP, lpos, Quaternion.identity);
        launched++;
        if(launched>=15)
        {
            animator.SetTrigger("shootup");
            animator.ResetTrigger("armup");
            launched=0;
        }
    }
    public void button()
    {
        Instantiate(Raiders, new Vector2(16,2), Quaternion.identity);
        Instantiate(Raiders, new Vector2(20,0), Quaternion.identity);
        Instantiate(Raiders, new Vector2(24,-2), Quaternion.identity);
        Instantiate(Raiders, new Vector2(28,2), Quaternion.identity);
        animator.ResetTrigger("push");
    }

    void OnTriggerEnter2D(Collider2D other)
	{
        Debug.Log("collider");
	    if (other.gameObject.name==("SkolovanCyborg(Clone)"))
			if(rand>other.GetComponent<SkolovanCyborg>().rand) Destroy(gameObject);
	}
    private IEnumerator HoldHoldFire()
    {
        yield return new WaitForSeconds(3);
        CanFire = false;
        StartCoroutine(HoldFire());
    }
    private IEnumerator HoldFire()
    {
        yield return new WaitForSeconds(7);
        CanFire = true;
    }
}