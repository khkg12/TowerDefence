using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 230901 made by 지호준

// interface 입니다. (인터페이스 명명 규칙은 CamelCase에 ~~ Able 같은 식으로 작성하시는게 좋습니다.)
// 함수의 선언은 하지만, 직접 정의는 하지 않아서 해당 정의는 이걸 받는 친구가 직접 구현하면 완성입니다.

// !! TODO_LIST 설명을 한번 하겠지만, 제 생각에는 공격을 하는 soldier 클래스와
// 돈과 관련된 일을 하게 되는 famer 클래스를 나누는 것이 좋다는 생각이 들었습니다. 그래서
// 돈을 얻을 수 있게 끔 하는 함수들을 구현해야 함을 알리는 인터페이스인 IncomeAble을 구현하게 되었습니다.


interface IncomeAble
{

    void RaiseIncome();
    void DownIncome();

}
