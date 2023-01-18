using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace advent24 {
    public class Token : MonoBehaviour {
        [SerializeField] private GameObject token;

        public void initialise() {
            AdventEvents.tokenMoves.AddListener(move);
            AdventEvents.invalidPositionCheck.AddListener(checkIfInvalid);
            AdventEvents.destroyExceptEnd.AddListener(destroyExceptEnd);
            AdventEvents.destroyExceptStart.AddListener(destroyExceptStart);
            name = "token (" + transform.position.x + ", " + transform.position.y + ")";
        }

        private void move() {
            GameObject childToken;
            childToken = Instantiate(token, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
            childToken.GetComponent<Token>().initialise();
            childToken = Instantiate(token, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
            childToken.GetComponent<Token>().initialise();
            childToken = Instantiate(token, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
            childToken.GetComponent<Token>().initialise();
            childToken = Instantiate(token, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
            childToken.GetComponent<Token>().initialise();
        }

        private void checkIfInvalid() {
            RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector2.zero);
            if (rays.Length > 1) Destroy(gameObject);
        }

        private void destroyExceptEnd() {
            if (!(transform.position.x == WallBounds.rightBound - 1 && transform.position.y == WallBounds.bottomBound)) {
                Destroy(gameObject);
            }
        }

        private void destroyExceptStart() {
            if (!(transform.position.x == 1 && transform.position.y == 0)) {
                Destroy(gameObject);
            }
        }
    }
}
