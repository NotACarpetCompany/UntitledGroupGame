using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{   
    public int numEnemies;
    public float max_cooldown;
    public float range;
    public GameObject enemy;

    private GameObject playerObj;
    private Camera cam;
    private float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        //Initiate Player Object
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        } else if (cooldown <= 0 & numEnemies != 0) {
            numEnemies -= 1;
            Spawn();
            cooldown = max_cooldown;
        }
    }

    void Spawn() {

        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        int randNum = Random.Range(0,2);
        float startHeight;
        float startWidth;

        if (randNum == 0) {
            startHeight = Random.Range(camHeight, camHeight + range);
            startWidth = Random.Range(0, camWidth + range);
        } else {
            startHeight = Random.Range(0, camHeight + range);
            startWidth = Random.Range(camWidth, camWidth + range);
        }

        randNum = Random.Range(0,2);
        if (randNum == 0) {
            startHeight *= -1;
        }

        randNum = Random.Range(0,2);
        if (randNum == 0) {
            startWidth *= -1;
        }

        Vector3 position = new Vector3(startHeight, startWidth, 10);
        GameObject clone = Instantiate(enemy, cam.transform.position + position, transform.rotation);
    }
}
