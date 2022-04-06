using UnityEngine;
using Random = UnityEngine.Random;


public class UpdateManager : MonoBehaviour
{
    private IUpdatable[] tanks;
    public int numberOfTanks;
    public GameObject tankPrefab;
    private void Start()
    {
        tanks = new IUpdatable[numberOfTanks];
        for (var i = 0; i < numberOfTanks; i++)
        {
            tanks[i] = Instantiate(tankPrefab, new Vector3(Random.Range(-50f,50f), 0, Random.Range(-50f,50f)), Quaternion.identity).GetComponent<TankUpdatable>();
        }
    }

    private void Update()
    {
        foreach (var tank in tanks)
        {
            if (tank != null)
                tank.Tick();
        }
    }
}