using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkestDimension {

    public class CombatSceneManager : MonoBehaviour {

        private void Awake() {
            G.Instance.Events.CmdEndTurn += OnEndTurn;
        }

        private void OnDestroy() {
            G.Instance.Events.CmdEndTurn -= OnEndTurn;
        }

        private void OnEndTurn(object sender, GameEventArgs e) {
            SceneManager.LoadSceneAsync("NavigationScene");
        }
    }

}