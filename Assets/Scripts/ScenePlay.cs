using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenePlay : MonoBehaviour
{
    public bool demo;
    private bool _firsttime = true;
    PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        data = SaveLoad.LoadPlayer();
        if(data.cancontinue==false) _firsttime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(data!=null)
        {
            if ((Input.GetKeyDown(KeyCode.Space)) && data.cancontinue == true)
                if (demo) SceneManager.LoadScene("TutorialDemo");
                else SceneManager.LoadScene("Tutorial");
            else if ((Input.GetKeyDown(KeyCode.Space)) && (data.cancontinue == false))
            {
                SceneManager.LoadScene("Intro");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("Intro");


        if (Input.GetKeyUp(KeyCode.Delete))
            SaveLoad.Delete();
    }
}
