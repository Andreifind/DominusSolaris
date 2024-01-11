using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TextCheated : MonoBehaviour
{
    public GameObject didwecheat;
    public bool cht;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        cht=data.cheated;
    }

    // Update is called once per frame
    void Update()
    {
        if(cht) didwecheat.SetActive(true);
        else didwecheat.SetActive(false);
    }
}
