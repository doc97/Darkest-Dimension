using UnityEngine;

public class PlayerController : MonoBehaviour {

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

    private KeyCode lastKeyDown = KeyCode.None;
    private Vector3 direction = new Vector3();

    private void Update() {
        PollInput();
    }

    private void PollInput() {
        if (Input.GetKeyDown(keyUp)) {
            lastKeyDown = keyUp;
        } else if (Input.GetKeyDown(keyDown)) {
            lastKeyDown = keyDown;
        } else if (Input.GetKeyDown(keyLeft)) {
            lastKeyDown = keyLeft;
        } else if (Input.GetKeyDown(keyRight)) {
            lastKeyDown = keyRight;
        }
    }
}
