using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameScene : UI_Scene
{
    void start()
    {    
      




       
    }
    public override void Init()
    {
        base.Init();
        Managers.Sound.Play("Prefabs/Sounds/BGM_Ingame",Define.Sound.Bgm) ; 
    }


}
