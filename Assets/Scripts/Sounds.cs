using UnityEngine;

public class Sounds : MonoBehaviour
{
	public static AudioClip boom, pew, shield, shieldd,bonus, unavailable, up, biglaser,laserend,cooldown,cdup,roket,bossboom,bossfire,bossradar,tesla,flare,bigboom;
	static AudioSource audioSrc;
    void Start()
    {
        pew= Resources.Load<AudioClip> ("pew");
		boom= Resources.Load<AudioClip> ("boom");
		shield= Resources.Load<AudioClip> ("shield");
		shieldd= Resources.Load<AudioClip> ("shielddown");
		bonus=Resources.Load<AudioClip> ("bonusbox");
		unavailable=Resources.Load<AudioClip> ("unavailable");
		up = Resources.Load<AudioClip> ("up");
		biglaser = Resources.Load<AudioClip> ("biglaser");
		bigboom = Resources.Load<AudioClip> ("bigboom");
		laserend= Resources.Load<AudioClip> ("laserend");
		cooldown = Resources.Load<AudioClip> ("cooldown");
		cdup = Resources.Load<AudioClip> ("cdup");
		roket = Resources.Load<AudioClip> ("launchroket");
		bossboom = Resources.Load<AudioClip> ("bossboom");
		bossfire = Resources.Load<AudioClip> ("bossfire");
		bossradar = Resources.Load<AudioClip> ("bossradar");
		tesla = Resources.Load<AudioClip> ("tesla");
		flare = Resources.Load<AudioClip> ("flare");
		audioSrc = GetComponent<AudioSource>();
    }

	public static void PlaySound (string clip)
		{
			switch (clip)
			{
				case "pew":
				audioSrc.PlayOneShot(pew);
				break;
				case "bum":
				audioSrc.PlayOneShot(boom);
				break;
				case "shield":
				audioSrc.PlayOneShot(shield);
				break;
				case "shieldd":
				audioSrc.PlayOneShot(shieldd);
				break;
				case "bonus":
				audioSrc.PlayOneShot(bonus);
				break;
				case "unavailable":
				audioSrc.PlayOneShot(unavailable);
				break;
				//case "up":
				//audioSrc.PlayOneShot(up);
				//break;
				case "biglaser":
				audioSrc.PlayOneShot(biglaser);
				break;
				case "cooldown":
				audioSrc.PlayOneShot(cooldown);
				break;
				case "laserend":
				audioSrc.PlayOneShot(laserend);
				break;
				case "cdup":
				audioSrc.PlayOneShot(cdup);
				break;
				case "roket":
				audioSrc.PlayOneShot(roket);
				break;
				case "bossboom":
				audioSrc.PlayOneShot(bossboom);
				break;
				case "bossfire":
				audioSrc.PlayOneShot(bossfire);
				break;
				case "bossradar":
				audioSrc.PlayOneShot(bossradar);
				break;
				case "tesla":
				audioSrc.PlayOneShot(tesla);
				break;
				case "flare":
				audioSrc.PlayOneShot(flare);
				break;
				case "bigboom":
				audioSrc.PlayOneShot(bigboom);
				break;
			
		}
}
}
