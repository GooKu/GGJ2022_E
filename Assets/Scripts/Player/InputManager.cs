using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputManager : MonoBehaviour
{
    private PlayerControl p1;
    private PlayerControl p2;

    public void SettingP1(PlayerControl p1)
    {
        this.p1 = p1;
    }

    public void SettingP2(PlayerControl p2)
    {
        this.p2 = p2;
    }

    private void Update()
    {
        if (p1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                p1.MoveUp();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                p1.MoveDown();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                p1.Shoot();
            }
        }

        if (p2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                p2.MoveUp();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                p2.MoveDown();
            }
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                p2.Shoot();
            }
        }
    }
}
