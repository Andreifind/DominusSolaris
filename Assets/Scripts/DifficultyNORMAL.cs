using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyNORMAL : MonoBehaviour
{
    public GameObject textnr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        textnr.SetActive(true);
    }
    public void OnMouseExit()
    {
        textnr.SetActive(false);
    }
}
