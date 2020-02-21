using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkestDimension {
    public class NavigationSceneManager : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadSceneAsync("CombatScene");
            }
        }
    }

}