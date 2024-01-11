using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class DamagePopup : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;   
    public static DamagePopup Create(Vector3 position, int damageAmount)
    {
       Transform damagePopupTransform = 
            Instantiate(GameAssets.i.pfDamagePopup
            , position, Quaternion.identity);
       DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
       damagePopup.Setup(damageAmount);
       return damagePopup;
    }
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private float _angle;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount)
    {
        player = GameObject.Find("ship").transform;
        textMesh.SetText(damageAmount.ToString());
        if (damageAmount==player.GetComponent<Ship>().damage*2)
        {
            
            textColor= new Color32(163, 16, 247, 255);
            textMesh.fontSize=11;
        }
        else 
        {
            textColor= new Color32( 255, 76, 0, 255);
            textMesh.fontSize=9;
        }
        disappearTimer=1f;
        textMesh.color = textColor;
        _angle = Random.Range(-180.0f, 180.0f);
    }

    private void Update()
    {
        //transform.eulerAngles = Mathf.Lerp(0, _angle, 3);
        if (player.GetComponent<Ship>().justloaded) Destroy(gameObject);
        float moveYSpeed = 1f;
        transform.position += new Vector3 (0,moveYSpeed)*Time.deltaTime;
        disappearTimer -=Time.deltaTime;
        if (disappearTimer <0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed*Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a<=0) Destroy(gameObject);
            textMesh.fontSize-=3*Time.deltaTime*2;
        }
        else
        {
            textMesh.fontSize+=Time.deltaTime*2;
        }
        
    }
}
