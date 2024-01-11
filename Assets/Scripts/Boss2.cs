using System.Collections;
using UnityEngine;

public class Boss2 : Enemy
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
    private bool encounter=false;
    public bool CanFire = true;
    int act=0;
    Transform dialu;
    public int rand;
    [SerializeField] private HealthBar healthBar;
    void Start()
    {
        rand=Random.Range(-20000,20000);
        body = this.GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        //a=Random.Range(-4,2);
        clasa = 2;
        maxhp=800;
        hp=maxhp;
        spawn=GameObject.FindWithTag("spawner").transform;
        dialu=GameObject.FindWithTag("dialog").transform;
        playe = GameObject.FindWithTag("Player").transform;
        playe.GetComponent<Ship>().dialog=true;
        healthBar.SetMaxHealth(maxhp);
    }
    public void shoot()
    {
        //Debug.Log("Atac");
        
        Sounds.PlaySound ("bossfire");
    }
    void Update()
    {
        healthBar.SetHealth(hp);
        if (hp<maxhp/2 && firsthalf==false)
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
        base.isded();
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
            if (oscilate==0 || transform.position.y+oscilate > 3 || transform.position.y+oscilate<-1)
                oscilate=Random.Range(-1, 2);
            else
                if (transform.position.x<8 && playe.GetComponent<Ship>().dialog==false)
                do
                {
                    targetPos= new Vector2(transform.position.x, transform.position.y+(oscilate*Time.deltaTime));
                    transform.position=targetPos;
                }while(transform.position.y==oscilate);
                //foc
        if (tfire <= 0 && playe.GetComponent<Ship>().dialog==false)
                {
                   // act=Random.Range(0,101);
                    if (act%3==0)
                    {
                        animator.SetTrigger("flare");
                        StartCoroutine(HoldHoldFire());
                //Debug.Log("Radar");
            }
                    else
                    {
                        animator.SetTrigger("emp");
                        //shoot();
                    }
                    tfire = atacc;
                    act++;
                }
                else
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
        Sounds.PlaySound ("bossboom");
        playe.GetComponent<Ship>().marebos=true;
        Destroy(gameObject);
    }
    public void flare()
    {
        Sounds.PlaySound ("flare");
        lpos= new Vector2();
        lpos.x=transform.position.x+2.17f;
        lpos.y=transform.position.y+0.96f;
        Instantiate(projectile,lpos,Quaternion.identity);
    }
    public void deplete()
    {
        Sounds.PlaySound ("tesla");
        playe.GetComponent<Ship>().overheat=1;
        playe.GetComponent<Ship>().energy=1;
    }

    void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.name==("SkolvanTesla(Clone)"))
			if(rand>other.GetComponent<Boss2>().rand) Destroy(gameObject);
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
