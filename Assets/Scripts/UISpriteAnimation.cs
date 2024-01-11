using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteAnimation : MonoBehaviour
{

    public Image m_Image;

    public Sprite[] m_SpriteArray;
    public Sprite _stopSprite;
    public float m_Speed = .02f;

    private int m_IndexSprite;
    Coroutine m_CorotineAnim;
    bool IsDone;
    public void OnMouseOver()
    {
        Debug.Log("on mouse over!");
        //Func_PlayUIAnim();
    }
    public void OnMouseExit()
    {
        Debug.Log("on mouse exit!");
        //Func_StopUIAnim();
    }
    public void Func_PlayUIAnim()
    {
        Debug.Log("play ui anim");
        IsDone = false;
        StartCoroutine(Func_PlayAnimUI());
    }

    public void Func_StopUIAnim()
    {
        Debug.Log("stop ui anim");
        IsDone = true;
        StopCoroutine(Func_PlayAnimUI());
        StartCoroutine(Func_StopAnimUI());
    }
    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSecondsRealtime(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length)
        {
            m_IndexSprite = 0;
        }
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        m_IndexSprite += 1;
        if (IsDone == false)
            m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
    }
    IEnumerator Func_StopAnimUI()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        m_Image.sprite = _stopSprite;
    }
}