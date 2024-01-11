using System.Collections;
using UnityEngine;
using TMPro;

public class StageDisplay : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public int Speed;
    public bool IsMoving = false;
    public Ship player;
    private float _resPos;
    private void Start()
    {
        _resPos = transform.position.x;
    }
    private void Update()
    {
        textDisplay.text = "STAGE " + player.planet + " - " + player.wave;
        Speed = ((int)(_resPos * Mathf.Abs(transform.position.x/4)) + 1);
        if (IsMoving) transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if (transform.position.x < -_resPos) Reset();
        //else Debug.Log(transform.position.x);
    }
    public void Move()
    {
        IsMoving = true;
    }
    public void Reset()
    {
        IsMoving = false;
        Debug.Log("reseted");
        transform.position = new Vector2(_resPos, transform.position.y);
    }
}
