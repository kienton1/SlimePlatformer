using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace Kien
{
    public class GhostGraphics : MonoBehaviour
    {
        private Vector3 lastPosition;
        private bool isMovingRight = true;
        public AIPath aiPath;

        void Start()
        {
            lastPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 currentPosition = transform.position;

            if (currentPosition.x > lastPosition.x)
            {
                // Moving to the right
                if (!isMovingRight)
                {
                    FlipCharacter();
                }
                isMovingRight = true;
            }
            else if (currentPosition.x < lastPosition.x)
            {
                // Moving to the left
                if (isMovingRight)
                {
                    FlipCharacter();
                }
                isMovingRight = false;
            }

            lastPosition = currentPosition;
        }

        private void FlipCharacter()
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}
