using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerType m_Player = PlayerType.P1;
    [SerializeField] private InputManager m_InputManager;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        m_InputManager.InputGroupEvent(m_Player);
    }


}
