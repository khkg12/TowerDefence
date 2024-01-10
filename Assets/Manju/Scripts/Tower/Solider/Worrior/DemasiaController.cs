using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemasiaController : MonoBehaviour
{
    public int atk;

    private void Start()
    {
        if(TryGetComponent<BoxCollider>(out var Col))
        {
            Col.enabled = false;
            StartCoroutine(CreateDemasiaRangeCo());
        }
        else
        {
            StartCoroutine(DestoryCo());
        }
    }

    public IEnumerator CreateDemasiaRangeCo()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

    public IEnumerator DestoryCo()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Monster>(out var monster))
        {
            monster.TakeDamage((int)(atk*2.5f));
        }
    }
}
