using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class SwordAurorController : MonoBehaviour
{
    public int atk;
    public float speed;

    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(DestoryCo());
    }

    IEnumerator DestoryCo()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        transform.position += transform.forward * speed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Monster>(out var monster))
        {
            monster.TakeDamage((int)(atk * 1.5f));
        }
    }
}
