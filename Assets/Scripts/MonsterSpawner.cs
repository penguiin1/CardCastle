using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Monster monsterPrefab;

    public MonsterData[] monsterDatas;
    public Transform spawnPoint;

    private List<Monster> monsters = new List<Monster>();

    private void Start()
    {
        CreateMonster();
    }
    private void Update()
    {
        //게임오버 상태일 때는 생성하지 않음
    }

    private void CreateMonster()
    {
        Monster monster = Instantiate(monsterPrefab, spawnPoint.position + new Vector3(10f,0,0), spawnPoint.rotation);
    }
}
