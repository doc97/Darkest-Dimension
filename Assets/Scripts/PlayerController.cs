using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestDimension {

    public class PlayerController : MonoBehaviour {

        #region Constants
        private const string FRONT_NAME = "Character_front";
        private const string BACK_NAME = "Character_back";
        private const string LEFT_NAME = "Character_left";
        private const string RIGHT_NAME = "Character_right";
        #endregion

        #region Fields
        [Header("Input bindings")]
        #region Input bindings
        [SerializeField]
        private KeyCode keyUp = KeyCode.W;

        [SerializeField]
        private KeyCode keyDown = KeyCode.S;

        [SerializeField]
        private KeyCode keyLeft = KeyCode.A;

        [SerializeField]
        private KeyCode keyRight = KeyCode.D;
        #endregion

        [Header("Gameplay")]
        #region Gameplay
        [SerializeField]
        private float speed = 1;
        #endregion
        #endregion

        private List<KeyCode> keys = new List<KeyCode>();
        private Vector3 direction = new Vector3();
        private bool isMoving;

        private void Update() {
            PollInput();
            UpdateMovement();
        }

        private void PollInput() {
            if (Input.GetKeyDown(keyUp)) {
                keys.Add(keyUp);
            } else if (Input.GetKeyDown(keyDown)) {
                keys.Add(keyDown);
            } else if (Input.GetKeyDown(keyLeft)) {
                keys.Add(keyLeft);
            } else if (Input.GetKeyDown(keyRight)) {
                keys.Add(keyRight);
            }

            if (Input.GetKeyUp(keyUp)) {
                keys.RemoveAll((key) => key == keyUp);
            } else if (Input.GetKeyUp(keyDown)) {
                keys.RemoveAll((key) => key == keyDown);
            } else if (Input.GetKeyUp(keyLeft)) {
                keys.RemoveAll((key) => key == keyLeft);
            } else if (Input.GetKeyUp(keyRight)) {
                keys.RemoveAll((key) => key == keyRight);
            }
        }

        private void UpdateMovement() {
            if (keys.Count == 0) {
                return;
            }

            Vector3 dir = GetDirection(keys[keys.Count - 1]);
            if (!isMoving) {
                Move(dir);
            } else if (dir == -direction) {
                Stop();
                Move(dir);
            }
        }

        private void Move(Vector3 direction) {
            this.direction = direction;
            isMoving = true;
            ActivateChild(GetChildNameByDirection(direction));
            StartCoroutine("MoveInDirection", direction);
        }

        private void Stop() {
            isMoving = false;
            StopCoroutine("MoveInDirection");
        }

        private IEnumerator MoveInDirection(Vector3 direction) {
            Vector3 start = transform.position;
            Vector3 target = VectorUtil.ToIntVector3(start + direction);
            float t = 0;

            while (t <= 1) {
                transform.position = Vector3.Lerp(start, target, t);
                t += speed * Time.deltaTime;

                if (t >= 1) {
                    break;
                }
                yield return null;
            }

            transform.position = VectorUtil.ToIntVector3(transform.position);
            isMoving = false;
        }

        private Vector3 GetDirection(KeyCode key) {
            if (key == keyUp) {
                return new Vector3(0, 1, 0);
            } else if (key == keyDown) {
                return new Vector3(0, -1, 0);
            } else if (key == keyLeft) {
                return new Vector3(-1, 0, 0);
            } else if (key == keyRight) {
                return new Vector3(1, 0, 0);
            } else {
                return new Vector3();
            }
        }

        private string GetChildNameByDirection(Vector3 direction) {
            if (direction.x > 0) {
                return RIGHT_NAME;
            } else if (direction.x < 0) {
                return LEFT_NAME;
            } else if (direction.y > 0) {
                return BACK_NAME;
            } else {
                return FRONT_NAME;
            }
        }

        private void ActivateChild(string childName) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false);
            }
            transform.Find(childName).gameObject.SetActive(true);
        }
    }

}