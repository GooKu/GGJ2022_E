using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map = null;
    [SerializeField]
    private TileBase p1Tile = null;
    [SerializeField]
    private TileBase p2Tile = null;

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

    public void UpdateTile(Vector3Int coor, PlayerType player)
    {
        var tile = map.GetTile(coor);
        var compareTile = player == PlayerType.P1 ? p1Tile : p2Tile;

        if(tile == compareTile) { return; }

        map.SetTile(coor, compareTile);

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
