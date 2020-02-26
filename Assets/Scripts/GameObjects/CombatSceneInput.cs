using UnityEngine;

namespace DarkestDimension {

    public class CombatSceneInput : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdSelectSpell, SpellElement.Fire);
            }
            if (Input.GetKeyDown(KeyCode.W)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdSelectSpell, SpellElement.Water);
            }
            if (Input.GetKeyDown(KeyCode.E)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdSelectSpell, SpellElement.Earth);
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdSelectSpell, SpellElement.Air);
            }
            if (Input.GetKeyDown(KeyCode.T)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdSelectSpell, SpellElement.Divine);
            }
            if (Input.GetKeyDown(KeyCode.Y)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdSelectSpell, SpellElement.Unholy);
            }
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdDeselectSpell);
            }
        }
    }

}
