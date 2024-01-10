using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    public AudioClip skillSound;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf" , 0.7f);
    }


    private void DestroySelf()
    {
        AudioSource.PlayClipAtPoint(skillSound, transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Monster monster;
        if(other.TryGetComponent<Monster>(out monster))
        {
            monster.TakeDamage(140);
        }
    }

}
