using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaldoController : MonoBehaviour
{
    public int atk;

    private void Start()
    {
        StartCoroutine(DestoryCo());
    }

    IEnumerator DestoryCo()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Monster>(out var monster))
        {
            monster.TakeDamage((int)(atk * 2.0f));
        }
    }
}
