using UnityEngine;

namespace DarkestDimension {

    public class UITestInput : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {
                G.Instance.TurnState.SelectSpell(SpellElement.Fire);
            }
            if (Input.GetKeyDown(KeyCode.W)) {
                G.Instance.TurnState.SelectSpell(SpellElement.Water);
            }
            if (Input.GetKeyDown(KeyCode.E)) {
                G.Instance.TurnState.SelectSpell(SpellElement.Earth);
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                G.Instance.TurnState.SelectSpell(SpellElement.Air);
            }
            if (Input.GetKeyDown(KeyCode.T)) {
                G.Instance.TurnState.SelectSpell(SpellElement.Divine);
            }
            if (Input.GetKeyDown(KeyCode.Y)) {
                G.Instance.TurnState.SelectSpell(SpellElement.Unholy);
            }
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                G.Instance.TurnState.DeselectSpell();
            }
        }
    }

}
