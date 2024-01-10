using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEngine;

public class Archor : Soldier
{



    private void RangeAttack( GameObject target )
    {

        
        RangeObj range = Instantiate(attackObj).GetComponent<RangeObj>();
        
        range.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);

        range.SetTarget( target , this);

        StartCoroutine( AttackDelayCo() );

    }
    
    protected override void Attack(GameObject targetObj)
    {

        if( targetObj.TryGetComponent<Monster>(out var monster))
        {
            animator.SetTrigger("isAttack");
            RangeAttack( targetObj );
        }
            
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        InitTargetList();

        // monsters.Any() == monsters.empty()
        if (isAttack && monsters.Any())
            Attack( SetTarget() );


    }
}
