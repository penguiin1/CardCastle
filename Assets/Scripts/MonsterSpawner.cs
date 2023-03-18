using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Monster monsterPrefab;

    public MonsterData[] monsterDatas;
    public Transform spawnPoint;

    public List<Monster> monsters_right = new List<Monster>();
    public List<Monster> monsters_left = new List<Monster>();

    private void Start()
    {
        CreateMonsterRight();  // 게임 시작할 때 몬스터 생성 (오른쪽)
        CreateMonsterLeft() ;
    }

    private void Update()
    {
        // 게임오버 상태일 때는 생성하지 않음
    }

    // 플레이어 오른쪽에 몬스터 스폰
    public void CreateMonsterRight()
    {
        Monster monster = Instantiate(monsterPrefab, spawnPoint.position + new Vector3(10f, 0, 0), spawnPoint.rotation);
        monsters_right.Add(monster);
    }

    // 플레이어 왼쪽에 몬스터 스폰
    public void CreateMonsterLeft()
    {
        Monster monster = Instantiate(monsterPrefab, spawnPoint.position + new Vector3(-10f, 0, 0), spawnPoint.rotation);
        monster.GetComponent<SpriteRenderer>().flipX = true;
        monsters_left.Add(monster);
    }
}
