using UnityEngine;

namespace DarkestDimension {

    public class UITestInput : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {
                G.Instance.SpellCast.SelectSpell(SpellElement.Fire);
            }
            if (Input.GetKeyDown(KeyCode.W)) {
                G.Instance.SpellCast.SelectSpell(SpellElement.Water);
            }
            if (Input.GetKeyDown(KeyCode.E)) {
                G.Instance.SpellCast.SelectSpell(SpellElement.Earth);
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                G.Instance.SpellCast.SelectSpell(SpellElement.Air);
            }
            if (Input.GetKeyDown(KeyCode.T)) {
                G.Instance.SpellCast.SelectSpell(SpellElement.Divine);
            }
            if (Input.GetKeyDown(KeyCode.Y)) {
                G.Instance.SpellCast.SelectSpell(SpellElement.Unholy);
            }
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                G.Instance.SpellCast.DeselectSpell();
            }
        }
    }

}
