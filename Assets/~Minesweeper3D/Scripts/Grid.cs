using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper3D
{


    public class Grid : MonoBehaviour
    {
        public GameObject blockPrefab;
        // The grid's dimensions
        public int height = 10, width = 10, depth = 10;
        // Spacing between each block
        public float spacing = 1.2f;

        // Multi-Dimensional Arrary storing the blocks (in this case 3D)
        private Block[,,] blocks;

        // Use this for initialization
        void Start()
        {
            // Generate blocks on startup
            GenerateBlocks();
        }

        // Spawns a block at position and returns the block component
        Block SpawnBlock(Vector3 pos)
        {
            // Instantiate clone
            GameObject clone = Instantiate(blockPrefab);
            // Set position
            clone.transform.position = pos;
            // Get Block component
            Block currentBlock = clone.GetComponent<Block>();
            // Return it
            return currentBlock;
        }

        // Spawns blocks in a grid-like fashion
        void GenerateBlocks()
        {
            // Create 3D array to store all the blocks
            blocks = new Block[width, height, depth];

            // Loop through the X, Y and Z axis of the 3D array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        // Calculate half size using array dimensions
                        Vector3 halfSize = new Vector3(width / 2, height / 2, depth / 2);
                        // Make sure to offset by half (so that elements are centered)
                        //// NOTE: Try without this line to see the difference visually when spawning
                        halfSize -= new Vector3(0.5f, 0.5f, 0.5f);
                        // Create position for element to pivot around Grid zero
                        Vector3 pos = new Vector3(x - halfSize.x,
                                                  y - halfSize.y,
                                                  z - halfSize.z);
                        // Apply spacing
                        pos *= spacing;
                        // Spawn the block at that position
                        Block block = SpawnBlock(pos);
                        // Attach block to grid as a child
                        block.transform.SetParent(transform);
                        // Store array coordinate inside the block itself
                        block.x = x;
                        block.y = y;
                        block.z = z;
                        // store block in the array at coordinates
                        blocks[x, y, z] = block;
                    }
                }
            }
        }

        
        // Count adjacent mines at element
        public int GetAdjacentMineCountAt(Block b)
        {
            int count = 0;
            // Loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                // Calculate adjacent element's index
                int desiredX = b.x + x;

                // IF desiredX is within range of blocks array
                if (desiredX <= blocks.Length)
                {
                    // IF the element at index is a mine
                    if (b.isMine)
                    {
                        // Increment count by 1;
                        count++;
                    }
                }

                for (int y = -1; y <= 1; y++)
                {
                    // Calculate adjacent element's index
                    int desiredY = b.x + x;

                    // IF desiredX is within range of blocks array
                    if (desiredY <= blocks.Length)
                    {
                        // IF the element at index is a mine
                        if (b.isMine)
                        {
                            // Increment count by 1;
                            count++;
                        }
                    }

                    for (int z = -1; z <= 1; z++)
                    {
                        // Calculate adjacent element's index
                        int desiredZ = b.x + x;

                        // IF desiredX is within range of blocks array
                        if (desiredZ <= blocks.Length)
                        {
                            // IF the element at index is a mine
                            if (b.isMine)
                            {
                                // Increment count by 1;
                                count++;
                            }
                        }

                    }

                    
                }

                               
            }
            return count;
        }

        // Used to destroy a block upon clicking it
        public void RemoveBlock()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
