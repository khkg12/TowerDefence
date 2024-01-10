using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlooringObj : MonoBehaviour
{
    int atk;
    private void Start()
    {
        StartCoroutine(CoolTimeCo());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Monster>(out var monster))
        {
            monster.TakeDamage(atk);
        }        
    }

    IEnumerator CoolTimeCo()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    public void SetAtk(int atk)
    {
        this.atk = atk;
    }
    
}
