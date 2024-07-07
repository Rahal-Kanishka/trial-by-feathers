using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2.5F;
    private float timer = 0;
    public float heightOffset = 8;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Debug.Log("spawnRate: " + spawnRate + ", timer: " + timer + ", delta time: " + Time.deltaTime);
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowest = transform.position.y - heightOffset;
        float highest = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowest, highest)), transform.rotation);

    }
}
