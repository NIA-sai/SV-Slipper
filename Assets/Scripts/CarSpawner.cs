using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    private bool direction;
    private GameObject prefab;

    private float timestamp;
    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Car");
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp)
        {
            spawn();
        }
    }

    private void spawn()
    {
        
        GameObject car = Instantiate(prefab);   
        CarController carController = car.GetComponent<CarController>();
        carController.RandomInitial(direction, Random.Range(0.9f, 1.1f) * 8.0f, (byte)Random.Range(0, 2), transform.position);
        timestamp = Time.time + Random.Range(0.4f, 2.5f);
    }
}
