using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkestDimension {

    public class CombatSceneManager : MonoBehaviour {
        public void GoToNavigationScene() {
            SceneManager.LoadSceneAsync("NavigationScene");
        }
    }

}