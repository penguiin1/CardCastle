using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/MonsterData", fileName ="MonsterData")]
public class MonsterData : ScriptableObject
{
    public float health = 100f;
    public float damage = 20f;
}
