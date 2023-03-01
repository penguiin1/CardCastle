// enum을 모아놓은 class
public class Define
{
    public enum Scene
    {
        Unknown,
        Lobby,
        Game,
    }
    public enum Sound
    {
       Bgm,
       Effect,
       MaxCount,
    }
     
    
    public enum UIEvent
    {
        Click,
        Drag,
    }
    

    public enum PlayerState
    {
       Moving,
       Attack,

       DoorChocing,

       NpcChoicing,

       CardChoicing,

       WeaponChoicing, 
    
    }
   

     public enum DungeonType
     {
        Battle,
        NonBattle,

     }

        public enum DungeonChoiceAppear
     {
        Enter,
        After,

        None,

     }


    
}
