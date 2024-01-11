using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Comp : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public GameObject dialu;
    public bool ison=false;
    // Start is called before the first frame update
    void Start()
    {
        //player.GetComponent<Ship>().dialog=true;
        //Instantiate(canvas,lpos,Quaternion.identity);
    }
    void Update()
    {
        if (player.GetComponent<Ship>().hp<600) turnoff();
            //turnon();
            if(Input.GetKeyDown(KeyCode.Return) && ison)
            {
                turnoff();
                dialu.GetComponent<Dialog>().inc();
            }
             
    }
    // Update is called once per frame
    public void turnoff()
    {
        player.GetComponent<Ship>().dialog=false;
        canvas.SetActive(false);
        Debug.Log("buton apasat");
        ison=false;
    }
    public void turnon()
    {
        
        //
        ison=true;
        player.GetComponent<Ship>().dialog=true;
        canvas.SetActive(true);
        Debug.Log("buton2 apasat");
    }
}
