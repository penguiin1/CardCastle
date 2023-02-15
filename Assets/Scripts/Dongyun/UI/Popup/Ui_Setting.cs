using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ui_Setting : UI_Popup
{
 
 public GameObject go ;
 public Slider BgmSlider;
 public Slider SfxSlider ;
 	enum GameObjects
	{
		BgmSetting,
    SfxSetting,
	}
    enum Buttons
	{
		Exit
	}

  void start()
  {   
          Init() ;
    
  }

  void Update()
  {
      BgmSlider.value= Managers.Game.BgmVolValue ;
        SfxSlider.value= Managers.Game.SfxVolValue ;   
  }
    public override void Init()
    {
        
        base.Init();
          Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Button ExitButton = GetButton((int)Buttons.Exit);
        
       
       
    }


   public void BgmValueChange()
    { 
       //Slider BgmSlider = Get<GameObject>((int)GameObjects.BgmSetting).GetComponent<Slider>();
       Managers.Game.BgmVolValue =BgmSlider.value ;
        Managers.Sound._audioSources[(int)Define.Sound.Bgm].volume =  Managers.Game.BgmVolValue ;
    }

       public void SfxValueChange()
    {  
      //  Slider SfxSlider = Get<GameObject>((int)GameObjects.SfxSetting).GetComponent<Slider>();
       Managers.Game.SfxVolValue =SfxSlider.value ;
        Managers.Sound._audioSources[(int)Define.Sound.Effect].volume =  Managers.Game.SfxVolValue ;
    }


    public  void ExitSetting()
    {
         Managers.UI.ClosePopupUI(this) ;

       
    }
}

  
