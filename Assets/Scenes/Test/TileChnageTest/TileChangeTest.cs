using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChangeTest : MonoBehaviour
{
    [SerializeField]
    private GameManager gm = null;
    [SerializeField]
    private Tilemap map = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var hit = Physics2D.Raycast(ray.GetPoint(0), ray.direction);

            if (hit.collider != null)
            {
                var coor = map.WorldToCell(hit.point);
                Debug.Log(coor);
                gm.UpdateTile(coor, PlayerType.P2);
            }
        }
    }
}
