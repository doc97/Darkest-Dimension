using UnityEngine;

namespace DarkestDimension {

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(StatusValidation))]
    public class CharacterAnimationController : MonoBehaviour {

        [SerializeField]
        private PlayerController controller;
        private Animator animator;

        private void OnValidate() {
            StatusValidation status = GetComponent<StatusValidation>();
            status.AddCondition(() => controller != null, "controller is null");
            status.UpdateStatus();
        }

        private void Start() {
            animator = GetComponent<Animator>();
        }

        public void Update() {
            animator.SetBool("isWalking", controller.IsMoving);
        }

    }

}