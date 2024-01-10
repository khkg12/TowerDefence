using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster
{
    private new void Update()
    {
        base.Update();
        if(monsterInfo.hp <= 0)
        {
            SoundManager.Instance.bgmScene = SoundManager.BgmScene.Win;
            SoundManager.Instance.BgmPlay(SoundManager.Instance.bgmScene);
            SceneController.Instance.SceneLoader("Ending");
        }
    }
}
