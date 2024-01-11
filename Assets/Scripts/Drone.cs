using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Enemy
{
    public float rspeed;
    public float w;
    float x,y,timeCounter;
    public int stac;
    public GameObject drona2;
    public GameObject expl;
    public GameObject pr;
    private Boss4 cent;
    int stage=0;
    Animator animator;
    private bool fpos=true;
    private float tfire;
    public GameObject wasps;
    private float RotateSpeed = 2f;
    private float Radius = 2.1f;
    int shots=0;
     private Vector2 _centre;
     private float _angle;
     private Transform playe;
    [SerializeField] private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        tfire=1;
        animator=GetComponent<Animator>();

        cent= GetComponentInParent<Boss4>();
        _centre = cent.transform.position;

        playe = GameObject.FindWithTag("Player").transform;

        if(cent.can==3) maxhp=150;
        if(cent.can==2) maxhp=250;
        if(cent.can==1) maxhp=350;
        if(cent.can==0) maxhp=450;
        base.Start();
        healthBar.SetMaxHealth(maxhp);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(hp);
        base.isded();
        ///
        if (shots%14==0 && maxhp==450)
        {
            StartCoroutine(HoldFire());
            Instantiate(wasps, new Vector2(16,2), Quaternion.identity);
            Instantiate(wasps, new Vector2(26,0), Quaternion.identity);
            Instantiate(wasps, new Vector2(36,-2), Quaternion.identity);
            shots++;
        }
        _centre =GameObject.FindWithTag("boss").transform.position;
        if(cent.GetComponent<Boss4>().dronesdead==0)
            _angle += RotateSpeed * Time.deltaTime;
        if(cent.GetComponent<Boss4>().dronesdead==1)
            _angle += RotateSpeed * 1.5f * Time.deltaTime;
        if(cent.GetComponent<Boss4>().dronesdead==2)
            _angle += RotateSpeed * 2 * Time.deltaTime;
        if(cent.GetComponent<Boss4>().dronesdead==3)
            _angle += RotateSpeed * 2.5f * Time.deltaTime;
         var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
         transform.position = _centre + offset;


        if (tfire <= 0 && transform.position.x<5.5f && playe.GetComponent<Ship>().dialog==false && cent.CanFire==true)
                {
                   Instantiate(pr, new Vector2(transform.position.x-0.11f, transform.position.y+0.23f), Quaternion.identity);
                   shots++;
                   tfire=1;
                }
                else
                    tfire -= Time.deltaTime;

        timeCounter+=Time.deltaTime*rspeed;
        x=Mathf.Cos(timeCounter)*w;
        y=Mathf.Sin(timeCounter)*w;
        //transform.position=new Vector2(x,y);
        if(transform.position.x>=2.49f && fpos)
        {
            
            fpos=false;
        }

        if(transform.position.x<=-2.49f) fpos=true;
        if(transform.position.y>=2.49f && stac==4)
        {
            Instantiate(drona2, new Vector2(0,0), Quaternion.identity);
            stac--;
        } 
        if(transform.position.x<=-2.49f && stac==3)
        {
            Instantiate(drona2, new Vector2(0,0), Quaternion.identity);
            stac--;
        }
        if(transform.position.y<=-2.49f && stac==2)
        {
            Instantiate(drona2, new Vector2(0,0), Quaternion.identity);
            stac--;
        }
        if(hp<=maxhp*0.66f && stage==0) 
        {
            animator.Play("drona66");
            stage++;
        }
        if(hp<=maxhp*0.33f && stage==1)
        {
            animator.Play("drona33");
            stage++;
        }
        if(hp<=0)
        {
            cent.GetComponent<Boss4>().dronesdead++;
            Instantiate(expl, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
            
    }
    private IEnumerator HoldFire()
    {
        cent.CanFire = false;
        yield return new WaitForSeconds(12);
        cent.CanFire = true;
    }
}
