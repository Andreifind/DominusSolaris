using System;
using System.Collections;
using UnityEngine;

public class WASD : MonoBehaviour
{
    [SerializeField] private GameObject _mouse;
    [SerializeField] private GameObject _player;
    [SerializeField] private float speed;
    private Color tmp;
    public bool begone = false;
    void Start()
    {
        tmp = this.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
            tmp.a = Math.Abs(Mathf.Sin(Time.time * speed));
            this.GetComponent<SpriteRenderer>().color = tmp;
            if (begone && tmp.a < 0.01f) this.gameObject.SetActive(false);

    }
}
