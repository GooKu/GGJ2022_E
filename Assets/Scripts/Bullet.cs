using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    public event Action<Vector3Int, PlayerType> OnTileChangeEvent;
    public event Action<Bullet, PlayerControl> OnHitPlayerEvent;

    public PlayerType Player => playerType;

    [SerializeField]
    private PlayerType playerType;
    [SerializeField]
    private float speed = 5;

    private Tilemap map;

    private int currentX;

    public void Init(Tilemap map)
    {
        this.map = map;
        var coor = map.WorldToCell(transform.position);
        currentX = coor.x;
        OnTileChangeEvent?.Invoke(coor, playerType);
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
        var coor = map.WorldToCell(transform.position);

        if (!map.HasTile(coor))
        {
            Destroy(gameObject);
            return;
        }

        if(coor.x != currentX)
        {
            OnTileChangeEvent?.Invoke(coor, playerType);
            coor.x = currentX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case Tags.Bullet:
                var bullet = collision.gameObject.GetComponent<Bullet>();

                if(bullet.Player == Player) { return; }

                Destroy(gameObject);
                break;
            case Tags.Player:
                OnHitPlayerEvent?.Invoke(this, collision.gameObject.GetComponent<PlayerControl>());
                break;
        }
    }
}
