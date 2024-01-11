using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyEZ : MonoBehaviour
{
    public GameObject textez;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        textez.SetActive(true);
    }
    public void OnMouseExit()
    {
        textez.SetActive(false);
    }
}
