using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace advent24 {
    public class Blizzard : MonoBehaviour {
        private Vector3 direction;
        private Func<bool> wouldCollide;
        private Action positionReset;

        private void Start() {
            AdventEvents.blizzardMoves.AddListener(move);
        }

        private void move() {
            if (!wouldCollide()) transform.position += direction;
            else positionReset();
        }

        public void setType(char c) {
            switch (c) {
                case '>':
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Arrows/right");
                    GetComponent<Blizzard>().direction = Vector2.right;
                    wouldCollide = () => { return transform.position.x == WallBounds.rightBound - 1; };
                    positionReset = () => { transform.position = new Vector2(1, transform.position.y); };
                    break;
                case 'v':
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Arrows/down");
                    wouldCollide = () => { return transform.position.y == WallBounds.bottomBound + 1; };
                    positionReset = () => { transform.position = new Vector2(transform.position.x, -1); };
                    GetComponent<Blizzard>().direction = Vector2.down;
                    break;
                case '<':
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Arrows/left");
                    wouldCollide = () => { return transform.position.x == 1; };
                    positionReset = () => { transform.position = new Vector2(WallBounds.rightBound - 1, transform.position.y); };
                    GetComponent<Blizzard>().direction = Vector2.left;
                    break;
                case '^':
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Arrows/up");
                    wouldCollide = () => { return transform.position.y == -1; };
                    positionReset = () => { transform.position = new Vector2(transform.position.x, WallBounds.bottomBound + 1); };
                    GetComponent<Blizzard>().direction = Vector2.up;
                    break;
            }
        }
    }
}
