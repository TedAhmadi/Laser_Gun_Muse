using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActTarget : MonoBehaviour {

    public GameObject Position;
    public GameObject[] enemies;
    GameObject fruit;
    public static int actTarget;
    public int currentcountcube;
    public int randTarget = 1, randTarget1 = 3, randTarget2 = 5;
    // Use this for initialization
    void Start () {
        randTarget = Random.Range(0, 9);
        randTarget1 = Random.Range(0, 9);
        randTarget2 = Random.Range(0, 9);
        if (randTarget == randTarget1 || randTarget == randTarget2)
        {
            randTarget = Random.Range(0, 9);
        }
        else if (randTarget1 == randTarget2)
        {
            randTarget1 = Random.Range(0, 9);
        }
        else { }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(string.Format(" randTarget: ") + randTarget+ " randTarget1: " + randTarget1+ " randTarget2: " + randTarget2);
        currentcountcube = Spawn_Cube.current_count_cube;

        if (currentcountcube >= 0 && currentcountcube <= 35)
        {
            actTarget = randTarget;
            if (currentcountcube == 0) { InstantiateEnemy(); }
        }
        else if (currentcountcube > 35 && currentcountcube <= 70)
        {
            actTarget = randTarget1;
            if (currentcountcube == 36) { InstantiateEnemy(); }
        }
        else if (currentcountcube > 70 && currentcountcube <= 100)
        {
            actTarget = randTarget2;
            if (currentcountcube == 71) { InstantiateEnemy(); }
        }
        else { }
        

    }
    void InstantiateEnemy()
    {
        Destroy(fruit);
        fruit = Instantiate(enemies[actTarget], Position.transform);
    }
}
