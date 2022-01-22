using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Tilemap m_Tilemap;
    [SerializeField] private PlayerControl m_PlayerControl;

    public void InputGroupEvent(PlayerType playerType)
    {
        if (playerType == PlayerType.P1)
        {
            Player1Input();
        }
        else if(playerType == PlayerType.P2)
        {
            Player2Input();
        }
    }

    private void Player1Input()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_PlayerControl.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_PlayerControl.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

        }
    }

    private void Player2Input()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_PlayerControl.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_PlayerControl.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {

        }
    }
}
