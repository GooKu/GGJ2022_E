using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayer : MonoBehaviour
{
    private PlayerControl player;

    public void Bind(PlayerControl player)
    {
        this.player = player;
    }

    public void Run()
    {
        StartCoroutine(behavior());
    }

    public void End()
    {
        StopAllCoroutines();
    }

    private IEnumerator behavior()
    {
        float waitTime;

        do
        {
            if (player.IsCd)
            {
                if (Random.Range(0, 1f) > .5f)
                {
                    Move();
                }

                waitTime = Random.Range(.2f, .8f);
                yield return new WaitForSeconds(waitTime);
            }
            else if(Random.Range(0, 1f) > .5f)
            {
                waitTime = Random.Range(.3f, 2f);
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                player.Shoot();
            }

            yield return null;

        } while (true);
    }

    private void Move()
    {
        if(Random.Range(0,1f) > .5f)
        {
            player.MoveDown();
        }
        else
        {
            player.MoveUp();
        }
    }

}
