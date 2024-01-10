using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAttackController : MonoBehaviour
{
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.4f;
        StartCoroutine(DestroyCo());
    }

    IEnumerator DestroyCo()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
