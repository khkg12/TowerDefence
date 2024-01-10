using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : Monster
{
    // Start is called before the first frame update
    new void Start()
    {
        //부모에있는 스타트를 먼저 시작하고 자식에 있는 스타트를 실행
        base.Start();

        //슬라임 속성
        monsterInfo.name = "슬라임";
        monsterInfo.hp = 5;
        monsterInfo.atk = 1;
        monsterInfo.speed = 0.01f;


    }

}
