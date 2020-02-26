using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkestDimension {
    public class NavigationSceneManager : MonoBehaviour {

        private void Awake() {
            G.Instance.Events.CmdEnterCombat += OnCmdEnterCombat;
        }

        private void OnDestroy() {
            G.Instance.Events.CmdEnterCombat -= OnCmdEnterCombat;
        }

        private void OnCmdEnterCombat(object sender, GameEventArgs e) {
            Logger.Log("scene", "Change to scene 'CombatScene'");
            SceneManager.LoadSceneAsync("CombatScene");
        }
    }

}