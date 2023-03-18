using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : LivingEntity
{
       public TurnManager _Turn ;
    private LivingEntity targetEntity;
    public float damage = 5f;
   
   Direction direction;

    public bool is_meet_player = false;

    enum Direction  // 플레이어와 비교한 몬스터의 위치
    {
        Left,  // 0
        Right  // 1
    }


    private bool hasTarget
    {
        get
        {
            if(targetEntity != null && !targetEntity.dead)
            {
                return true;
            }
            return false;
        }
    }

    private void Start()
    {
        _Turn = GameObject.FindObjectOfType<TurnManager>() ;
        float player_pos = _Turn.player.transform.position.x;
        

        if (transform.position.x < player_pos)
            direction = Direction.Left;
        else
            direction = Direction.Right;
    }

    public void Setup(MonsterData monsterData)
    {

    }

    public override void Die()
    {
        base.Die();

        if (direction== Direction.Left) 
           _Turn.player.is_meet_left = false;
        else
            _Turn.player.is_meet_right = false;
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
    }

    public void StartTurn()
    {
        if (is_meet_player)  // 몬스터가 플레이어를 만나면 움직이지 않고 공격
        {
            AttackPlayer();
        }
        else  // 몬스터가 플레이어를 만나지 않은 경우
        {
            bool is_move = true;

            if (direction == Direction.Left)
            {
                foreach (Monster monster in _Turn.spawner.monsters_left)  // 왼쪽에 몬스터가 있으면 움직이고, 아니면 움직이지 않음
                {
                    if (monster == this)  // 자기 자신은 제외
                        continue;
                    else
                    {
                        float distance = transform.position.x - monster.transform.position.x;
                        if (distance == -2.5f)
                        {
                            is_move = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (Monster monster in _Turn.spawner.monsters_right)  // 왼쪽에 몬스터가 있으면 움직이고, 아니면 움직이지 않음
                {
                    if (monster == this)  // 자기 자신은 제외
                        continue;
                    else
                    {
                        float distance = transform.position.x - monster.transform.position.x;
                        if (distance == 2.5f)
                        {
                            is_move = false;
                            break;
                        }
                    }
                }
            }


            if (is_move)
                Move();  // Move() 함수 내부에서 EndTurn() 함수를 호출함
            else
                EndTurn();
        }
    }

    // 현재 몬스터의 동작을 끝내면서 다음 몬스터의 동작을 시작함
    public void EndTurn()
    {
        if (direction == Direction.Left) 
            _Turn.MonsterControlLeft();
        else
            _Turn.MonsterControlRight(); 
    }

    void Move()
    {
        if (direction == Direction.Left)
            transform.Translate(2.5f, 0, 0);
        else
            transform.Translate(-2.5f, 0, 0);

        EndTurn();
    }

    void AttackPlayer()
    {
        _Turn.player.OnDamage(1f);

        EndTurn();
    }
}
