using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialControls : MonoBehaviour
{
    [SerializeField] private GameObject _mouse;
    [SerializeField] private GameObject _keyboard;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _spawner;
    [SerializeField] private GameObject _upgrader;
    [SerializeField] private GameObject _text;
    private Ship _ship;
    private bool step1=false;
    private bool step2 = false;
    private bool step3 = false;
    void Start()
    {
        _ship = _player.GetComponent<Ship>();
    }

    void Update()
    {
        if((_ship.hasmoved == true) && (step1 == false))
        {
            step1=true;
            StartCoroutine(MouseStart());
        }
        if(_ship.hasfired == true && step1==false)
        {
            step1=true;
            StartCoroutine(Mouse1());
        }
        if ((_ship.usedpower == true) && (step2 == false))
        {
            step2 = true;
            StartCoroutine(Mouse2());
        }
        if(_upgrader.gameObject.GetComponent<PauseUp>()._upgraded == true && (step3==false))
        {
            step3 = true;
            StartCoroutine(TextBegone());
        }

    }
    private IEnumerator MouseStart()
    {
        _keyboard.GetComponent<WASD>().begone=true;
        yield return new WaitForSeconds(1);
        _mouse.SetActive(true);
        _ship.canfire = true;
    }
    private IEnumerator Mouse1()
    {
        yield return new WaitForSeconds(1);
        _ship.lasers = 1;
    }
    private IEnumerator Mouse2()
    {
        _mouse.GetComponent<MouseClick>().disable = true;
        yield return new WaitForSeconds(2); 
        _text.SetActive(true);
        _ship.points = 1;
    }
    private IEnumerator TextBegone()
    {
        _text.SetActive(false);
        yield return new WaitForSeconds(1);
        _spawner.GetComponent<Spawner>().wave = 3;
        _ship.wave = 3;
        _spawner.GetComponent<Spawner>().bossded = 1;
    }
}
