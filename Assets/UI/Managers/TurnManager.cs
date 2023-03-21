using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    
    public Player player;
    public MonsterSpawner spawner;

    public bool isPlayerTurnStart = true;
    public bool isMonsterTurnStart = false;

    public int monster_create_prob;  // 몬스터 생성 확률 (0~100)

    // 턴 넘기기 용 변수
    int monsterCountRight = 0;  // 턴이 끝난 몬스터의 수
    int currentTotalMonstersRight = 0;  // 현재 총 몬스터의 수
    int monsterCountLeft = 0;
    int currentTotalMonstersLeft = 0;

    // 몬스터 근접 경고
    public GameObject warningLeft;
    public GameObject warningRight;

    string currentTurn;

    public void Start()
    {
        monster_create_prob = 20;  // 몬스터 생성 확률 설정
    }
    
    public void Update()
    {
        TurnUpdate() ;
    }

 
    public void TurnUpdate()
    {

        if (isPlayerTurnStart)
        {
            isPlayerTurnStart = false;
            currentTurn = "player";
            TurnControl();
        }

        if (isMonsterTurnStart)
        {
            isMonsterTurnStart = false;
            currentTurn = "monster";
            TurnControl();
        }
    }

    
    public void TurnControl()
    {
        if (currentTurn == "monster")  // 몬스터의 턴이 시작될 때, 몬스터 스폰 & 리스트에서 몬스터 제거
        {
            // 죽은 몬스터 리스트에서 삭제
            foreach (Monster monster in spawner.monsters_left)
            {
                if (monster.dead)
                {
                    spawner.monsters_left.Remove(monster);  // 리스트에서 제거
                    Destroy(monster.gameObject);  // 몬스터 게임오브젝트 파괴
                    break;  // 몬스터 1개만 리스트에서 지워도 되므로 반복문을 빠져나옴
                }
            }

            foreach (Monster monster in spawner.monsters_right)
            {
                if (monster.dead)
                {
                    spawner.monsters_right.Remove(monster);
                    Destroy(monster.gameObject);
                    break;
                }
            }
        }

        // 플레이어와 몬스터의 만남 여부 설정
        float player_pos = player.transform.position.x;
        foreach (Monster monster in spawner.monsters_left)
        {   
            float distance = Mathf.Abs(player_pos - monster.transform.position.x);
            if (distance == 2.5f)
            {
                player.meet_monster_left = monster;
                player.is_meet_left = true;
                monster.is_meet_player = true;
            }
        }

        foreach (Monster monster in spawner.monsters_right)
        {
            float distance = Mathf.Abs(player_pos - monster.transform.position.x);
            if (distance == 2.5f)
            {
                player.meet_monster_right = monster;
                player.is_meet_right = true;
                monster.is_meet_player = true;
            }
        }

        if (currentTurn == "player")
        {
            setWarning();

            player.StartTurn();
        }
        else  // 플레이어의 턴이 끝나면 여기로 들어옴
        {
            setWarning();

            if ((spawner.monsters_left.Count == 0) && (spawner.monsters_right.Count == 0))  // 몬스터가 하나도 없는 경우
                EndMonsterTurn();  // 바로 Player의 턴 시작
            else  // 몬스터가 하나 이상 있는 경우
            {
                monsterCountLeft = 0;
                currentTotalMonstersLeft = spawner.monsters_left.Count;
                monsterCountRight = 0;
                currentTotalMonstersRight = spawner.monsters_right.Count;
                StartCoroutine(StartMonsterTurn());
            }
        }
    }

    IEnumerator StartMonsterTurn()  // 몬스터가 있을때만 호출됨
    {
        yield return new WaitForSeconds(0.5f);

        if (spawner.monsters_left.Count == 0)
        {
            left_monsters = false;
            right_monsters = true;
            spawner.monsters_right[0].StartTurn();
        }
        else
        {
            left_monsters = true;
            right_monsters = false;
            spawner.monsters_left[0].StartTurn();
        }
        // 한 몬스터의 모든 행동이 끝나면 다음 몬스터의 행동이 시작됨
    }

    bool left_monsters = false;
    bool right_monsters = false;

    public void MonsterControlLeft()
    {
        monsterCountLeft++;

        if (monsterCountLeft >= currentTotalMonstersLeft)
        {
            left_monsters = false;
            right_monsters = true;

            if (spawner.monsters_right.Count != 0)
                spawner.monsters_right[0].StartTurn();
            else
                EndMonsterTurn();
        }
        else
            spawner.monsters_left[monsterCountLeft].StartTurn();
    }

    public void MonsterControlRight()
    {
        monsterCountRight++;

        if (monsterCountRight >= currentTotalMonstersRight)  // 모든 몬스터의 턴이 끝난 경우 - 몬스터의 턴 끝
        {
            right_monsters = false;
            EndMonsterTurn();
        }
        else
            spawner.monsters_right[monsterCountRight].StartTurn();
    }

    void EndMonsterTurn()
    {
        // 스포너 위치에 몬스터가 존재하는지 검사
        // 왼쪽
        bool spawner_monster_exist = false;  // 스포너 위치에 몬스터가 존재하는지 여부
        float current_spawn_point = player.transform.position.x - 10f;
        foreach (Monster monster in spawner.monsters_left)
        {
            float monster_pos = monster.transform.position.x;
            if (monster_pos == current_spawn_point)
            {
                spawner_monster_exist = true;
                break;
            }
        }
        // 확률에 따라 몬스터 생성, 스포너의 위치에 몬스터가 존재하면 생성하지 않음
        int temp = Random.Range(1, 101);
        if ((temp <= monster_create_prob) && !spawner_monster_exist)
            spawner.CreateMonsterLeft();

        // 오른쪽
        spawner_monster_exist = false;
        current_spawn_point = player.transform.position.x + 10f;
        foreach (Monster monster in spawner.monsters_right)
        {
            float monster_pos = monster.transform.position.x;
            if (monster_pos == current_spawn_point)
            {
                spawner_monster_exist = true;
                break;
            }
        }
        temp = Random.Range(1, 101);
        if ((temp <= monster_create_prob) && !spawner_monster_exist)
            spawner.CreateMonsterRight();

        isPlayerTurnStart = true;  // 플레이어 턴 시작
    }

    void setWarning()  // 몬스터 근접 경고창 띄우기
    {
        bool is_monster_left = false;
        bool is_monster_right = false;
        float player_pos = player.transform.position.x;
           
        // 왼쪽
        foreach (Monster monster in spawner.monsters_left)
        {
            float monster_pos = monster.transform.position.x;

            if (player_pos - monster_pos == 2.5f * 4)
            {
                is_monster_left = true;

                warningLeft.SetActive(true);
                break;
            }
        
        }
        if (!is_monster_left)
        {
            warningLeft.SetActive(false);
        }

        // 오른쪽
        foreach (Monster monster in spawner.monsters_right)
        {
            float monster_pos = monster.transform.position.x;

            if (monster_pos - player_pos == 2.5f * 4)
            {
                is_monster_right = true;

                warningRight.SetActive(true);
                break;
            }
               
        }
        if (!is_monster_right)
        {
            warningRight.SetActive(false);
        }
    }
}


