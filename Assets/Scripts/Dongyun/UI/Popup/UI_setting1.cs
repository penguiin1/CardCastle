using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UI_setting1 : UI_Popup
{

    public Slider BgmSlider ;
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
     
       BgmSlider.value  = Managers.Game.BgmVolValue ;
        SfxSlider.value = Managers.Game.SfxVolValue ;
    
     
   }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Button ExitButton = GetButton((int)Buttons.Exit);
  

        BgmSlider.value  = Managers.Game.BgmVolValue ;
        SfxSlider.value = Managers.Game.SfxVolValue ;

         Managers.Sound._audioSources[(int)Define.Sound.Bgm].volume = BgmSlider.value ;
         Managers.Sound._audioSources[(int)Define.Sound.Effect].volume = SfxSlider.value ;
        
      

       
    }


    public void onclickexit( )
    {  Debug.Log("설정창 닫기!") ;
        Managers.UI.ClosePopupUI(this);
    }

    public void onBgmVolChange()
    {        
             
               Managers.Game.BgmVolValue  = BgmSlider.value ;
                Managers.Sound._audioSources[(int)Define.Sound.Bgm].volume = BgmSlider.value ;
    }

     public   void onSfxVolChange()
    {         
             
               Managers.Game.SfxVolValue  =  SfxSlider.value ;
                Managers.Sound._audioSources[(int)Define.Sound.Effect].volume = SfxSlider.value ;
    }

    
}
