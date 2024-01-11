using UnityEngine;

public class Boss4 : Enemy
{
    bool canspawn=true;
    public GameObject drona;
    public GameObject gandac;

    private float oscilate;
    public GameObject expl;
    Vector2 targetPos;
    private float tfire=0;
    public int dronesdead=0;
    public int can=4;
    Animator animator;
    Transform dialu;
    bool firsthalf=false;
    private Transform playe;
    public bool fst=false,snd=false,trd=false;
    // Start is called before the first frame update
    public bool CanFire = true;
    void Start()
    {
        base.Start();
        animator=GetComponent<Animator>();
        dialu=GameObject.FindWithTag("dialog").transform;
        playe = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //dialog
        if(dronesdead==2 && firsthalf==false)
        {
            firsthalf=true;
            playe.GetComponent<Ship>().dialog=true;
            dialu.GetComponent<Dialog_Comp>().turnon();
            dialu.GetComponent<Dialog>().reset();
            dialu.GetComponent<Dialog>().type();
        }
        //
        base.isded();
        if(transform.position.x>7.5f)    
            transform.Translate(Vector2.left * 2 * Time.deltaTime);
        else if (playe.GetComponent<Ship>().dialog==false)
        {
            if (oscilate==0 || transform.position.y+oscilate > 4.3f || transform.position.y+oscilate<-3)
			oscilate=Random.Range(-2, 4);
		    else
			if (transform.position.x<8)
			do
			{
				targetPos= new Vector2(transform.position.x, transform.position.y+(oscilate/Mathf.Abs(oscilate))*Time.deltaTime);
				transform.position=targetPos;
			}while(transform.position.y==oscilate);
        }
        if (tfire <= 0 && can>0)
                {
                   var drone = Instantiate(drona,new Vector2(transform.position.x+2.49f,transform.position.y), Quaternion.identity);
                   drone.transform.parent = this.transform;
            tfire =0.75f;
                   can--;
                }
                else
                    tfire -= Time.deltaTime;
        if(dronesdead==4)
            animator.SetTrigger("dead");
        
    }
    public void ending()
    {
        Instantiate(gandac, transform.position, Quaternion.identity);
        Instantiate(expl, transform.position, Quaternion.identity);
        playe.GetComponent<Ship>().dialog=true;
        dialu.GetComponent<Dialog_Comp>().turnon();
        dialu.GetComponent<Dialog>().reset();
        dialu.GetComponent<Dialog>().type();
        Destroy(gameObject);
    }
}
