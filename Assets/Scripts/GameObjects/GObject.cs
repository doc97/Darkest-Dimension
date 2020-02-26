using UnityEngine;

namespace DarkestDimension {

    public class GObject : MonoBehaviour {
        private void Awake() {
            G.Instance.Init();
        }

        private void Update() {
            G.Instance.Update(Time.deltaTime);
        }
    }

}