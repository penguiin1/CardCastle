using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dungeon",fileName ="Dungeon")]
public class Dungeon : ScriptableObject
{
    public int Dungeon_num ;

    public string Dungeon_name ;

    public Define.DungeonType  _type ;

   public Define.DungeonChoiceAppear _selector ;

    public string Dungeon_Explain ;

    public List<string> Room_AnswerList ;






   public Transform spawnpos ;
    
}
