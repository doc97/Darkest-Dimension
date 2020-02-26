using UnityEngine;

namespace DarkestDimension {
    public class NavigationSceneShortcuts : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdEnterCombat);
            }
        }
    }
}