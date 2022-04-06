using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAIBenchmark : MonoBehaviour
{
    Transform[] tanks;
    public int numberOfTanks;
    public GameObject tankPrefab;
    public Transform playerTransform;
    private Vector3 vector = new Vector3(0, 0, 0.05f);

    // Start is called before the first frame update
    void Start()
    {
        tanks = new Transform[numberOfTanks];
        for (int i = 0; i < numberOfTanks; i++)
        {
            tanks[i] = Instantiate(tankPrefab).transform;
            tanks[i].position = new Vector3(Random.Range(-50,50), 0, Random.Range(-50,50));
            //tanks[i].gameObject.GetComponent<TankBenchmark>().playerTransform = playerTransform;
        }
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
            return;
        
        var pos = playerTransform.position;
        foreach (var t in tanks)
        {
            t.LookAt(pos);
            t.Translate(vector);
        }
    }
}
