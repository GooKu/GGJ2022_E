using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    private event Action<Bullet> OnHitBulletEvent;
    private event Action<Bullet, PlayerControl> OnHitPlayerEvent;

    [SerializeField]
    private PlayerType playerType;
    [SerializeField]
    private float speed = 5;

    private Tilemap map;

    private int currentX;

    public void Init(Tilemap map)
    {
        this.map = map;
        currentX = getX(map);
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case Tags.Bullet:
                OnHitBulletEvent?.Invoke(this);
                break;
            case Tags.Player:
                OnHitPlayerEvent?.Invoke(this, collision.gameObject.GetComponent<PlayerControl>());
                break;
        }
    }

    private int getX(Tilemap map)
    {
        return map.WorldToCell(transform.position).x;
    }

}
