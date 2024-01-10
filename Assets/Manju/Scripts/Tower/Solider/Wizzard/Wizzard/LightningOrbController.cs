using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningOrbController : MonoBehaviour
{
    int atk;
    void Start()
    {
        StartCoroutine(CoolTimeCo());
        atk = TowerManager.Instance.selectTile.towerObj.GetComponent<Tower>().status.atk;
    }
    IEnumerator CoolTimeCo()
    {
        yield return new WaitForSeconds(2.0f);        
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Monster>(out var monster))
        {
            monster.TakeDamage((int)(atk * 1.2f));
        }
    }
}
