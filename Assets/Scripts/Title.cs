using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    public bool isactive = true;
    public GameObject cont;
    public GameObject sett;
    public bool istutorial=true;
    GameObject player;
    // Start is called before the first frame update
    public GameObject Titlu;
    void Start()
    {
        Time.timeScale = 0f;
        isactive = true;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isactive==true && Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Game has quit");
            Application.Quit();
        } 
        if (player.GetComponent<Ship>().cancontinue==true && istutorial==false)
        cont.SetActive(true);
        else cont.SetActive(false);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        Titlu.SetActive(false);
        isactive = false;
    }

    public void Options()
    {
        sett.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game has quit");
    }
    public void LoadContinue()
    {
        SceneManager.LoadScene("Scena1");
    }

}
