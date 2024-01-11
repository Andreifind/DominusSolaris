using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private StageDisplay _stageDisp;
    // Start is called before the first frame update
    public GameObject[,] Enemy = new GameObject[10, 7];
    public GameObject[,] Squids = new GameObject[10, 3];
    public GameObject[] Rachetele = new GameObject[10];
    // planet 0
    public GameObject gandac1;
    public GameObject gandac2;
    public GameObject gandac3;
    public GameObject gandac1f;
    public GameObject gandac2f;
    public GameObject gandac3f;
    public GameObject gandacb;

    public GameObject racheta1;

    public GameObject squid1;
    public GameObject squid2;
    public GameObject squid3;
    // planet 1
    public GameObject tun1;
    public GameObject tun2;
    public GameObject tun3;
    public GameObject tun1f;
    public GameObject tun2f;
    public GameObject tun3f;
    public GameObject tunb;
    public GameObject drill;
    //planet 3
    public GameObject int1;
    public GameObject int2;
    public GameObject int3;
    public GameObject int1f;
    public GameObject int2f;
    public GameObject int3f;
    public GameObject intb;
    public GameObject ddrill;
    //planet space
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    // planet 4
    public GameObject wasp1;
    public GameObject wasp2;
    public GameObject wasp3;
    public GameObject wasp1f;
    public GameObject wasp2f;
    public GameObject wasp3f;
    public GameObject waspb;
    // planet 5
    public GameObject wraith1;
    public GameObject wraith2;
    public GameObject wraith3;
    public GameObject wraith1f;
    public GameObject wraith2f;
    public GameObject wraith3f;
    public GameObject wraithb;
    public GameObject spikeball;
    // tutorial
    public GameObject tutorialenemy;
    //
    public GameObject Mine;
    private int ypos;
    private Vector2 lpos;
    private float timeBtwSpawn = 1;
    public float startTimeBtwSpawn = 1;
    public int nr = 0;
    private int en;
    private Transform player;
    public int wave = 0;
    public int bossded = 0;
    public int planet = 0;
    private int rnd = 0, rnd1 = 0;
    bool spawned = false;
    public bool aspawned = false;
    // Update is called once per frame
    void Start()
    {
        Enemy[0, 0] = gandac1;
        Enemy[0, 1] = gandac2;
        Enemy[0, 2] = gandac3;
        Enemy[0, 3] = gandac1f;
        Enemy[0, 4] = gandac2f;
        Enemy[0, 5] = gandac3f;
        Enemy[0, 6] = gandacb;
        Squids[0, 0] = squid1;
        Squids[0, 1] = squid2;
        Squids[0, 2] = squid3;
        //
        Enemy[1, 0] = tun1;
        Enemy[1, 1] = tun2;
        Enemy[1, 2] = tun3;
        Enemy[1, 3] = tun1f;
        Enemy[1, 4] = tun2f;
        Enemy[1, 5] = tun3f;
        Enemy[1, 6] = tunb;
        //
        Enemy[2, 0] = int1;
        Enemy[2, 1] = int2;
        Enemy[2, 2] = int3;
        Enemy[2, 3] = int1f;
        Enemy[2, 4] = int2f;
        Enemy[2, 5] = int3f;
        Enemy[2, 6] = intb;
        //
        Enemy[3, 0] = wasp1;
        Enemy[3, 1] = wasp2;
        Enemy[3, 2] = wasp3;
        Enemy[3, 3] = wasp1f;
        Enemy[3, 4] = wasp2f;
        Enemy[3, 5] = wasp3f;
        Enemy[3, 6] = waspb;
        //
        Enemy[5, 0] = wraith1;
        Enemy[5, 1] = wraith2;
        Enemy[5, 2] = wraith3;
        Enemy[5, 3] = wraith1f;
        Enemy[5, 4] = wraith2f;
        Enemy[5, 5] = wraith3f;
        Enemy[5, 6] = wraithb;
        //
        Enemy[8, 0] = tutorialenemy;
        Rachetele[0] = racheta1;
        player = GameObject.Find("ship").transform;
        wave = player.GetComponent<Ship>().wave;
        planet = player.GetComponent<Ship>().planet;
    }
    void Update()
    {
        player.GetComponent<Ship>().planet = planet;
        if (planet != 4)
        {
            //reset clock, next planet
            if (wave > 3)
            {
                planet++;
                player.GetComponent<Ship>().scenetrigger = true;
                wave = 0;
                timeBtwSpawn = 10;
            }
            //next wave
            if (bossded == 1)
            {
                //Debug.Log("boss is dead");
                if (timeBtwSpawn > 0)
                    if (player.GetComponent<Ship>().justloaded == false) timeBtwSpawn -= Time.deltaTime;
                wave++;
                player.GetComponent<Ship>().wave++;
                if(wave <= 3)
                    _stageDisp.IsMoving = true;
                bossded = 0;
                nr = 0;
                spawned = false;
            }

            if (player.GetComponent<Ship>().wave != wave) player.GetComponent<Ship>().wave = wave;
            //spawn enemies
            if (timeBtwSpawn <= 0)
            {
                ypos = Random.Range(-8, 7);
                lpos = new Vector2(15, ypos / 2);
                if (timeBtwSpawn <= 0)
                {
                    if (planet != 4) timeBtwSpawn = startTimeBtwSpawn;
                    else timeBtwSpawn = 2 * startTimeBtwSpawn;
                    if (planet == 8 && spawned == false)
                    {
                        //StartCoroutine(Wait());
                        //spawned=true;
                        //timeBtwSpawn=20;
                    }
                }
                if (nr == 20 && wave < 3)
                {
                    if (planet != 8) Instantiate(Enemy[planet, wave + 3], lpos, Quaternion.identity);
                    nr++;
                    timeBtwSpawn = 10;
                }
                if (nr < 20 && wave < 3 && planet != 8)
                {
                    if (wave < 3 && (nr == 5 || nr == 10 || nr == 15))
                    {
                        if (planet == 0)
                        {
                            lpos = new Vector2(15, 1);
                            Instantiate(Squids[planet, wave], lpos, Quaternion.identity);
                            lpos = new Vector2(15, -1);
                            Instantiate(Squids[planet, wave], lpos, Quaternion.identity);
                            lpos = new Vector2(17, 2);
                            Instantiate(Squids[planet, wave], lpos, Quaternion.identity);
                            lpos = new Vector2(17, -2);
                            Instantiate(Squids[planet, wave], lpos, Quaternion.identity);
                            lpos = new Vector2(19, 3);
                            Instantiate(Squids[planet, wave], lpos, Quaternion.identity);
                            lpos = new Vector2(19, -3);
                            Instantiate(Squids[planet, wave], lpos, Quaternion.identity);
                            lpos = new Vector2(21, 0.01f);
                            Instantiate(Squids[planet, wave], lpos, Quaternion.identity);
                            lpos = new Vector2(21, -0.01f);
                            Instantiate(Squids[planet, wave], lpos, Quaternion.identity);
                            timeBtwSpawn = 6;
                        }
                        if (planet == 1)
                        {
                            lpos = new Vector2(15, 1);
                            Instantiate(drill, lpos, Quaternion.identity);
                            lpos = new Vector2(15, -1);
                            Instantiate(drill, lpos, Quaternion.identity);
                            lpos = new Vector2(19, 2);
                            Instantiate(drill, lpos, Quaternion.identity);
                            lpos = new Vector2(19, -2);
                            Instantiate(drill, lpos, Quaternion.identity);
                            lpos = new Vector2(23, 3);
                            Instantiate(drill, lpos, Quaternion.identity);
                            lpos = new Vector2(23, -3);
                            Instantiate(drill, lpos, Quaternion.identity);
                            lpos = new Vector2(25, 0.01f);
                            Instantiate(drill, lpos, Quaternion.identity);
                            lpos = new Vector2(25, -0.01f);
                            Instantiate(drill, lpos, Quaternion.identity);
                            timeBtwSpawn = 6;
                        }
                        if (planet == 2)
                        {
                            lpos = new Vector2(15, 1);
                            Instantiate(ddrill, lpos, Quaternion.identity);
                            lpos = new Vector2(15, -1);
                            Instantiate(ddrill, lpos, Quaternion.identity);
                            lpos = new Vector2(17, 2);
                            Instantiate(ddrill, lpos, Quaternion.identity);
                            lpos = new Vector2(17, -2);
                            Instantiate(ddrill, lpos, Quaternion.identity);
                            lpos = new Vector2(19, 3);
                            Instantiate(ddrill, lpos, Quaternion.identity);
                            lpos = new Vector2(19, -3);
                            Instantiate(ddrill, lpos, Quaternion.identity);
                            lpos = new Vector2(21, 0.01f);
                            Instantiate(ddrill, lpos, Quaternion.identity);
                            lpos = new Vector2(21, -0.01f);
                            Instantiate(ddrill, lpos, Quaternion.identity);
                            timeBtwSpawn = 6;
                        }
                        if (planet == 3)
                        {
                            lpos = new Vector2(15, 1);
                            Instantiate(Mine, lpos, Quaternion.identity);
                        }
                        if (planet == 5)
                        {
                            lpos = new Vector2(15, 1);
                            Instantiate(spikeball, lpos, Quaternion.identity);
                            lpos = new Vector2(15, -1);
                            Instantiate(spikeball, lpos, Quaternion.identity);
                            lpos = new Vector2(17, 2);
                            Instantiate(spikeball, lpos, Quaternion.identity);
                            lpos = new Vector2(17, -2);
                            Instantiate(spikeball, lpos, Quaternion.identity);
                            lpos = new Vector2(19, 3);
                            Instantiate(spikeball, lpos, Quaternion.identity);
                            lpos = new Vector2(19, -3);
                            Instantiate(spikeball, lpos, Quaternion.identity);
                            lpos = new Vector2(21, 0.01f);
                            Instantiate(spikeball, lpos, Quaternion.identity);
                            lpos = new Vector2(21, -0.01f);
                            Instantiate(spikeball, lpos, Quaternion.identity);
                            timeBtwSpawn = 6;
                        }

                    }
                    else if (wave < 3 && (nr == 3 || nr == 6 || nr == 9 || nr == 12 || nr == 15 || nr == 18))
                    {
                        ypos = Random.Range(0, 2);
                        if (ypos == 0)
                        {

                            lpos = new Vector2(15, 0);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                            lpos = new Vector2(20, 0);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                            lpos = new Vector2(25, 0);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                        }
                        else
                        {
                            lpos = new Vector2(15, 3);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                            lpos = new Vector2(20, 3);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                            lpos = new Vector2(25, 3);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                            lpos = new Vector2(15, -3);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                            lpos = new Vector2(20, -3);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                            lpos = new Vector2(25, -3);
                            Instantiate(Rachetele[0], lpos, Quaternion.identity);
                        }

                    }
                    else if (wave < 3) Instantiate(Enemy[planet, wave], lpos, Quaternion.identity);
                    nr++;
                }
                if (wave == 3 && nr == 0)
                {
                    lpos = new Vector2(15, 0);
                    Instantiate(Enemy[planet, 6], lpos, Quaternion.identity);
                    nr++;
                }
            }
            else if (player.GetComponent<Ship>().justloaded == false) timeBtwSpawn -= Time.deltaTime;
        }
        //nivel spatiu asteroizi
        else
        {
            //Random.Range(0, 2);
            //reset clock, next planet
            if (wave > 2)
            {
                planet++;
                player.GetComponent<Ship>().scenetrigger = true;
                wave = 0;
                timeBtwSpawn = 10;
            }
            //next wave
            if (bossded == 1)
            {
                //Debug.Log("boss is dead");
                timeBtwSpawn = 4;
                wave++;
                player.GetComponent<Ship>().wave++;
                if (wave <= 2)
                    _stageDisp.IsMoving = true;
                bossded = 0;
                nr = 0;
            }
            if (player.GetComponent<Ship>().wave != wave) player.GetComponent<Ship>().wave = wave;
            //spawn enemies
            if (timeBtwSpawn <= 0)
            {
                lpos = new Vector2(Random.Range(10, 9), 10);
                //timeBtwSpawn=1;
                //Debug.Log(timeBtwSpawn);
                if (nr <= 20 && wave == 0)
                {
                    lpos = new Vector2(Random.Range(1, 9), 10 + Random.Range(0, 10));
                    Instantiate(asteroid1, lpos, Quaternion.identity);
                    lpos = new Vector2(Random.Range(9, 25), 10 + Random.Range(0, 10));
                    Instantiate(asteroid1, lpos, Quaternion.identity);
                    lpos = new Vector2(Random.Range(9, 25), 10 + Random.Range(0, 10));
                    Instantiate(asteroid1, lpos, Quaternion.identity);
                    lpos = new Vector2(Random.Range(9, 25), 10 + Random.Range(0, 10));
                    Instantiate(asteroid1, lpos, Quaternion.identity);
                    nr++;
                    timeBtwSpawn = 1.5f;
                }
                if (nr <= 20 && wave == 1)
                {
                    while (rnd == rnd1)
                        rnd = Random.Range(0, 3);
                    rnd1 = rnd;
                    if (rnd == 0)
                    {
                        lpos = new Vector2(50 + Random.Range(-4, 4), 3.5f);
                        Instantiate(asteroid2, lpos, Quaternion.identity);
                        lpos = new Vector2(50 + Random.Range(-4, 4), -0.3f);
                        Instantiate(asteroid2, lpos, Quaternion.identity);
                    }
                    else if (rnd == 1)
                    {
                        lpos = new Vector2(50 + Random.Range(-4, 4), 3);
                        Instantiate(asteroid2, lpos, Quaternion.identity);
                        lpos = new Vector2(50 + Random.Range(-4, 4), -3);
                        Instantiate(asteroid2, lpos, Quaternion.identity);
                    }
                    else
                    {
                        lpos = new Vector2(50 + Random.Range(-4, 4), 0.3f);
                        Instantiate(asteroid2, lpos, Quaternion.identity);
                        lpos = new Vector2(50 + Random.Range(-4, 4), -3.5f);
                        Instantiate(asteroid2, lpos, Quaternion.identity);
                    }
                    nr += 1;
                    timeBtwSpawn = 2f;
                }
                if (wave == 2 && aspawned == false) nr = 1;
                if (nr == 1 && wave == 2 && aspawned == false)
                {
                    lpos = new Vector2(18, 0);
                    Instantiate(asteroid3, lpos, Quaternion.identity);
                    nr = 2;
                    aspawned = true;
                }
                if (nr >= 20)
                    bossded = 1;
                if (wave > 2) planet++;
            }
            else if (player.GetComponent<Ship>().justloaded == false) timeBtwSpawn -= Time.deltaTime;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Enemy[planet, 0], lpos, Quaternion.identity);
    }

    public void res()
    {
        //nr = 0;
    }
}
