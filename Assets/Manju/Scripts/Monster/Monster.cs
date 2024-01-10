using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//몬스터 속성 선언
[System.Serializable]
public class MonsterInfo
{
    public string name;
    public int hp;
    public int maxHp;
    public int atk;
    public float speed;

    [SerializeField]
    public int currentCheckPoint;
}

public class Monster : MonoBehaviour
{
    //몬스터 속성 상속
    public MonsterInfo monsterInfo = new MonsterInfo();
    public List<Transform> checkPoint;
    protected Animator animator;
    protected Renderer renderer;
    protected WaitForSeconds hitAniDelay;

    public AudioClip dieClip;

    Slider hpBar;

    float hitAniTimer;

    public float moveWeight;
    public bool isDie;

    public int Hp
    {
        get => monsterInfo.hp;
        set
        {
            monsterInfo.hp = value;
            if (monsterInfo.hp <= 0)
            {
                hpBar.gameObject.SetActive(false);
                Die();
            }
        }
    }

    public void Start()
    {
        hitAniTimer = 0.1f;
        monsterInfo.currentCheckPoint = 0;
        animator = GetComponent<Animator>();
        renderer = GetComponentInChildren<Renderer>();
        hitAniDelay = new WaitForSeconds(hitAniTimer);
        isDie = false;

        hpBar = transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        hpBar.value = 1;
            
    }

    public void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        Movement(checkPoint[monsterInfo.currentCheckPoint], isDie);
    }

    // 몬스터의 움직임
    public void Movement(Transform target, bool isDie)
    {
        if(isDie)
            return;

        int dir = 1;
        transform.position = Vector3.MoveTowards(transform.position , target.position , monsterInfo.speed);
        moveWeight += monsterInfo.speed;
        if (transform.position == target.transform.position)
        {
            monsterInfo.currentCheckPoint++;
            if(monsterInfo.currentCheckPoint >= checkPoint.Count)
            {
                Player.Instance.Life -= monsterInfo.atk;
                Destroy(gameObject);
                return;
            }
            transform.LookAt(checkPoint[monsterInfo.currentCheckPoint]);

            if (checkPoint[monsterInfo.currentCheckPoint].position.x - transform.position.x < 0)
            {
                dir = -1;
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90 * dir, -90 * dir);
        }
    }

    // 현재 체크 포인트리턴
    public int GetCurrentCheckPoint()
    {
        return checkPoint.Count;
    }

   public float GetDistance()
   {
        return moveWeight;
   }


    //몬스터 파괴 함수
    public virtual void Die()
    {
        isDie = true;
        AudioSource.PlayClipAtPoint(dieClip, transform.position);
        animator.SetTrigger("isDie");
        StartCoroutine(DestroyCo());
    }

    IEnumerator DestroyCo()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    //플리이어가 몬스터를 때리는 함수
    public virtual void TakeDamage(int attackDamage)
    {

        Hp -= attackDamage;
        hpBar.value = (float)((float)Hp / (float)monsterInfo.maxHp);
        StartCoroutine(TakeDamageImageCo());
    }

    IEnumerator TakeDamageImageCo()
    {
        renderer.material.color = Color.red;
        yield return hitAniDelay;
        renderer.material.color = Color.white;
    }
}
