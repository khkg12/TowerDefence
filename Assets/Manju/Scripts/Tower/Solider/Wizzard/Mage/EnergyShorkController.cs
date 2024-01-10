using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShorkController : MonoBehaviour
{
    int atk;
    Collider cd;
    private void Start()
    {
        cd = GetComponent<Collider>();    
        StartCoroutine(CoolTimeCo());
        atk = TowerManager.Instance.selectTile.towerObj.GetComponent<Tower>().status.atk;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Monster>(out var monster))
        {
            monster.TakeDamage((int)(atk* 1.5f));
        }
    }

    IEnumerator CoolTimeCo()
    {
        yield return new WaitForSeconds(1.0f);
        cd.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public void SetAtk(int atk)
    {
        this.atk = atk;
    }
}
