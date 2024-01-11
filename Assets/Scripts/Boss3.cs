using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : Enemy
{
    int oscilate;
    Rigidbody2D body;
    Vector2 targetPos;
    public GameObject boom;
    Vector2 lpos;
    Animator animator;
    private float tfire;
    private bool firsthalf=false;
    private bool secondhalf=false;
    private bool encounter=false;
    private bool CanFire = true;
    public int act=0;
    Transform dialu;

    public GameObject projectile;
    public GameObject racheta;
    public GameObject laserbeam;
    public GameObject interceptor;

    public int beams=0;
    public int rand;

    [SerializeField] private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        rand=Random.Range(-20000,20000);
        body = this.GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        //a=Random.Range(-4,2);
        clasa = 2;
        hp=maxhp;
        spawner=GameObject.FindWithTag("spawner").transform;
        dialu=GameObject.FindWithTag("dialog").transform;
        player = GameObject.FindWithTag("Player").transform;
        player.GetComponent<Ship>().dialog=true;
        healthBar.SetMaxHealth(maxhp);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(hp);
        lpos =new Vector2(transform.position.x-0.092f,transform.position.y-0.506f);
        if(hp<maxhp/2 && firsthalf==false && beams==0)
        {
            firsthalf=true;
            player.GetComponent<Ship>().dialog=true;
            dialu.GetComponent<Dialog_Comp>().turnon();
            dialu.GetComponent<Dialog>().reset();
            dialu.GetComponent<Dialog>().type();
        }
         if (player.GetComponent<Ship>().hp<5 || player.GetComponent<Ship>().justloaded)
        {
           // Debug.Log("ded");
            spawner.GetComponent<Spawner>().nr=0;    
            Destroy(gameObject);
        }
        base.isded();
        if (hp<=0)
        {
            Instantiate(boom,transform.position,Quaternion.identity);
            spawner.GetComponent<Spawner>().bossded=1;
            player.GetComponent<Ship>().marebos=true;
            Sounds.PlaySound ("bossboom");
            Destroy(gameObject);
        }
        if (transform.position.x<=9 & encounter==false) 
            {
                player.GetComponent<Ship>().dialog=true;
                encounter=true;
                dialu.GetComponent<Dialog_Comp>().turnon();
                dialu.GetComponent<Dialog>().reset();
                dialu.GetComponent<Dialog>().type();
            }
            if (transform.position.x>8) transform.Translate(Vector2.left * 4 * Time.deltaTime);
            if (oscilate==0 || transform.position.y+oscilate > 4 || transform.position.y+oscilate<-3)
                oscilate=Random.Range(-1, 2);
            else
                if ((transform.position.x<=8) && (player.GetComponent<Ship>().dialog==false) && (beams==0))
                do
                {
                    targetPos= new Vector2(transform.position.x, transform.position.y+(oscilate*Time.deltaTime*3));
                    transform.position=targetPos;
                }while(transform.position.y==oscilate);
                //foc
        if (tfire <= 0 && player.GetComponent<Ship>().dialog==false && CanFire)
                {
                    if (act==3)
                    {
                        Instantiate(racheta,lpos,Quaternion.identity);
            }
                    else if (act==12)
                    {
                        animator.SetTrigger("laser");
                        beams=1;
                        StartCoroutine(HoldHoldFire());
                    }
                    else 
                    {
                        animator.SetTrigger("pew");
                        Debug.Log("ACT Else");
            }
                    tfire = atacc/Random.Range(1, 3);;
                    act++;
                    if(act>12) act=1;
                }
                else
                {
                    tfire -= Time.deltaTime;
                }
    }
    public void shoot()
    {
        Instantiate(projectile,lpos,Quaternion.identity);

    }
    public void lasergo()
    {
        animator.SetTrigger("laseron");
        //beams=1;
        laserbeam.SetActive(true);
    }
    public void refresh()
    {
        beams = 0;
        Debug.Log("Refresh");
        laserbeam.SetActive(false);
    }
    public void beamm()
    {
        Debug.Log(beams);
        beams++;
        if(beams>=24 || beams==0)
        {
            animator.SetTrigger("laseroff");
            laserbeam.SetActive(false);
            //beams=0;
            //Instantiate(interceptor, new Vector2(16,2), Quaternion.identity);
            Instantiate(interceptor, new Vector2(20,1), Quaternion.identity);
            Instantiate(interceptor, new Vector2(28,0), Quaternion.identity);
            Instantiate(interceptor, new Vector2(36,-1), Quaternion.identity);
            act=0; 
        } 
    }
    void OnTriggerEnter2D(Collider2D other)
	{
        //Debug.Log("collider");
	if (other.gameObject.name==("Boss3(Clone)"))
			if(rand>other.GetComponent<Boss3>().rand) Destroy(gameObject);
	}
    private IEnumerator HoldHoldFire()
    {
        yield return new WaitForSeconds(3);
        CanFire = false;
        StartCoroutine(HoldFire());
    }
    private IEnumerator HoldFire()
    {
        yield return new WaitForSeconds(10);
        CanFire = true;
    }

}
