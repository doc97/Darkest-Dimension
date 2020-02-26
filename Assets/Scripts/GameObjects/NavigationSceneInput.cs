using UnityEngine;

namespace DarkestDimension {
    public class NavigationSceneInput : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdEnterCombat);
            }
        }
    }
}