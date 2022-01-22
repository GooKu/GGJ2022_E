using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Tilemap m_Tilemap;

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

        }
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

        }
    }

    private void Player2Input()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {

        }
    }

    private void Move(Vector2 direction)
    {
        
    }
}
