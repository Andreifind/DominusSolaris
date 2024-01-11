using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ship : MonoBehaviour
{
    Animation anim;
    [SerializeField] private StageDisplay _stageDisp;
    private Rigidbody2D body = null;
    private Vector2 targetPos;
    private Vector2 lpos;
    private Vector2 laspos;
    private Transform spawner;
    public float movedist = 0.5f;
    public GameObject laser;
    public GameObject explo;
    public GameObject lazer;
    public GameObject shield;
    public int hp = 600;
    public float energy = 100.0f;
    public int shieldsdown = 1;
    public Energybar nrgbar;
    public int lasers = 0;
    public int shields = 0;
    public int laserdown = 1;
    public CameraShake cam;
    public float vel = 3f;
    public float overheat = 100;
    public int over = 0;
    public int tax;
    public int exp = 0;
    public int exp1 = 0;
    public int points = 0;
    public int targetexp = 10;
    public int level = 0;
    public int speed = 15;
    public int damage = 1;
    public int roketdmg = 10;
    public int laserdamage = 15;
    public GameObject raketa;
    public int rokets = 0;
    public int roketdown = 1;
    private float rtime = 0f;
    public int crit = 100;
    public int pierce = 0;
    public int wave = 0;
    public int planet = 0;
    public GameObject spark;
    private int wavev;
    Animator animator;
    public bool lass = false;
    public bool justloaded = true;
    public bool loaded = true;
    private bool skr = false;
    public bool marebos = false;
    public bool passby = false;
    public bool laseron = false;
    public bool scenetrigger = false;
    public bool scenetrigger2 = false;
    public bool scenetrigger3 = false;
    public Transform dialogue;
    public int killscore = 0;
    public bool dialog = false;
    public bool dialtrig = false;
    public int[,] route = new int[3, 10];
    public float spid;
    public bool scenechange = false;
    public bool pickup = false;
    public int index = 0;
    public bool ch;
    private string[] cheatCode;
    int ind = 0;
    public int deaths = 0;
    //public GameObject dial;
    private Vector2 respos;
    int drop;
    public bool died = false;
    public int somekills = 0;
    public int score = 0;
    public int shotsfired = 0;
    public int hitted = 0;
    int somefired;
    int somehit;
    public bool cancontinue=false;
    public int experience = 0;
    public float taxred;
    public bool cheated = false;
    public bool isdemo;
    public int highscore = 0;
    //tutorial
    public bool hasfired;
    public bool canfire;
    public bool usedpower;
    public bool hasmoved;
    // Start is called before the first frame update
    SpriteRenderer sprite;
    void Start()
    {
        _stageDisp.IsMoving = true;
        hp = 600;
        body = this.GetComponent<Rigidbody2D>();
        spawner = GameObject.FindWithTag("spawner").transform;
        //if (wave==0 && planet==0) SaveLoad.SavePlayer(this);
        wavev = wave;
        animator = GetComponent<Animator>();
        loaded = true;
        sprite = GetComponent<SpriteRenderer>();
        cheatCode = new string[] { "c", "h", "e", "a", "t" };
        sprite.color = new Color32(255, 255, 255, 255);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        spawner.GetComponent<Spawner>().nr = 0;
        //
        planet = data.planet;
        if ((planet < 6 && data.isdemo == false) || (planet < 2 && data.isdemo == true))
        {
            wave = data.wave;
            planet = data.planet;
            level = data.level;
            points = data.points;
            energy = data.energy;
            shieldsdown = data.shieldsdown;
            lasers = data.lasers;
            shields = data.shields;
            laserdown = data.laserdown;
            overheat = data.overheat;
            over = data.over;
            tax = data.tax;
            exp = data.exp;
            exp1 = data.exp1;
            targetexp = data.targetexp;
            speed = data.speed;
            damage = data.damage;
            roketdmg = data.roketdmg;
            laserdamage = data.laserdamage;
            rokets = data.rokets;
            roketdown = data.roketdown;
            crit = data.crit;
            pierce = data.pierce;
            killscore = data.killscore;
            deaths = data.deaths;
            index = data.index;
            shotsfired = data.shotsfired;
            dialogue.GetComponent<Dialog>().index = index;
            hp = data.hp;
            if (hp < 600) hp = 600;
            spawner.GetComponent<Spawner>().nr = 0;
            spawner.GetComponent<Spawner>().wave = wave;
            spawner.GetComponent<Spawner>().planet = planet;
            animator.ResetTrigger("isded");
            animator.ResetTrigger("isfire");
            animator.ResetTrigger("startbeam");
            animator.ResetTrigger("endbeam");
            animator.SetTrigger("restarted");
            animator.Play("Shipidle");
            justloaded = true;
            loaded = true;
            if (somekills > 2 && killscore < somekills)
                killscore = somekills - 1;
            else killscore = data.killscore;
            score = data.score;
            if (data.shotsfired == 0) shotsfired = somefired;
            else shotsfired = data.shotsfired;
            if (data.hitted == 0) hitted = somehit;
            else hitted = data.hitted;
            taxred = data.taxred;
            cheated = data.cheated;
            isdemo = data.isdemo;
        }
        else
        {
            LoadNEW();
        }

        SaveLoad.SavePlayer(this);
        //skr=true;
        cancontinue = true;
        canfire = true;
    }

    public void LoadNEW()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        level = 0;
        points = 0;
        energy = 100;
        killscore = 0;
        shieldsdown = 1;
        lasers = 0;
        shields = 0;
        rokets = 0;
        laserdown = 1;
        overheat = 100;
        over = 0;
        tax = 10;
        exp = 0;
        exp1 = 0;
        targetexp = 75;
        speed = 15;
        damage = 1;
        roketdmg = 10;
        laserdamage = 15;
        roketdown = 1;
        crit = 100;
        pierce = 0;
        ///
        wave = 0;
        planet = 0;
        spawner.GetComponent<Spawner>().nr = 0;
        spawner.GetComponent<Spawner>().wave = 0;
        spawner.GetComponent<Spawner>().planet = 0;
        ///
        hp = 600;
        animator.ResetTrigger("isded");
        animator.ResetTrigger("isfire");
        animator.ResetTrigger("startbeam");
        animator.ResetTrigger("endbeam");
        animator.SetTrigger("restarted");
        animator.Play("Shipidle");
        SaveLoad.SavePlayer(this);
        justloaded = true;
        loaded = true;
        skr = true;
        index = 0;
        deaths = 0;
        score = 0;
        shotsfired = 0;
        hitted = 0;
        cancontinue = true;
        taxred = 0.9f;
        cheated = false;
        isdemo = false;
        highscore = data.highscore;
        canfire = true;
    }
    public void LoadEZ()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        level = 0;
        points = 0;
        energy = 100;
        killscore = 0;
        shieldsdown = 1;
        lasers = 0;
        shields = 0;
        rokets = 0;
        laserdown = 1;
        overheat = 100;
        over = 0;
        tax = 10;
        exp = 0;
        exp1 = 0;
        targetexp = 40;
        speed = 15;
        damage = 1;
        roketdmg = 10;
        laserdamage = 15;
        roketdown = 1;
        crit = 100;
        pierce = 0;
        ///
        wave = 0;
        planet = 0;
        spawner.GetComponent<Spawner>().nr = 0;
        spawner.GetComponent<Spawner>().wave = 0;
        spawner.GetComponent<Spawner>().planet = 0;
        ///
        hp = 600;
        animator.ResetTrigger("isded");
        animator.ResetTrigger("isfire");
        animator.ResetTrigger("startbeam");
        animator.ResetTrigger("endbeam");
        animator.SetTrigger("restarted");
        animator.Play("Shipidle");
        justloaded = true;
        loaded = true;
        skr = true;
        index = 0;
        deaths = 0;
        score = 0;
        shotsfired = 0;
        hitted = 0;
        cancontinue = true;
        taxred = 0.6f;
        cheated = false;
        isdemo = false;
        highscore = data.highscore;
        canfire = true;
        SaveLoad.SavePlayer(this);
    }
    public void LoadHard()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        level = 0;
        points = 0;
        energy = 100;
        killscore = 0;
        shieldsdown = 1;
        lasers = 0;
        shields = 0;
        rokets = 0;
        laserdown = 1;
        overheat = 100;
        over = 0;
        tax = 10;
        exp = 0;
        exp1 = 0;
        targetexp = 90;
        speed = 15;
        damage = 1;
        roketdmg = 10;
        laserdamage = 15;
        roketdown = 1;
        crit = 100;
        pierce = 0;
        ///
        wave = 0;
        planet = 0;
        spawner.GetComponent<Spawner>().nr = 0;
        spawner.GetComponent<Spawner>().wave = 0;
        spawner.GetComponent<Spawner>().planet = 0;
        ///
        hp = 600;
        animator.ResetTrigger("isded");
        animator.ResetTrigger("isfire");
        animator.ResetTrigger("startbeam");
        animator.ResetTrigger("endbeam");
        animator.SetTrigger("restarted");
        animator.Play("Shipidle");
        justloaded = true;
        loaded = true;
        skr = true;
        index = 0;
        deaths = 0;
        score = 0;
        shotsfired = 0;
        hitted = 0;
        cancontinue = true;
        taxred = 1.1f;
        cheated = false;
        isdemo = false;
        highscore = data.highscore;
        canfire = true;
        SaveLoad.SavePlayer(this);
    }
    public void demodemo()
    {
        isdemo = true;
    }
    public void LoadNormalDemo()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        level = 0;
        points = 0;
        energy = 100;
        killscore = 0;
        shieldsdown = 1;
        lasers = 0;
        shields = 0;
        rokets = 0;
        laserdown = 1;
        overheat = 100;
        over = 0;
        tax = 10;
        exp = 0;
        exp1 = 0;
        targetexp = 75;
        speed = 15;
        damage = 1;
        roketdmg = 10;
        laserdamage = 15;
        roketdown = 1;
        crit = 100;
        pierce = 0;
        ///
        wave = 0;
        planet = 0;
        spawner.GetComponent<Spawner>().nr = 0;
        spawner.GetComponent<Spawner>().wave = 0;
        spawner.GetComponent<Spawner>().planet = 0;
        ///
        hp = 600;
        animator.ResetTrigger("isded");
        animator.ResetTrigger("isfire");
        animator.ResetTrigger("startbeam");
        animator.ResetTrigger("endbeam");
        animator.SetTrigger("restarted");
        animator.Play("Shipidle");
        justloaded = true;
        loaded = true;
        skr = true;
        index = 0;
        deaths = 0;
        score = 0;
        shotsfired = 0;
        hitted = 0;
        cancontinue = true;
        taxred = 0.9f;
        cheated = false;
        isdemo = true;
        highscore = data.highscore;
        SaveLoad.SavePlayer(this);
    }
    public void LoadHardDemo()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        level = 0;
        points = 0;
        energy = 100;
        killscore = 0;
        shieldsdown = 1;
        lasers = 0;
        shields = 0;
        rokets = 0;
        laserdown = 1;
        overheat = 100;
        over = 0;
        tax = 10;
        exp = 0;
        exp1 = 0;
        targetexp = 90;
        speed = 15;
        damage = 1;
        roketdmg = 10;
        laserdamage = 15;
        roketdown = 1;
        crit = 100;
        pierce = 0;
        ///
        wave = 0;
        planet = 0;
        spawner.GetComponent<Spawner>().nr = 0;
        spawner.GetComponent<Spawner>().wave = 0;
        spawner.GetComponent<Spawner>().planet = 0;
        ///
        hp = 600;
        animator.ResetTrigger("isded");
        animator.ResetTrigger("isfire");
        animator.ResetTrigger("startbeam");
        animator.ResetTrigger("endbeam");
        animator.SetTrigger("restarted");
        animator.Play("Shipidle");
        justloaded = true;
        loaded = true;
        skr = true;
        index = 0;
        deaths = 0;
        score = 0;
        shotsfired = 0;
        hitted = 0;
        cancontinue = true;
        taxred = 1.1f;
        cheated = false;
        isdemo = true;
        highscore = data.highscore;
        SaveLoad.SavePlayer(this);
    }
    public void LoadEZDemo()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        level = 0;
        points = 0;
        energy = 100;
        killscore = 0;
        shieldsdown = 1;
        lasers = 0;
        shields = 0;
        rokets = 0;
        laserdown = 1;
        overheat = 100;
        over = 0;
        tax = 10;
        exp = 0;
        exp1 = 0;
        targetexp = 40;
        speed = 15;
        damage = 1;
        roketdmg = 10;
        laserdamage = 15;
        roketdown = 1;
        crit = 100;
        pierce = 0;
        ///
        wave = 0;
        planet = 0;
        spawner.GetComponent<Spawner>().nr = 0;
        spawner.GetComponent<Spawner>().wave = 0;
        spawner.GetComponent<Spawner>().planet = 0;
        ///
        hp = 600;
        animator.ResetTrigger("isded");
        animator.ResetTrigger("isfire");
        animator.ResetTrigger("startbeam");
        animator.ResetTrigger("endbeam");
        animator.SetTrigger("restarted");
        animator.Play("Shipidle");
        justloaded = true;
        loaded = true;
        skr = true;
        index = 0;
        deaths = 0;
        score = 0;
        shotsfired = 0;
        hitted = 0;
        cancontinue = true;
        taxred = 0.6f;
        cheated = false;
        isdemo = true;
        highscore = data.highscore;
        SaveLoad.SavePlayer(this);
    }

    public void LoadTUTORIAL()
    {
        //PlayerData data = SaveLoad.LoadPlayer();
        level = 0;
        points = 0;
        energy = 100;
        killscore = 0;
        shieldsdown = 1;
        lasers = 0;
        shields = 0;
        rokets = 0;
        laserdown = 1;
        overheat = 100;
        over = 0;
        tax = 10;
        exp = 0;
        exp1 = 0;
        targetexp = 10;
        speed = 15;
        damage = 1;
        roketdmg = 10;
        laserdamage = 15;
        roketdown = 1;
        crit = 100;
        pierce = 0;
        wave = 1;
        planet = 8;
        hp = 600;
        deaths = 0;
        animator.ResetTrigger("isded");
        animator.ResetTrigger("isfire");
        animator.ResetTrigger("startbeam");
        animator.ResetTrigger("endbeam");
        animator.SetTrigger("restarted");
        animator.Play("Shipidle");
        //SaveLoad.SavePlayer(this);
        justloaded = true;
        loaded = true;
        //skr=true;
        index = 0;
        spawner.GetComponent<Spawner>().nr = 0;
        spawner.GetComponent<Spawner>().wave = wave;
        spawner.GetComponent<Spawner>().planet = planet;
        Debug.Log("tutorial");
        cancontinue = false;
        isdemo = false;
        hasfired = false;
        usedpower = false;
        canfire = false;
        hasmoved = false;
    }
    public void skiptutorialdemo()
    {
        SceneManager.LoadScene("Scena1Demo");
    }
    public void LoadTUTORIALDemo()
    {
        //PlayerData data = SaveLoad.LoadPlayer();
        level = 0;
        points = 0;
        energy = 100;
        killscore = 0;
        shieldsdown = 1;
        lasers = 0;
        shields = 0;
        rokets = 0;
        laserdown = 1;
        overheat = 100;
        over = 0;
        tax = 10;
        exp = 0;
        exp1 = 0;
        targetexp = 10;
        speed = 15;
        damage = 1;
        roketdmg = 10;
        laserdamage = 15;
        roketdown = 1;
        crit = 100;
        pierce = 0;
        wave = 1;
        planet = 8;
        hp = 600;
        deaths = 0;
        animator.ResetTrigger("isded");
        animator.ResetTrigger("isfire");
        animator.ResetTrigger("startbeam");
        animator.ResetTrigger("endbeam");
        animator.SetTrigger("restarted");
        animator.Play("Shipidle");
        //SaveLoad.SavePlayer(this);
        justloaded = true;
        loaded = true;
        //skr=true;
        index = 0;
        spawner.GetComponent<Spawner>().nr = 0;
        spawner.GetComponent<Spawner>().wave = wave;
        spawner.GetComponent<Spawner>().planet = planet;
        Debug.Log("tutorial");
        cancontinue = false;
        isdemo = true;
    }
    //admin tools
    public void cheatAddPoints()
    {
        points++;
    }
    public void cheatSkipStage()
    {
            if (planet != 4)
            {
                spawner.GetComponent<Spawner>().wave = 3;
                wave = 3;
            }
            else
            {
                spawner.GetComponent<Spawner>().wave = 2;
                wave = 2;
            }
            spawner.GetComponent<Spawner>().bossded = 1;
        if (planet == 0)
            dialogue.GetComponent<Dialog>().index = 2;
        if (planet == 1)
            dialogue.GetComponent<Dialog>().index = 4;
        if (planet == 2)
            dialogue.GetComponent<Dialog>().index = 6;
        if (planet == 3)
            dialogue.GetComponent<Dialog>().index = 8;
        if (planet == 5)
            dialogue.GetComponent<Dialog>().index = 10;
    }
    public void cheatBecomeImmortal()
    {
        hp = 99999;
    }
    public void cheatGoToBoss()
    {
        if (planet != 4)
        {
            spawner.GetComponent<Spawner>().wave = 3;
            wave = 3;
        }
        else
        {
            spawner.GetComponent<Spawner>().wave = 2;
            wave = 2;
        }
        spawner.GetComponent<Spawner>().nr = 0;
    }
    public void cheatGetRandomPowerup()
    {
        int powerupindex;
        powerupindex = Random.Range(0, 3);
        if (powerupindex == 0)
        {
            rokets = 3;
            lasers = 0;
            shields = 0;
        }
        if (powerupindex == 1)
        {
            rokets = 0;
            lasers = 1;
            shields = 0;
        }
        if (powerupindex == 2)
        {
            rokets = 0;
            lasers = 0;
            shields = 1;
        }
        energy = 100;
    }
    public void justdie()
    {
        if (!justloaded)
            hp = 4;
        //animator.Play("Shipidle");
        animator.ResetTrigger("isded");
        animator.SetTrigger("restarted");
        //anim = GetComponent<Animation>();
        //anim.Stop();
        deaths++;
        //SaveLoad.SaveDeaths(this);

    }
    public void kilal()
    {
        justloaded = true;
    }
    public void pewpew()
    {
        animator.ResetTrigger("isfire");
        //lpos= new Vector2(transform.position.x+0.42f, transform.position.y-0.52f);
        Instantiate(laser, lpos, Quaternion.identity);
        Instantiate(spark, lpos, Quaternion.identity);
        Sounds.PlaySound("pew");
        if (overheat - tax * taxred < 0) overheat = 0;
        else
            overheat -= tax * taxred;
    }
    public void bigbeam()
    {
        laseron = true;
        lazer.SetActive(true);
        Debug.Log("merge");
        StartCoroutine(cam.Shake(2.15f, .07f));
        laserdown = 0;
        lasers -= 1;
        Sounds.PlaySound("biglaser");
    }
    void Update()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        if(data != null)
            if(data.planet < 6) cancontinue = true;
        //if (data == null)
        //{
        //    cancontinue = false;
        //    SaveLoad.SavePlayer(this);
        //}
        //else cancontinue = false;
        somekills = killscore;
        somefired = shotsfired;
        somehit = hitted;
        //deathscore
        if (dialog)
        {
            if (hp < 600 && data != null) hp = data.hp;
            animator.SetTrigger("restarted");
            animator.Play("Shipidle");
        }
        if (died)
        {
            deaths++;
            died = false;
        }
        //cheatcode
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[ind]))
            {
                ind++;
            }
            else
            {
                ind = 0;
            }
            if (ind == cheatCode.Length)
            {
                ind = 0;
                Debug.Log("cheat activated!");
                hp = 99999;
                damage = 15;
                speed = 50;
                tax = 0;
                pierce = 1;
                crit = 30;
                cheated = true;
            }
        }
        ////
        ///
        if (overheat < 0) overheat = 0;
        if (overheat > 100) overheat = 100;
        //if(dialog) dial.SetActive(true);
        lpos = new Vector2(transform.position.x + 0.42f, transform.position.y - 0.52f);
        //GOD MODE
        if (marebos)
        {
            StartCoroutine(cam.Shake(1f, .07f));
            if (taxred == 1.1f) score += 80000 / (deaths + 1);
            if (taxred == 0.9f) score += 60000 / (deaths + 1);
            if (taxred == 0.6f) score += 40000 / (deaths + 1);
            marebos = false;
        }
        if (passby)
        {
            StartCoroutine(cam.Shake(1f, .07f));
            passby = false;
        }
        if (pickup)
        {
            if (planet != 8)
                drop = Random.Range(0, 3);
            else drop = 1;
            if (drop == 0)
            {
                rokets = 3;
                lasers = 0;
                shields = 0;
            }
            if (drop == 1)
            {
                lasers = 1;
                rokets = 0;
                shields = 0;
            }
            if (drop >= 2)
            {
                shields = 1;
                rokets = 0;
                lasers = 0;
            }
            pickup = false;
        }
        //cheats
        /*
		if ((Input.GetKeyDown(KeyCode.G)))
		{
			hp=9000;
			points=200;
			//damage=50;
			//speed=50;
			energy=100;
			rokets=50;
			lasers=50;
			shields=50;
		}
		if ((Input.GetKeyDown(KeyCode.L)))
		{
			hp=599;
		}
		if ((Input.GetKeyDown(KeyCode.Z)))
		{
			if(planet!=4)
			{
				spawner.GetComponent<Spawner>().wave=3;
				wave=3;
			}
			else
			{
				spawner.GetComponent<Spawner>().wave=2;
				wave=2;
			}
			spawner.GetComponent<Spawner>().bossded=1;
		}
		if ((Input.GetKeyDown(KeyCode.X)))
		{
			if(planet!=4)
			{
				spawner.GetComponent<Spawner>().wave=3;
				wave=3;
			}
			else
			{
				spawner.GetComponent<Spawner>().wave=2;
				wave=2;
			}
			spawner.GetComponent<Spawner>().nr=0;
			//spawner.GetComponent<Spawner>().bossded=1;
		}
		if ((Input.GetKeyDown(KeyCode.C)))
		{
			points++;
		}
		if ((Input.GetKeyDown(KeyCode.V)))
		{
			drop=Random.Range(0,3);
			if(drop==0)
			{
				rokets=3;
				lasers=0;
				shields=0;
			} 
			if (drop==1)
			{
				lasers=1;
				rokets=0;
				shields=0;
			} 
			if (drop>=2)
			{
				shields=1;
				rokets=0;
				lasers=0;
			} 
		}
		if ((Input.GetKeyDown(KeyCode.H)))
		{
			hp=9000;
			points=200;
			damage+=18;
			speed=30;
			rokets=50;
			lasers=50;
			shields=50;
			energy=1000;
			pierce=1;
			crit=5;
			tax=0;
		}
		if ((Input.GetKeyDown(KeyCode.J)))
		{
			wave=-1;
			spawner.GetComponent<Spawner>().wave=-1;
		}
		*/
        if (skr)
        {
            spawner.GetComponent<Spawner>().nr = 0;
            spawner.GetComponent<Spawner>().wave = 0;
            spawner.GetComponent<Spawner>().planet = 0;
            skr = false;
        }
        if (lass)
        {
            laseron = false;
            animator.SetTrigger("endbeam");
            lass = false;
            lazer.SetActive(false);
        }
        if (exp != experience)
        {
            if (exp - experience > 15 && justloaded == false) exp = experience + 15;
            //else if (justloaded)
            experience = exp;
        }
        if (score > highscore)
        {
            highscore = score;
            if(data != null)
                data.highscore = score;
        }
        if (exp >= targetexp)
        {
            //Debug.Log(exp);
            points += 1;
            level += 1;
            exp -= targetexp;
            if (taxred == 0.6f) targetexp += 30;
            if (taxred == 0.9f) targetexp += 50;
            if (taxred == 1.1f) targetexp += 65;
            //targetexp*=level;
        }
        if (wave != wavev && planet < 8)
        {
            wavev = wave;
            SaveLoad.SavePlayer(this);
            Debug.Log("game saved..");
            Debug.Log(planet);
        }
        if (exp != exp1 && laseron == false)
        {
            StartCoroutine(cam.Shake(.15f, .07f));
            exp1 = exp;
            killscore++;
        }
        //laser pew pew
        if(canfire)
        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0)) && overheat >= 0 && over == 0 && Time.timeScale > 0 && (dialog == false) && hp >= 600)
        {
            animator.SetTrigger("isfire");
            Debug.Log(shotsfired);
            Debug.Log(hitted);
            shotsfired++;
                if (usedpower == false && planet == 8)
                {
                    lasers = 1;
                    hasfired = true;
                }
        }
        if (overheat == 0)
        {
            if (over == 0) Sounds.PlaySound("cooldown");
            over = 1;
        }
        if (hp < 600 && dialog == false)
        {
            animator.SetTrigger("isded");
        }

        //scut 
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)) && energy >= 100f && shields >= 1 && Time.timeScale > 0 && (dialog == false))
        {
            lpos = new Vector2(transform.position.x + 0.42f, 0);
            Instantiate(shield, lpos, Quaternion.identity);
            shieldsdown = 0;
            shields -= 1;
            Sounds.PlaySound("shield");
        }

        if (laserdown == 1 && energy < 100f && Time.timeScale > 0 && dialog == false)
        {
            if (energy < 99) energy += 2 * Time.deltaTime;//0.01f;
            else
            {
                energy = 100;
                Sounds.PlaySound("cdup");
            }
        }
        if (energy >= 100) roketdown = 1;
        // mare laser 
        laspos = new Vector2(transform.position.x + 12f, transform.position.y - 0.12f);
        if (((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)) && ((energy < 98f && rokets == 0) || laserdown == 0 || (lasers == 0 && shields == 0 && rokets == 0)) && Time.timeScale > 0))
            Sounds.PlaySound("unavailable");
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)) && energy >= 100f && laserdown == 1 && lasers >= 1 && Time.timeScale > 0 && (dialog == false))
        {
            animator.SetTrigger("startbeam");
            usedpower = true;
        }
        if (overheat < 100 && Time.timeScale > 0 && (dialog == false))
        {
            overheat += 9 * Time.deltaTime;
            if (over == 1) overheat += 21 * Time.deltaTime;
            //overheat+=0;
        }
        else if (over == 1 && Time.timeScale > 0)
        {
            over = 0;
            Sounds.PlaySound("cdup");
        }

        //raketa

        //if (((Input.GetKeyDown(KeyCode.X)) && (energy<=0 || rokets==0 || roketdown ==0) ))
        //Sounds.PlaySound ("unavailable");
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)) && energy > 0f && rokets >= 1 && Time.timeScale > 0 && roketdown == 1 && (dialog == false))
        {
            Instantiate(raketa, lpos, Quaternion.identity);
            //roketdown=0;
            rokets -= 1;
            Sounds.PlaySound("roket");
            if (energy - 34 > 0)
                energy -= 34;
            else
                energy = 0;

            if (energy <= 0)
            {
                roketdown = 0;
            }

        }

        if (justloaded)
        {
            StartCoroutine(Wait());

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("enemy"))
            other.GetComponent<Enemy>().hp -= 30;
        if (other.gameObject.tag == ("Projectile") || other.gameObject.tag == ("enemy"))
        {
            hp -= 1;
        }
    }
    public void kabum()
    {
        if (!justloaded)
        {
            Sounds.PlaySound("bigboom");
            Instantiate(explo, transform.position, Quaternion.identity);
            exp += 1;
        }
        else animator.Play("Shipidle");
    }
    IEnumerator Wait()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        spawner.GetComponent<Spawner>().nr = 0;
        animator.Play("Shipidle");
        if(data != null)
            hp = data.hp;
        animator.ResetTrigger("isded");
        yield return new WaitForSeconds(1);
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        justloaded = false;

    }

    IEnumerator WaitForStageDisplay()
    {
        yield return new WaitForSeconds(1);
        _stageDisp.IsMoving = true;
    }

    public void skiptutorial()
    {
        if(isdemo == false)
            SceneManager.LoadScene("Scena1");
        else
            SceneManager.LoadScene("Scena1Demo");
    }
    void FixedUpdate()
    {
        if (dialog == true) body.velocity = new Vector2(0, 0);
        if (Time.timeScale > 0 && (dialog == false))
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && transform.position.y < 3.3f)
            {
                if (dialog == false) transform.Translate(new Vector3(0f, Time.deltaTime * vel * 1.5f));
                canfire = true;
                hasmoved = true;
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && transform.position.y > -3.5f)
            {
                if (dialog == false) transform.Translate(new Vector3(0f, Time.deltaTime * vel * -1.5f));
                canfire = true;
                hasmoved = true;
            }
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < -2)
            {
                if (dialog == false && scenechange == false) if (dialog == false) transform.Translate(new Vector3(Time.deltaTime * vel * 1.5f, 0f));
                canfire = true;
                hasmoved = true;
            }
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > -8)
            {
                if (dialog == false && scenechange == false) transform.Translate(new Vector3(Time.deltaTime * vel * -1.5f, 0f));
                canfire = true;
                hasmoved = true;
            }
            //else
            //body.velocity = new Vector2 (0,0);
        }


        if (scenetrigger && transform.position.x < 17)
        {
            if (planet < 8)
                SaveLoad.SavePlayer(this);
            if (scenechange == false)
                spid += .03f;
            if (scenechange == false && spid > 4.5f)
            {
                spid = 1.2f;
                scenechange = true;
            }
            if (scenechange)
            {
                body.velocity = UnityEngine.Vector2.right * vel * 2.5f * spid;
                spid += .04f;
            }
        }
        if (scenetrigger && transform.position.x > 17)
        {
            body.velocity = UnityEngine.Vector2.right * vel * 0;
            spid = 0;
            scenetrigger = false;
            scenetrigger2 = true;
            if (planet >= 8 && isdemo == false) SceneManager.LoadScene("Scena1");
            if (planet >= 8 && isdemo == true) SceneManager.LoadScene("Scena1Demo");
            if (planet == 6 || (planet == 2 && isdemo == true))
            {
                cancontinue = false;
                Debug.Log("cancontinue");
                SaveLoad.SavePlayer(this);
                SceneManager.LoadScene("EndScene");
            }
        }
        if (scenetrigger3)
        {
            scenetrigger2 = false;
            respos = new Vector2(-8f, transform.position.y);
            transform.position = respos;
            StartCoroutine(WaitForStageDisplay());
            scenetrigger3 = false;
            scenechange = false;
            if (planet < 8)
                SaveLoad.SavePlayer(this);
            Debug.Log("game saved");
            Debug.Log(planet);
        }
    }
}
