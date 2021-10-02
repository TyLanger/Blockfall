using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public int xSize = 16;
    public int zSize = 9;
    public float spacing = 1;


    public Block blockPrefab;
    public Block[,] blocks;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new Block[xSize, zSize];
        SpawnBlocks();
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
    }

}
