using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    public event Action<PlayerControl> OnShootEvent;

    [SerializeField] private PlayerType m_Player = PlayerType.P1;
    [SerializeField] private Tilemap m_Tilemap;
    [SerializeField] private int m_TopTilemap = 4;
    [SerializeField] private int m_ButtonTilemap = -4;
    [SerializeField] private float shootCd = .5f;

    private Vector3Int m_CurrentPlayerPosition;

    public PlayerType Player { get => m_Player; set => m_Player = value; }

    public bool IsCd { get; private set; }


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
        if (IsCd) { return; }

        OnShootEvent?.Invoke(this);

        StartCoroutine(coolDown());
    }

    private IEnumerator coolDown()
    {
        IsCd = true;
        yield return new WaitForSeconds(shootCd);
        IsCd = false;
    }

}
