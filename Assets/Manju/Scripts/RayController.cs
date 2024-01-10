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
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Tile tile;

                if (hit.collider.gameObject.TryGetComponent<Tile>(out tile))
                {
                    TowerManager.Instance.SetSelectTile(tile);
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
