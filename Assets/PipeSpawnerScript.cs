using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float Timer = 0;
    public float heightOffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer < spawnRate)
        {
            Timer = Timer + Time.deltaTime;

        }
        else
        {
            spawnPipe();
            Timer = 0;

        }
    }

    void spawnPipe()
    {
        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y - heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0) , transform.rotation);

    }
}
