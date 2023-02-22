using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName ="itme",fileName ="item/card")]
public class CardItem : ScriptableObject
{
  	public int num;
	public int cost;
	public int range ;
	public int minattack;
	public int maxattack;
   public int shield;

   public string _name;
   public string explain ; 

   public Sprite Card_Image ;



}
