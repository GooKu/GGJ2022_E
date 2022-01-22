using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerType m_Player = PlayerType.P1;
    [SerializeField] private InputManager m_InputManager;
    [SerializeField] private Tilemap m_Tilemap;
    [SerializeField] private int m_TopTilemap = 4;
    [SerializeField] private int m_ButtonTilemap = -4;

    private Vector3Int m_CurrentPlayerPosition;

    public PlayerType Player { get => m_Player; set => m_Player = value; }


    private void Start()
    {
        if(m_Player == PlayerType.P1)
        {

            m_CurrentPlayerPosition = new Vector3Int(-9, 0, 0);
            transform.position = m_Tilemap.GetCellCenterWorld(m_CurrentPlayerPosition);
        }
        else if(m_Player == PlayerType.P2)
        {
            m_CurrentPlayerPosition = new Vector3Int(6, 0, 0);
            transform.position = m_Tilemap.GetCellCenterWorld(m_CurrentPlayerPosition);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        m_InputManager.InputGroupEvent(m_Player);
    }

    public void MoveUp()
    {
        if(m_CurrentPlayerPosition.y < m_TopTilemap)
        {
            m_CurrentPlayerPosition = m_CurrentPlayerPosition + new Vector3Int(0, 1, 0);
            transform.position = m_Tilemap.GetCellCenterWorld(m_CurrentPlayerPosition);
        }
    }

    public void MoveDown()
    {
        if (m_CurrentPlayerPosition.y > m_ButtonTilemap)
        {
            m_CurrentPlayerPosition = m_CurrentPlayerPosition + new Vector3Int(0, -1, 0);
            transform.position = m_Tilemap.GetCellCenterWorld(m_CurrentPlayerPosition);
        }
    }

    public void Shoot()
    {
        Debug.Log(m_Player.ToString() + "Shooting");
    }

}
