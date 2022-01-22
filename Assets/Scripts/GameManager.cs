using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map = null;

    private int p1Score;
    private int p2Score;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        p1Score = p2Score = 9 * 8;
    }

    public void UpdateTile(Vector2Int pos, PlayerType player)
    {
        //TODO: update tile color
        if(player == PlayerType.P1)
        {
            p1Score += 1;
            p2Score -= 1;
            return;
        }

        p1Score -= 1;
        p2Score += 1;
    }
}
