using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
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
    public GameObject end;
    //public GameObject ship;
    SpriteRenderer sprite;
    int index=0;
    bool switched=false;
    // Start is called before the first frame update
    void Start()
    {
        //sprite = ship.GetComponent<SpriteRenderer>();
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<=2.2 && !switched)
            {
                switch(index)
                {
                    case 0:
                    snow.SetActive(false);
                    mount.SetActive(false);
                    rain.SetActive(true);
                    jung.SetActive(true);
                    switched=true;
                    index++;
                    break;
                    case 1:
                    rain.SetActive(false);
                    jung.SetActive(false);
                    desert.SetActive(true);
                    desertsun.SetActive(true);
                    desertsunny.SetActive(true);
                    sands.SetActive(true);
                    switched=true;
                    index++;
                    break;
                    case 2:
                    sands.SetActive(false);
                    desert.SetActive(false);
                    desertsun.SetActive(false);
                    desertsunny.SetActive(false);
                    city.SetActive(true);
                    switched=true;
                    index++;
                    break;
                    case 3:
                    city.SetActive(false);
                    space.SetActive(true);
                    stardust.SetActive(true);
                    switched=true;
                    index++;
                    break;
                    case 4:
                    //sprite.color = new Color32 (255, 165, 81, 255);
                    space.SetActive(false);
                    stardust.SetActive(false);
                    end.SetActive(true);
                    switched=true;
                    index++;
                    break;
                    case 5:
                    //sprite.color = new Color32 (255, 255, 255, 255);
                    end.SetActive(false);
                    snow.SetActive(true);
                    mount.SetActive(true);
                    switched=true;
                    index=0;
                    break;

                }
                
            }
        if(transform.position.x<-20)
        {
            transform.position=new Vector2(140, -1.9f);
            switched=false;
        } 
        transform.Translate(new Vector2(-18*Time.deltaTime,0));
    }
}
