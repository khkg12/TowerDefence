using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        //부모에있는 스타트를 먼저 시작하고 자식에 있는 스타트를 실행
        //base.Start();

        //스텀프 속성
        monsterInfo.name = "스텀프";
        monsterInfo.hp = 10;
        monsterInfo.speed = 0.1f;
        monsterInfo.atk = 1;

    }

}
