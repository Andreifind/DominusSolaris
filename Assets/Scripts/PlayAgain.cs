using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerData data = SaveLoad.LoadPlayer();
        if ((Input.GetKeyDown(KeyCode.Space)))
            if(data.isdemo)
                SceneManager.LoadScene("Scena1Demo");
            else SceneManager.LoadScene("Scena1");
    }
}