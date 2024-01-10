using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudObj;

    public float timer;
    public float createDelay;

    private void Start()
    {
        timer = 8.0f;
        createDelay = 8f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= createDelay)
        {
            timer = 0;
            CreateCloud();
        }
    }

    void CreateCloud()
    {
        Vector3 pos = transform.position;

        pos.y += Random.Range(-4.5f, 4.5f);

        GameObject cloud = Instantiate(cloudObj, pos, Quaternion.identity);
    }
}
