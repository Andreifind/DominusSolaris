using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Transform player;
    public GameObject deathmenu;
    public Transform spawner;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Ship>().hp<5)
        {
            deathmenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Reply()
    {
        Time.timeScale = 1f;
        deathmenu.SetActive(false);
        spawner.GetComponent<Spawner>().nr=0;
        player.GetComponent<Ship>().died=true;
        Debug.Log("reply reset");
    }
    public void Reset()
    {
        Time.timeScale = 0f;
        deathmenu.SetActive(false);
        spawner.GetComponent<Spawner>().nr=0;
        player.GetComponent<Ship>().died=true;
        Debug.Log("reset");
    }
}
