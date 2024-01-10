using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterSpawn : MonoBehaviour
{
    //지연시간 설정
    public float spawnDelay;

    // 몬스터의 개수
    public List<int> monsterCountList;

    // 몬스터리스트 선언
    // 몬스터의 종류
    public List<GameObject> monsterList; // = new List<GameObject>();

    //이동포인트 선언
    public List<Transform> checkPoint;
    public static List<Transform> CheckPoint = null;

    public List<Vector3> angleList;

    //몬스터 리스트에 있는 몬스터가 다 소환하게 0을 넣음
    int currentIndex = 0;

    //포인트변수
    public GameObject spawn;
    public GameObject spawnObj;


    void Start()
    {
        //스폰위치를 테그로 관리
        spawn = GameObject.FindWithTag("spawn");

        // 스폰 딜레이와 마릿수 정하기, 임의의 값임으로 나중에 변경해줘야함
        spawnDelay = 1.0f;

        CheckPoint = checkPoint;
        //몬스터리스트에 있는 몬스터를 일정시간만큼 지연시키기
        StartCoroutine(MonsterSpawnCo(0));
    }


    // 몬스터 인스턴스 찍을때
    // 그 몬스터에서 체크포인트를 리스트로 가지고 있고
    // 여기에서 체크포인트를 몬스터 한테 넘겨줘
    IEnumerator MonsterSpawnCo(int waveRound)
    {
        // true = 라운드수 조정해줄 것
        while (monsterList.Count > waveRound)
        {
            // 현재 소환한 몬스터 수 < 총 소환할 몬스터 수
            while(currentIndex < monsterCountList[waveRound])
            {
                // 몬스터 소환 간격
                yield return new WaitForSeconds(spawnDelay);
                //포인트 변수에 몬스터 리스트에 있는 몬스터를 소환시키기, spawn에 위치를 받아와서 소환
                Vector3 createPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                spawnObj = Instantiate(monsterList[waveRound]);
                spawnObj.transform.position = createPos;
                spawnObj.transform.LookAt(checkPoint[0]);
                spawnObj.transform.localEulerAngles = new Vector3(spawnObj.transform.localEulerAngles.x, 90, -90);
                spawnObj.GetComponent<Monster>().checkPoint = checkPoint;
                currentIndex++;
            }
            // 몬스터수 초기화
            currentIndex = 0;
            // 다음 라운드
            waveRound += 1;
            // 다음 웨이브까지 걸리는 시간
            yield return new WaitForSeconds(5.0f);
        }
    }
}
