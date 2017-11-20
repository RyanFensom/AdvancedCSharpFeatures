using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper3D
{
    [RequireComponent(typeof(Renderer))]
    
    public class Block : MonoBehaviour
    {
        public int x, y, z;
        public bool isMine = false;
        [Header("References")]
        public Color[] textColors;
        public TextMesh textElement;
        public Transform mine;

        private bool isRevealed = false;
        private Renderer rend;

        // Use this for initialization
        void Awake()
        {
            rend = GetComponent<Renderer>();
        }

        void Start()
        {
            // Detach text Element from block
            textElement.transform.SetParent(null);
            // Randomly decide if it's a mine or not
            isMine = Random.value < .05f;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void UpdateText(int adjacentMines)
        {
            // Are there asjacent mines?
            if (adjacentMines > 0)
            {
                // Set test to amount of mines
                textElement.text = adjacentMines.ToString();

                // Check if adjacentMines are withi textColor's array
                if (adjacentMines >= 0 && adjacentMines < textColors.Length) { }
                {
                    // Set text color to whatever was present
                    textElement.color = textColors[adjacentMines];
                }
            }
        }

        public void Reveal(int adjacentMines)
        {
            // Flags the block as being revealed
            isRevealed = true;
            // Checks if bloack is a mine
            if (isMine)
            {
                // Activate the references mine
                mine.gameObject.SetActive(true);
                // Detach mine from children
                mine.SetParent(null);
            }
            else
            {
                // Updates the text to display adjacentMines
                UpdateText(adjacentMines);
            }

            // Deactivates the block
            gameObject.SetActive(false);
        }
    }
}