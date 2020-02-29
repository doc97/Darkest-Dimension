using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkestDimension {

    public class CombatSceneManager : MonoBehaviour {

        private void Awake() {
            G.Instance.Events.CmdExitCombat += OnCmdExitCombat;
        }

        private void OnDestroy() {
            G.Instance.Events.CmdExitCombat -= OnCmdExitCombat;
        }

        private void Start() {
            G.Instance.Combat.Reset();
            G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdSelectSpellTarget,
                new Entity("Enemy", new HealthComponent(5)));
        }

        private void OnCmdExitCombat(object sender, GameEventArgs e) {
            Logger.Log("scene", "Change to scene 'NavigationScene'");
            SceneManager.LoadSceneAsync("NavigationScene");
        }
    }

}