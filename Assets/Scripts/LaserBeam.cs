using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
	[SerializeField] private Transform player;
	private Ship _ship;
	private Vector2 targetPos;
	float tfire;
	float atacc;
	public bool hit=false;
	public GameObject inv;
	private SpriteRenderer spriteRenderer;
	Vector2 poss;
	//public int damage=20;
    // Start is called before the first frame update
    void Start()
    {
        //player=GameObject.Find("ship").transform;
        _ship=player.GetComponent<Ship>();
        atacc =.02f;
        _ship.laseron=true;
		Debug.Log("merge");
		
    }
    // Update is called once per frame
    void Update()
    {
		if(_ship.justloaded)
		{
            _ship.laserdown=1;
            _ship.laseron=false;
            _ship.lass=true;
		}
		poss= new Vector2(transform.position.x-7.95f, transform.position.y-.12f);
		if (tfire <= 0)
                {
                    var projectile = Instantiate(inv, poss, Quaternion.identity);
					projectile.transform.parent = player;
					tfire = atacc;
                }
                else
                    tfire -= Time.deltaTime;
        targetPos= new Vector2(player.position.x+1.05f, player.position.y-0.12f);
		transform.position=targetPos;
		if (_ship.energy<=0f)
		{
            _ship.laserdown=1;
			Sounds.PlaySound ("laserend");
            _ship.laseron=false;
            _ship.lass=true;
			Debug.Log("poc");
		}
		else
            _ship.energy-=50*Time.deltaTime;
    }
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag==("Projectile"))
	{
		Destroy(other.gameObject);
	}
	}
}
