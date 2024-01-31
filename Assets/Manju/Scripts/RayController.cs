using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RayController : MonoBehaviour
{
    Ray ray;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        // shoot raycast && canvas click exception 
        

    }

    void CreateTower()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 지점으로부터 레이를 쏨.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // 레이에 부딪힌값이 존재 시
            {                
                if (hit.collider.gameObject.TryGetComponent(out Tile tile)) // 부딪힌 콜라이더가 Tile을 가지고 있다면
                {
                    TowerManager.Instance.SetSelectTile(tile); // 30 ~ 42 타워 설치과정
                    UiManager.Instance.TowerOptionUi(false);
                    if (tile.towerObj == null && tile.isBuildAble)
                    {
                        UiManager.Instance.TowerRotationSelectUi(false);
                        UiManager.Instance.TowerJobSelectUi(true);
                        tile.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    }
                    else if (tile.towerObj != null && tile.isBuildAble)
                    {
                        TowerManager.Instance.selectTower = tile.towerObj.GetComponent<Tower>();
                        UiManager.Instance.TowerOptionUi(true);
                    }
                }
            }
        }
    }
}
