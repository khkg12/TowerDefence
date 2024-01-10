using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Archer : Soldier
{
    private ParticleSystem cast;
    private Coroutine delay;

    [SerializeField]
    private GameObject arrow;

    private GameObject monster;

    private void OnEnable()
    {
        if (TryGetComponent<ParticleSystem>(out cast))
            cast.Stop();
    }


    public void RangeAttack(GameObject target)
    {


        RangeObj range = Instantiate(attackObj).GetComponent<RangeObj>();
        range.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        range.SetTarget(target, this);

        delay = StartCoroutine(AttackDelayCo());

    }


    public void AttackSpeedInit(float time , float speed)
    {
        StartCoroutine( AttackSpeedCo(time,speed) );

    }


    public IEnumerator AttackSpeedCo(float time, float speed)
    {

        yield return new WaitForSeconds(time);
        status.atkSpeed = speed;
        isAttack = true;

    }


    IEnumerator StopAttackCo(float time)
    {

        isAttack = false;
        yield return new WaitForSeconds(time);
        isAttack = true;
    }


    protected override void Attack(GameObject targetObj)
    {
        if (targetObj.TryGetComponent<Monster>(out var monster))
        {
            AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.idleSound], transform.position);
            animator.SetTrigger("isAttack");
            RangeAttack(targetObj);
        }

    }
    IEnumerator DelaySkillCo(float time)
    {

        

        StopCoroutine(delay);
        yield return new WaitForSeconds(time);


        Monster target = SetTarget().GetComponent<Monster>();
        Vector3 targetPos = target.transform.position;
        if (target == null)
            Debug.Log(target);
        else
            status.towerSkills[0].UseSkill(this, target, arrow);


        yield return new WaitForSeconds(status.atkSpeed);
        isAttack = true;

    }

    IEnumerator DelaySkillCo(float time , Vector3 pos)
    {

        StopCoroutine(delay);
        yield return new WaitForSeconds(time);

        Monster target = SetTarget().GetComponent<Monster>();


        if (target.gameObject == null)
            status.towerSkills[0].UseSkill(this, pos, arrow);
        else
            status.towerSkills[0].UseSkill(this, target, arrow);


        yield return new WaitForSeconds(status.atkSpeed);
        isAttack = true;
    }


    public override void UseSkill()
    {
        if (status.mp != status.maxMp)
            return;

        if (SetTarget() == null)
            return;

        status.mp = 0;

        if (cast != null)
        {
            StartCoroutine(DelaySkillCo(3.2f,SetTarget().transform.position));
            cast.Play();
        }
        else
        {
            status.towerSkills[0].UseSkill(this, SetTarget().GetComponent<Monster>());
        }
        AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.skillSound], transform.position);
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        InitTargetList();

        // monsters.Any() == monsters.empty()
        if (isAttack && monsters.Any())
        {
            Attack(SetTarget());
        }


        if (isIncomeMp)
        {
            IncomeMp();
            StartCoroutine(IncomeMpDelayCo());
        }
            
        

    }

}
