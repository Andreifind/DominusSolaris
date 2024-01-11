using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUp : MonoBehaviour
{
    public static bool IsPaused = false;
    public bool _upgraded=false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenu;
    public GameObject tits;
    public int pm=0;
    public int um=0;
    public Transform player;
    public GameObject textlaser;
    public GameObject imglaser;
    public GameObject settingsmenu;
    public GameObject textlaserdamage;
    public GameObject textlaserspeed;
    public GameObject textlasercost;
    public GameObject textlasercrit;
    public GameObject textlaserpierce;
    public GameObject imglaserdamage;
    public GameObject imglaserspeed;
    public GameObject imglasercost;
    public GameObject imglasercrit;
    public GameObject imglaserpierce;
    public GameObject spawner;
    // Update is called once per frame
    void Start()
    {
        //player=GameObject.Find("ship").transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pm+um==0 && spawner.GetComponent<Spawner>().bossded==0 && player.GetComponent<Ship>().dialog==false) //daca ambele sunt inchise
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && pm==0 && player.GetComponent<Ship>().dialog==false) //daca meniul principal e inchis
            {
                pauseMenuUI.SetActive(false);
                settingsmenu.SetActive(false);
                pauseMenu.SetActive(true);
                LaserO();
                LaserCO();
                LaserDO();
                LaserPO();
                LaserSO();
                pm=1;
                um=0;
            }
        else if (Input.GetKeyDown(KeyCode.Escape) && pm==1) //daca meniul principal e deshis
             Resume();          
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        pm=0;
        Time.timeScale = 1f;
        IsPaused=false;
    }

    public void exit()
    {
        pauseMenu.SetActive(false);
        tits.SetActive(true);
        Time.timeScale = 0f;
        //tits.transform.GetComponent<Title>().isactive = true;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        pm=1;
        Time.timeScale = 0f;
        IsPaused=true;
    }
    public void Upgrade1()
    {
        pauseMenuUI.SetActive(true);
        pm=0;
        um=1;
        pauseMenu.SetActive(false);
    }
    public void Settingsup()
    {
        settingsmenu.SetActive(true);
        pm=0;
        um=1;
        //pauseMenu.SetActive(false);
    }
    public void Settingsdn()
    {
        settingsmenu.SetActive(false);
        pm=1;
        um=0;
        pauseMenu.SetActive(true);
    }
    public void Upgrade2()
    {
        pauseMenuUI.SetActive(false);
        pm=1;
        um=0;
        pauseMenu.SetActive(true);
    }
    // LASER 
    public void Laser()
    {
        textlaser.SetActive(true);
        imglaser.SetActive(true);
    }
    public void LaserO()
    {
        textlaser.SetActive(false);
        imglaser.SetActive(false);
    }
    //DAMAGE
    public void LaserD()
    {
        textlaserdamage.SetActive(true);
        imglaserdamage.SetActive(true);
    }
    public void LaserDO()
    {
        textlaserdamage.SetActive(false);
        imglaserdamage.SetActive(false);
    }
    //CRIT
    public void LaserC()
    {
        textlasercrit.SetActive(true);
        imglasercrit.SetActive(true);
    }
    public void LaserCO()
    {
        textlasercrit.SetActive(false);
        imglasercrit.SetActive(false);
    }
    ///COST
    public void LaserCt()
    {
        textlasercost.SetActive(true);
        imglasercost.SetActive(true);
    }
    public void LaserCtO()
    {
        textlasercost.SetActive(false);
        imglasercost.SetActive(false);
    }
    //SPEED
    public void Lasers()
    {
        textlaserspeed.SetActive(true);
        imglaserspeed.SetActive(true);
    }
    public void LaserSO()
    {
        textlaserspeed.SetActive(false);
        imglaserspeed.SetActive(false);
    }
    //PIERCE
    public void LaserP()
    {
        textlaserpierce.SetActive(true);
        imglaserpierce.SetActive(true);
    }
    public void LaserPO()
    {
        textlaserpierce.SetActive(false);
        imglaserpierce.SetActive(false);
    }
    public void UpDamage()
    {
        if (player.GetComponent<Ship>().points>0 && player.GetComponent<Ship>().damage<6)
        {
            player.GetComponent<Ship>().damage+=1;
            player.GetComponent<Ship>().points-=1;
            _upgraded = true;
        }
    }
    public void UpSpeed()
    {
        if (player.GetComponent<Ship>().points>0 && player.GetComponent<Ship>().speed<25)
        {
            player.GetComponent<Ship>().speed+=2;
            player.GetComponent<Ship>().points-=1;
            _upgraded = true;
        }
    }
    public void UpCrit()
    {
        if (player.GetComponent<Ship>().points>0 && player.GetComponent<Ship>().crit==100 && player.GetComponent<Ship>().damage>1)
        {
            player.GetComponent<Ship>().crit=90;
            player.GetComponent<Ship>().points-=1;
            _upgraded = true;
        }
        else if (player.GetComponent<Ship>().points>0 && player.GetComponent<Ship>().crit==90 && player.GetComponent<Ship>().damage>1)
        {
            player.GetComponent<Ship>().crit=75;
            player.GetComponent<Ship>().points-=1;
            _upgraded = true;
        }
    }
    public void UpCost()
    {
        if (player.GetComponent<Ship>().points>0 && player.GetComponent<Ship>().tax==10 && player.GetComponent<Ship>().speed>15)
        {
            player.GetComponent<Ship>().tax=8;
            player.GetComponent<Ship>().points-=1;
            _upgraded = true;
        }
        else if (player.GetComponent<Ship>().points>0 && player.GetComponent<Ship>().tax==8 && player.GetComponent<Ship>().speed>15)
        {
            player.GetComponent<Ship>().tax=5;
            player.GetComponent<Ship>().points-=1;
            _upgraded = true;
        }
    }
    public void UpPEN()
    {
        if (player.GetComponent<Ship>().points>0 && player.GetComponent<Ship>().tax<10 && player.GetComponent<Ship>().crit<100 && player.GetComponent<Ship>().pierce==0)
        {
            player.GetComponent<Ship>().pierce=1;
            player.GetComponent<Ship>().points-=1;
            _upgraded = true;
        }
    }
}
