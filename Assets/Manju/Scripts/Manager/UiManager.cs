using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//230905 지호준 comment
//  현재 uimanager가 가지고 있는 prefab이 없음 아마 script만 받아서 그런 듯 
//  UI manager의 경우 성미가 이미 만든 틀에 따라서 변경이 필요해 보임
//  Ui manager 만들 때는 옆에 성미 두고 개발 필요 요망


public class UiManager : MonoBehaviour
{
    public List<GameObject> towerJobBtnList;
    public List<GameObject> towerRotationBtnList;
    public List<GameObject> towerOptionBtnList;
    public List<GameObject> gameOptionBtnList;

    public TextMeshProUGUI falseMessage;
    public TextMeshProUGUI skillOptionText;
    public TextMeshProUGUI skillDamageText;

    public static UiManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UiManager>();
            }
            return instance;
        }
    }
    private static UiManager instance;

    [SerializeField] List<TextMeshProUGUI> textMeshProUGUI;

    public GameObject selectTileUiObj;
    public GameObject currentSelectTile;

    private void Update()
    {
        textMeshProUGUI[0].text = Player.Instance.Life.ToString();
        textMeshProUGUI[1].text = Player.Instance.Cost.ToString();
        textMeshProUGUI[2].text = Player.Instance.population.ToString() + " / " + Player.Instance.maxPopulation.ToString();
    }

    public void TileSelectUi(bool isShow)
    {
        if(currentSelectTile != null)
        {
            Destroy(currentSelectTile);
        }

        if(isShow)
        {
            currentSelectTile = Instantiate(selectTileUiObj, TowerManager.Instance.selectTile.transform.position, Quaternion.identity);
            currentSelectTile.transform.position += Vector3.back * 3;
        }
    }

    public void TowerJobSelectUi(bool isShow)
    {
        towerJobBtnList[0].transform.parent.gameObject.SetActive(isShow);
        TileSelectUi(isShow);
    }

    public void TowerRotationSelectUi(bool isShow)
    {

        TowerJobSelectUi(false);
        towerRotationBtnList[0].transform.parent.position = CurrentUiPosition();
        for (int i = 0; i < towerRotationBtnList.Count;i++)
        {
            towerRotationBtnList[i].SetActive(isShow);
        }
    }

    public void TowerOptionUi(bool isShow)
    {
        towerOptionBtnList[0].transform.parent.position = CurrentUiPosition();
        int j = 0;
        if (isShow)
        {
            // 타워옵션 ui가 켜지는 경우는 타워가 존재 할때만 켜진다
            // 그러므로 isShow가 true일 경우는 towerObj가 null가 되지 않는다
            // 위에 if문에 같이 쓰게되면 타워옵션을 끄는 경우에도 towerObj의 존재유무를 판단하기 때문에
            // 널레퍼런스 오류가 발생 할 수 있다.
            Tower selectTower = TowerManager.Instance.selectTile.towerObj.GetComponent<Tower>();
            if (selectTower.status.towerSkills.Count > 0)
            {
                Skill towerSkill = selectTower.status.towerSkills[0];

                towerOptionBtnList[2].GetComponent<Image>().sprite = towerSkill.skillImage;
                skillOptionText.text = towerSkill.skillOption;
                skillDamageText.text = towerSkill.skillDamageText;
            }
            else
            {
                towerOptionBtnList[2].GetComponent<Image>().sprite = selectTower.GetComponent<Farmer>().skillImage;
                skillOptionText.text = "열심히 금화를 채굴합니다.";
                skillDamageText.text = "인구수를 늘려줍니다.";
            }

            if (selectTower.nextLevelTower == null)
            {
                j = 1;
            }
        }
        for (int i = j; i < towerOptionBtnList.Count; i++)
        {
            towerOptionBtnList[i].SetActive(isShow);
        }
    }

    // 오디오 조절이랑 게임일시정지 하는 ui 추가
    public void GameOptionUi(bool isShow)
    {
        if (isShow)
        {
            gameOptionBtnList[0].SetActive(isShow);
            Time.timeScale = 0.0f;
        }
        else
        {
            gameOptionBtnList[0].SetActive(isShow);
            Time.timeScale = 1.0f;
        }
    }

    Vector3 CurrentUiPosition()
    {
        Vector3 tempPos = TowerManager.Instance.selectTile.transform.position;
        Vector3 uiScreenPos = Camera.main.WorldToScreenPoint(tempPos);

        return uiScreenPos;
    }

    public IEnumerator FalseMessageCo(string msg)
    {
        falseMessage.transform.parent.gameObject.SetActive(true);
        falseMessage.text = msg;
        yield return new WaitForSeconds(0.8f);
        falseMessage.transform.parent.gameObject.SetActive(false);
    }
}
