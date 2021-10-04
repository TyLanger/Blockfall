using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : Bullet
{
    bool hasReleased = false;

    public override void Setup(float speed, int damage)
    {
        base.Setup(speed, damage);
    }

    public void SetTether(Transform tetherTarget, float length)
    {
        StartCoroutine(CheckTether(tetherTarget, length));
    }

    IEnumerator CheckTether(Transform tetherTarget, float length)
    {
        while(true)
        {
            // don't check the tether once you've released.
            // tether is you need to stay this close to the shard to keep it alive
            // until you build up enough and they can release
            if (hasReleased)
                break;

            if(tetherTarget != null)
            {
                if(Vector3.Distance(transform.position, tetherTarget.position) > length)
                {
                    Cleanup();
                }
            }
            else
            {
                Cleanup();
            }

            yield return null;
        }
    }

    public void Release(Vector3 targetPoint, float newMoveSpeed)
    {
        if (!hasReleased)
        {
            // only release once
            hasReleased = true;
            ResetLife();
            transform.LookAt(targetPoint);
            _moveSpeed = newMoveSpeed;
        }
    }
}
