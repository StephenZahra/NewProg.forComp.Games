using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    Vector2 blockPosition, startingBlockPosition;
    GameObject randomBlock;
    GameObject[] arrayOfBlocks;

    // Start is called before the first frame update
    void Start()
    {
        arrayOfBlocks = Resources.LoadAll<GameObject>("Blocks");

        startingBlockPosition = transform.position;
        blockPosition = startingBlockPosition;

        ShowBlocksOnXAndY();
    }

    private void GetAndSpawnRandomBlocks()
    {
        int randomBlockIndex = Random.Range(0, arrayOfBlocks.Length);

        randomBlock = arrayOfBlocks[randomBlockIndex];

        Instantiate(randomBlock, blockPosition, transform.rotation);
    }

    private void ShowBlocksOnXAndY()
    {
        for(int y = 5; y > 1; y--)
        {
            for(int x = 1; x < 15; x+=2)
            {
                GetAndSpawnRandomBlocks();
                blockPosition.x += 2;
            }
            blockPosition.x = startingBlockPosition.x;
            blockPosition.y -= 2; 
        }
    }
}
