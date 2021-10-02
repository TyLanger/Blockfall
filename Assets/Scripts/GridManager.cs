using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridManager : MonoBehaviour
{

    public int xSize = 16;
    public int zSize = 9;
    public float spacing = 1;


    public Block blockPrefab;
    public Block[,] blocks;

    int activeBlocks = 0;
    public float timeBetweenFalls = 1; //0.2 might be good

    // Start is called before the first frame update
    void Start()
    {
        blocks = new Block[xSize, zSize];
        SpawnBlocks();
        StartCoroutine(DecayBlocks());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBlocks()
    {
        Vector3 bottomLeft = transform.position - new Vector3(spacing * (xSize-1) / 2f, 0, spacing * (zSize-1) / 2f);

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < zSize; j++)
            {
                Block copy = Instantiate(blockPrefab, bottomLeft + new Vector3(i * spacing, 0, j * spacing), Quaternion.identity, transform);
                blocks[i, j] = copy;
            }
        }

        activeBlocks = xSize * zSize;
    }

    public void DropRandomBlock()
    {
        // get an array of all blocks still alive (haven't fallen)
        var aliveBlocks = blocks.Cast<Block>().Where(u => !u.HasFallen()).ToArray();
        // pick a random one
        int r = Random.Range(0, aliveBlocks.Count());
        // make it fall
        aliveBlocks[r].Fall();

        activeBlocks--;
    }

    IEnumerator DecayBlocks()
    {
        while (activeBlocks > 0)
        {
            DropRandomBlock();
            yield return new WaitForSeconds(timeBetweenFalls);
        }
    }

}
