using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShardGun : Gun
{
    public event Action<Vector3, float> ReleaseAllShards;

    public float releasedMoveSpeed = 20;
    public float tetherLength = 5;

    int currentOffset = 0;

    public Transform[] shardOffsetPoints;

    public Shard shardPrefab;
    int numShards = 0;
    int numNeeded = 5;

    Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    public override bool Fire(Vector3 aimPoint)
    {
        if(base.Fire(aimPoint))
        {
            // successfully fired a shot
            // create a shard
            Shard copy = Instantiate(shardPrefab, shardOffsetPoints[currentOffset].position, transform.rotation);
            currentOffset = ((currentOffset+1) % shardOffsetPoints.Length);
            copy.SetTether(player.transform, tetherLength);

            copy.OnDecayed += ShardDecayed;
            ReleaseAllShards += copy.Release;

            numShards++;

            if (numShards >= numNeeded)
            {
                numShards = 0;
                ReleaseAllShards?.Invoke(aimPoint, releasedMoveSpeed);
            }
            return true;
        }
        return false;
    }

    void ShardDecayed(Bullet copy)
    {
        // ran out of tether length and shard dissappeared
        ReleaseAllShards -= ((Shard)copy).Release;

        numShards = Math.Max(0, (numShards - 1));

    }
}
