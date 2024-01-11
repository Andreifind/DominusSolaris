using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textCRIT : MonoBehaviour
{
    public GameObject player;
    Text lass;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("ship");
        lass = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Ship>().crit==100)
            lass.text = "This skill will increase your critical hit chance. Current level: 0/2. Current critical hit chance: 0%";
        else if (player.GetComponent<Ship>().crit==90)
            lass.text = "This skill will increase your critical hit chance. Current level: 1/2. Current critical hit chance: 10%";
        else if (player.GetComponent<Ship>().crit==75)
            lass.text = "This skill will increase your critical hit chance. Current level: 2/2. Current critical hit chance: 25%";
    }
}
