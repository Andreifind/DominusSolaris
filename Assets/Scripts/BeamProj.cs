using UnityEngine;

public class BeamProj : MonoBehaviour
{
    int damage;
    public GameObject las;
    private Ship player;
    int nr;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Ship>();
        
        nr = Random.Range(0, 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("player damage is "+player.damage);
        damage = player.damage;
        if (nr > player.crit)
            damage = player.damage*2;
        transform.Translate(Vector2.right * 160 * Time.deltaTime);
        if (transform.position.x>20)
			Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		
	if (other.gameObject.name==("poc") || other.gameObject.tag==("enemy"))
        {
			Destroy(gameObject);
		}
	if (other.gameObject.tag==("Projectile"))
        {
            Destroy(other.gameObject);
        }
	if (other.gameObject.tag==("enemy"))
	{
		other.GetComponent<Enemy>().hp -= damage;
        las.GetComponent<Laser>().hit=true;
        las.GetComponent<Laser>().ics=transform.position.x;
		//other.GetComponent<Enemy>().ishit=1;
		DamagePopup.Create(transform.position, damage);
	}
		
	}
}
