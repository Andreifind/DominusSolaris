using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    public GameObject player;
    void Start()
    {
        StartCoroutine(Type());
    }
    void Update()
    {
        //if (textDisplay.text==null) type();
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void inc()
    {
        index+=1;
        Debug.Log("inc index");
        textDisplay.text=null;
        player.GetComponent<Ship>().index=index;
    }
    public void type()
    {
        StartCoroutine(Type());
    }
    public void reset()
    {
        textDisplay.text=null;
    }
    // Update is called once per frame
}
