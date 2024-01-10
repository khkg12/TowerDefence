using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 230901 made by 지호준


// !! TODO_LIST 
// 해당 인터페이스에서 구현해야 하는 것들은 '공격과 관련된 기본적 기능' 입니다.
// 생각 나는 것들은 대충 끄적여 봤지만, 조금 더 필요하다고 생각하시는 부분은 직접 수정해 주지 마시고
// 카톡방에 올려서 말씀해 주시면 감사하겠습니다. interface를 받은 클래스 또한 같이 수정이 필요해 지기 때문입니다.

   

public interface IAttackAble
{
    float CalDamage(int damage); // private
    float GetDamage(); // return CalDamage();

    // 향후 추가 예정
}