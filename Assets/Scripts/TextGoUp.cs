using UnityEngine;
using UnityEngine.SceneManagement;

public class TextGoUp : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private bool _demo;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        if (transform.position.y > 1480 || Input.GetKeyDown(KeyCode.Escape))
            if(_demo)
                SceneManager.LoadScene("TutorialDemo");
            else
                SceneManager.LoadScene("Tutorial");
    }   
}
