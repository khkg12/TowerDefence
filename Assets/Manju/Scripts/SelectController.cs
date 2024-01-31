using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.EventSystems;



public class SelectController : MonoBehaviour
{
    Tile[] tiles;

    float leftX, leftY, rightX, rightY;
    float width, height;

    float halfWidth;
    float halfHeight;

    const int TILE_WIDTH = 21;
    const int TILE_HEIGHT = 10;

    Vector3 leftMapPos = new Vector3(-10, -4.55f, 0); // 맵 맨끝 큐브좌표
    void Start()
    {
        tiles = new Tile[TILE_WIDTH * TILE_HEIGHT];
        for(int i = 0; i <  tiles.Length; i++)
        {
            tiles[i] = new Tile();
        }

        leftX = Camera.main.transform.position.x - Camera.main.orthographicSize * (Screen.width / Screen.height);
        leftY = Camera.main.transform.position.y - Camera.main.orthographicSize;
        rightX = Camera.main.transform.position.x + Camera.main.orthographicSize * (Screen.width / Screen.height);
        rightY = Camera.main.transform.position.y + Camera.main.orthographicSize;

        width = (rightX - leftX) / TILE_WIDTH;
        halfWidth = width / 2;
        height = (rightY - leftY) / TILE_HEIGHT;
        halfHeight = height / 2;
        Debug.Log(width + " / " + height);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CreateTower();
        }
    }

    void CreateTower()
    {
        int x, y;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x -= leftMapPos.x - halfWidth;
        mousePos.y -= leftMapPos.y - halfHeight;
        x = (int)(mousePos.x / width);
        y = (int)(mousePos.y / height);
        
        Debug.Log($"{x}와 {y}");
        int index = y * TILE_WIDTH + x; // 클릭한좌표의 타워가 몇번째 타워인지 1,2 이면 10*10일 때 2 * 10 + 1 = 21번째        
        Debug.Log("설치타일 인덱스 : " + index);
        if (tiles[index].isBuildAble) // 설치가 가능한 타일인지 체크
        {
            // UiManager.Instance.TowerOptionUi(false);
            TowerManager.Instance.SetSelectTile(tiles[index]);
            SetSelectTilePos(x, y); // 마우스클릭 지점의 가운데를 설치할 타일의 위치로 넘김
            if (tiles[0].towerObj == null)
            {
                // UiManager.Instance.TowerRotationSelectUi(false);
                UiManager.Instance.TowerJobSelectUi(true);
            }
            else
            {
                // 설치되있는 타워 클릭시 뜨는 UI
            }
        }
    }

    public void SetSelectTilePos(int x, int y)
    {        
        TowerManager.Instance.selectTile.transform.position = new Vector3(x * width + halfWidth + leftMapPos.x, y * height + halfHeight + leftMapPos.y, 0);        
    }
}
