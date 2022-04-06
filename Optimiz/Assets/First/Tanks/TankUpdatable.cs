using UnityEngine;


public class TankUpdatable : MonoBehaviour, IUpdatable
{
    public Transform playerTransform;
    private Vector3 vector = new Vector3(0, 0, 0.05f);

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Tick()
    {
        if (playerTransform == null)
            return;
        
        var pos = playerTransform.position;
        transform.LookAt(pos);
        transform.Translate(vector);
    }
}