using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Tower
{

    [SerializeField] int incomeValue;
    [SerializeField] int maxPopulationValue;

    public Sprite skillImage;

    private void Start()
    {
        Player.Instance.income += incomeValue;
        Player.Instance.maxPopulation += maxPopulationValue;
    }

    private void OnDestroy()
    {
        if(Player.Instance != null)
        {
            Player.Instance.income -= incomeValue;
            Player.Instance.maxPopulation -= maxPopulationValue;
        }
    }
}
