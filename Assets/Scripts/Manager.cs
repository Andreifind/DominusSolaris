using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Manager : MonoBehaviour
{
    public Transform player;
    public Transform spawner;
    public GameObject rain;
    public GameObject snow;
    public GameObject mount;
    public GameObject jung;
    public GameObject desert;
    public GameObject desertsun;
    public GameObject desertsunny;
    public GameObject sands;
    public GameObject city;
    public GameObject space;
    public GameObject stardust;
    public GameObject overwarning;
    public GameObject end;
    private bool scenet;
    private int planet;
    int planet1;
    private int wave;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        planet = spawner.GetComponent<Spawner>().planet;
        planet1=planet;
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        scenet=player.GetComponent<Ship>().scenetrigger2;
        planet = spawner.GetComponent<Spawner>().planet;
        if (player.GetComponent<Ship>().loaded)
        {
            ChangeScene();
            player.GetComponent<Ship>().loaded=false;
        } 
        if (scenet==true)
        {
            animator.SetTrigger("fadein");
            //planet1=planet;
            player.GetComponent<Ship>().scenetrigger2=false;
        } 
        if (player.GetComponent<Ship>().over==1)
        {
            overwarning.SetActive(true);
        }
        if (player.GetComponent<Ship>().over==0)
        {
            overwarning.SetActive(false);
        }
    }
    public void ChangeScene()
    {
        if (planet==0)
        {
            disableall();
            snow.SetActive(true);
            mount.SetActive(true);

        }
        if (planet==1)
        {
            disableall();
            rain.SetActive(true);
            jung.SetActive(true);
        }
        if (planet==2)
        {
            disableall();
            sands.SetActive(true);
            desert.SetActive(true);
            desertsun.SetActive(true);
            desertsunny.SetActive(true);
        }
        if (planet==3)
        {
            disableall();
            city.SetActive(true);
        }
        if (planet==4)
        {
            disableall();
            space.SetActive(true);
            stardust.SetActive(true);
        }
        if (planet==5)
        {
            disableall();
            end.SetActive(true);
        }
        if (planet==6)
        {
            disableall();
        }
        System.Threading.Thread.Sleep(500);
        player.GetComponent<Ship>().scenetrigger3=true;
    }
    void disableall()
    {
         rain.SetActive(false);
         sands.SetActive(false);
         snow.SetActive(false);
         mount.SetActive(false);
         jung.SetActive(false);
         desert.SetActive(false);
         space.SetActive(false);
         stardust.SetActive(false);
         desertsun.SetActive(false);
         desertsunny.SetActive(false);
         city.SetActive(false);
         end.SetActive(false);
    }
}
