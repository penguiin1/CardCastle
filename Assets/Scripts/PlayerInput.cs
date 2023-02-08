using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    void Start()
    {
        
    }
    public void PlayerRMove()
    {
        transform.Translate(2.5f, 0, 0);
    }
    public void PlayerLMove()
    {
        transform.Translate(-2.5f, 0, 0);
    }
}
