using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : LivingEntity
{
    public bool is_meet_right = false;  // 몬스터를 만났는지 여부 (오른쪽)
    public bool is_meet_left = false;  // 몬스터를 만났는지 여부 (왼쪽)
    public Monster meet_monster_right = null;  // 만난 몬스터 객체 (오른쪽)
    public Monster meet_monster_left = null;  // 만난 몬스터 객체 (왼쪽)

    // 조작 버튼
    public Button left_btn;
    public Button right_btn;
    public Button attack_btn;
    public Button act_btn;

    bool is_meet_door = false;  // 플레이어가 문을 만났는지 여부

    // Start is called before the first frame update
    void Start()
    {
        act_btn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerRMove()
    {
        if (is_meet_right && is_meet_left)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.Translate(2.5f, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;

            EndTurn();
        }

    }
    public void PlayerLMove()
    {
        if (is_meet_right && is_meet_left)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.Translate(-2.5f, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;

            EndTurn();
        }
    }

    public void AttackMonster()
    {
        // 일단 왼쪽 오른쪽 둘 다 공격하게
        if (is_meet_left)
            meet_monster_left.OnDamage(50f);
        if (is_meet_right)
            meet_monster_right.OnDamage(50f);

        EndTurn();
    }

    public void ActBtnClicked()
    {
        print("문");
    }

    public void StartTurn()
    {
        print(health);

        if (is_meet_right && is_meet_left)  // 오른쪽과 왼쪽 모두 만났을 경우
        {
            left_btn.interactable = true;
            right_btn.interactable = true;
            attack_btn.interactable = true;
        }
        else if (is_meet_right || is_meet_left)  // 오른쪽이나 왼쪽 둘 중 하나라도 만났을 경우
        {
            left_btn.interactable = false;
            right_btn.interactable = false;
            attack_btn.interactable = true;
        }
        else  // 몬스터를 아예 만나지 않았을 경우
        {
            left_btn.interactable = true;
            right_btn.interactable = true;
            attack_btn.interactable = false;
        }

        
    }

    public void EndTurn()
    {
        left_btn.interactable = false;
        right_btn.interactable = false;
        attack_btn.interactable = false;

        GameManager.instance.isMonsterTurnStart = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Door")  // 문과의 충돌
        {
            act_btn.interactable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Door")  // 문과의 충돌
        {
            act_btn.interactable = false;
        }
    }
}
