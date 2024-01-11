using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Animator _animator;
    private Ship _ship;
    private Color tmp;
    public bool disable=false;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _ship = _player.GetComponent<Ship>();
        tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        this.GetComponent<SpriteRenderer>().color = tmp;
    }

    void Update()
    {
        if (_ship.hasfired)
            _animator.SetTrigger("hasclicked");
        if (!disable && tmp.a < 0.99f) tmp.a += 0.005f;
        this.GetComponent<SpriteRenderer>().color = tmp;
        if (_ship.hasfired && disable)
        {
            tmp.a -= 0.005f;
            this.GetComponent<SpriteRenderer>().color = tmp;
        }
        if (tmp.a < 0.01f && disable) this.gameObject.SetActive(false);
    }
}
