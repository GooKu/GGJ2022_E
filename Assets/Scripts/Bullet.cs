using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private event Action<Bullet> OnHitBulletEvent;
    private event Action<Bullet, PlayerControl> OnHitPlayerEvent;

    [SerializeField]
    private PlayerType playerType;
    [SerializeField]
    private float speed = 5;

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
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
}
