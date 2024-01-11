using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 vectorToTarget;
    float angle;
    Quaternion q;
    //public GameObject ship;
    public int speed;
    private float tfire;
    public float atacc;
    Animator animator;
    public GameObject prj;
    private Transform playe;
    [SerializeField] private Boss2 _boss;
    Vector2 pos;
    void Start()
    {
        animator=GetComponent<Animator>();
        playe = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //rotire dupa player
        vectorToTarget = playe.position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg+180*Mathf.Deg2Rad   ;
        q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        //foc
        if (tfire <= 0 && playe.GetComponent<Ship>().dialog==false && _boss.CanFire)
                {
                    animator.SetTrigger("atac");
                    tfire = atacc;
                }
        else if(playe.GetComponent<Ship>().dialog==false)
        {
                    tfire -= Time.deltaTime;
                    animator.ResetTrigger("atac");
                    //animator.ResetTrigger("Radar");
         }
    }
    public void shoot()
    {
        Sounds.PlaySound ("bossfire");
        pos=transform.position;
        pos.x-=0.85f;
        Instantiate(prj, pos, q);
        animator.ResetTrigger("atac");
    }
}
