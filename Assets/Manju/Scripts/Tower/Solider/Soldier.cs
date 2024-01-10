using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Soldier : Tower
{
    public GameObject attackObj;

    protected enum TowerSound
    {
        idleSound = 0,
        skillSound = 1,
    }

    public List<AudioClip> towerSoundList;

    protected Animator animator;

    [SerializeField]
    protected List<Monster> monsters;

    protected GameObject SetTarget()
    {
        float maxWeight = 0;
        GameObject target = null;
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i].GetDistance() > maxWeight)
            {
                maxWeight = monsters[i].GetDistance();
                target = monsters[i].gameObject;
            }
        }
        return target;
    }

    protected void InitTargetList()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i] == null)
            {
                monsters.RemoveAt(i);
                i--;
            }
        }
        
        for(int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i].isDie == true)
            {
                monsters.RemoveAt(i);
                i--;
            }
        }
    }

    public bool isAttack;
    protected bool isIncomeMp;

    public WaitForSeconds attackDelay;
    protected WaitForSeconds incomeMpDelay;

    private float mpTimer;

    public GameObject mpSlider;

    protected void Start()
    {
        mpTimer = 1.0f;
        isAttack = true;
        isIncomeMp = true;
        incomeMpDelay = new WaitForSeconds(mpTimer); // Mp회복에 1초 딜레이줌

        if (TryGetComponent<Animator>(out var myAnimator))
        {
            animator = myAnimator;
        }

        Player.Instance.population++;
        mpSlider = Instantiate(mpSlider, transform.position, Quaternion.identity);
        mpSlider.transform.position += Vector3.up;
        mpSlider = mpSlider.transform.GetChild(0).gameObject;
    }

    private void OnDestroy()
    {
        Destroy(mpSlider);
        if(Player.Instance != null)
        {
            Player.Instance.population--;
        }
    }

    protected void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        InitTargetList();
        if (isAttack && monsters.Count > 0)
        {
            StartCoroutine(AttackDelayCo());
            Attack(SetTarget());
        }

        if (isIncomeMp)
        {
            StartCoroutine(IncomeMpDelayCo());
            IncomeMp();
        }
    }

    protected IEnumerator AttackDelayCo()
    {
        isAttack = false;
        yield return new WaitForSeconds(status.atkSpeed);
        isAttack = true;
    }

    protected IEnumerator AttackDelayCo(float coolTime)
    {
        isAttack = false;
        yield return new WaitForSeconds(coolTime);
        isAttack = true;
    }



    protected IEnumerator IncomeMpDelayCo()
    {
        isIncomeMp = false;
        yield return incomeMpDelay;
        isIncomeMp = true;
    }

    protected void IncomeMp()
    {
        if(status.mp >= status.maxMp)
        {
            status.mp = status.maxMp;
            return;
        }
        status.mp += status.recoveryMp;
        
        mpSlider.GetComponent<Slider>().value = (float)status.mp / (float)status.maxMp;
    }

    // CalDamage 끝난 후의 데미지 리턴
    public virtual int GetDamage()
    {
        return status.atk;
    }

    public virtual int GetSkillDamage()
    {
        return status.atk;
    }

    protected virtual void Attack(GameObject targetObj)
    {
        
        if(targetObj.TryGetComponent<Monster>(out var monster))
        {
            
            animator.SetTrigger("isAttack");
            monster.TakeDamage(GetDamage());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Monster monster;
        if(other.gameObject.TryGetComponent<Monster>(out monster))
        {
            monsters.Add(monster);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Monster monster;
        if (other.gameObject.TryGetComponent<Monster>(out monster))
        {
            InitTargetList();
            monsters.RemoveAt(0);
        }
    }
}
