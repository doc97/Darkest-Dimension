using UnityEngine;

namespace DarkestDimension {

    public class GObject : MonoBehaviour {
        private void Update() {
            G.Instance.Update(Time.deltaTime);
        }
    }

}