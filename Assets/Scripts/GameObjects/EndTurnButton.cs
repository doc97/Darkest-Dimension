using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DarkestDimension {

    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(StatusValidation))]
    public class EndTurnButton : MonoBehaviour {

        private void OnValidate() {
            StatusValidation status = GetComponent<StatusValidation>();
            status.ClearConditions();
            status.AddCondition(() => transform.childCount > 0);
            status.AddCondition(() => transform.GetChild(0).GetComponent<TextMeshProUGUI>() != null);
            status.UpdateStatus();
        }

        private void Update() {
            if (G.Instance.Combat.IsPlayerTurn) {
                Enable();
            } else {
                Disable();
            }
        }

        private void Enable() {
            GetComponent<Button>().interactable = true;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "End turn";
        }

        private void Disable() {
            GetComponent<Button>().interactable = false;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Wait";
        }
    }

}