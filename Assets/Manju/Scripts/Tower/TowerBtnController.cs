using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBtnController : MonoBehaviour
{
    public GameObject selectObj;

    public void JobSelect()
    {
        TowerManager.Instance.selectTower = selectObj.GetComponent<Tower>();
        UiManager.Instance.TowerRotationSelectUi(true);
    }

    public void RotationSelect(int angle)
    {
        Quaternion rotation = Quaternion.Euler(0,angle, 0);
        TowerManager.Instance.BuyTower(rotation);
    }

    public void Sell()
    {
        TowerManager.Instance.SellTower();
        UiManager.Instance.TowerOptionUi(false);
    }

    public void Upgrade()
    {
        TowerManager.Instance.UpgradeTower();
        UiManager.Instance.TowerOptionUi(false);
    }

    public void Skill()
    {
        TowerManager.Instance.selectTile.towerObj.GetComponent<Tower>().UseSkill();
        UiManager.Instance.TowerOptionUi(false);
    }
}
