using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;
using DG.Tweening;




public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<TowerManager>();
            }
            return instance;
        }
    }
    private static TowerManager instance;

    public Tile selectTile;
    public Tower selectTower;

    public void BuyTower(Quaternion angle)
    {
        if (IsPopulation())
        {
            if (IsCostCheck(selectTower))
            {
                Player.Instance.Cost -= selectTower.GetCost();
                CreateTower(selectTower.gameObject, angle);
                UiManager.Instance.TowerJobSelectUi(false);
            }
            else
            {
                StartCoroutine(UiManager.Instance.FalseMessageCo("금화가 부족합니다."));
            }
        }
        else if(selectTower.TryGetComponent<Farmer>(out var tower))
        {
            if (IsCostCheck(tower))
            {
                Player.Instance.Cost -= tower.GetCost();
                CreateTower(tower.gameObject, angle);
                UiManager.Instance.TowerJobSelectUi(false);
            }
            else
            {
                StartCoroutine(UiManager.Instance.FalseMessageCo("금화가 부족합니다."));
            }
        }
        else
        {
            StartCoroutine(UiManager.Instance.FalseMessageCo("인구수가 부족합니다."));
        }
        UiManager.Instance.TowerRotationSelectUi(false);
    }

    private void CreateTower(GameObject tower, Quaternion angle)
    {
        Vector3 createPos = new Vector3(selectTile.transform.position.x, selectTile.transform.position.y, selectTile.transform.position.z - 1);
        selectTile.towerObj = Instantiate(tower,selectTile.transform);
        selectTile.towerObj.transform.DOScale(1, 1);
        selectTile.towerObj.transform.position = createPos;
        selectTile.towerObj.transform.localEulerAngles = angle.eulerAngles;
    }

    public void SellTower()
    {
        Player.Instance.Cost += (int)(selectTile.towerObj.GetComponent<Tower>().GetCost() * 0.7f); // 판매가 0.7
        Destroy(selectTile.towerObj);
    }

    public void UpgradeTower()
    {
        GameObject nextLevelObj = selectTile.towerObj.GetComponent<Tower>().nextLevelTower;
        if (IsCostCheck(nextLevelObj.GetComponent<Tower>()))
        {
            Player.Instance.Cost -= nextLevelObj.GetComponent<Tower>().GetCost();
            Quaternion createAngle = selectTile.towerObj.transform.localRotation;
            Destroy(selectTile.towerObj);
            CreateTower(nextLevelObj, createAngle);
        }
        else
        {
            StartCoroutine(UiManager.Instance.FalseMessageCo("금화가 부족합니다."));
        }
    }

    public bool IsCostCheck(Tower tower)
    {
        if (Player.Instance.Cost >= tower.GetCost())
        {
            return true;
        }
        return false;
    }

    public bool IsPopulation()
    {
        if (Player.Instance.population < Player.Instance.maxPopulation)
        {
            return true;
        }

        return false;
    }

    public void SetSelectTile(Tile tile)
    {
        selectTile = tile;
    }
}
 
