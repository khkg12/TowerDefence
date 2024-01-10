using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }
    private static Player instance;


    public Player playerIns;
    public int Cost
    {
        get => cost;
        set
        {
            cost = value;
            if(cost <= 0)
            {
                cost = 0;
            }
        }
    }
    private int cost;

    public int income;
    public int population;
    public int maxPopulation;
    
    public int Life
    {
        get => life;
        set
        {
            life = value;
            if (life <= 0)
            {
                life = 0;
                SoundManager.Instance.bgmScene = SoundManager.BgmScene.GameOver;
                SoundManager.Instance.BgmPlay(SoundManager.Instance.bgmScene);
                SceneController.Instance.SceneLoader("GameOver");
            }
        }
    }

    private int life;


    public RayController rayController;

    [SerializeField]
    float timer;

    WaitForSeconds incomeTimer;

    IEnumerator GetIncomeCo()
    {
        while(true)
        {
            cost += income;
            yield return incomeTimer;
        }
    }

    void Start()
    {
        // 코스트 초기값 설정
        cost = 300;
        timer = 1;
        population = 0;
        maxPopulation = 3;
        life = 10;
        income = 10;
        incomeTimer = new WaitForSeconds(timer);

        StartCoroutine(GetIncomeCo());
    }
}
