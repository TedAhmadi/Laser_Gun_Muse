using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Cube : MonoBehaviour {

    public Rigidbody[] enemies;

    //public Vector3 spawnValues;
    public Transform frute;
    public float spawnWait, spawnWait2, spawnWait3;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    public int Max_cube;
    public int count_cube;
    public static int current_count_cube;
    int randEnemey, randEnemey1, randEnemey2,  randSpeed1, randSpeed2, randSpeed3;
    
    // Use this for initialization
    void Start () {
        StartCoroutine(waitSpawner());
    }
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        spawnWait2 = Random.Range(spawnLeastWait, spawnMostWait);
        spawnWait3 = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            Rigidbody tt,mm;
            randEnemey = Random.Range(0, 9);
            randEnemey1 = Random.Range(0, 9);
            randEnemey2 = Random.Range(0, 9);

            randSpeed1 = Random.Range(500, 1000);
            randSpeed2 = Random.Range(300, 400);
            randSpeed3 = Random.Range(300, 400);
            
            //Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));
            tt = Instantiate(enemies[randEnemey], frute.position, frute.transform.rotation) as Rigidbody;
            tt.AddForce(frute.forward * randSpeed1);
            
            yield return new WaitForSeconds(spawnWait2);
            mm = Instantiate(enemies[randEnemey1], frute.position + new Vector3(2, 0, 0), frute.transform.rotation) as Rigidbody;
            mm.AddForce(frute.forward * randSpeed2);

            yield return new WaitForSeconds(spawnWait3);
            mm = Instantiate(enemies[randEnemey2], frute.position + new Vector3(-2, 0, 0), frute.transform.rotation) as Rigidbody;
            mm.AddForce(frute.forward * randSpeed3);
            
            count_cube ++;
            current_count_cube = count_cube;
            if (count_cube >= Max_cube)
            {
                stop = true;
            }
            yield return new WaitForSeconds(spawnWait);
        }

    }
}
