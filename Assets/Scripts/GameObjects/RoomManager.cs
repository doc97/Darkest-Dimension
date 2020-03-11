using UnityEngine;

namespace DarkestDimension {

    [RequireComponent(typeof(StatusValidation))]
    public class RoomManager : MonoBehaviour {

        [SerializeField]
        private Transform background;

        [SerializeField]
        private Transform[] roomPrefabs;

        private void OnValidate() {
            StatusValidation status = GetComponent<StatusValidation>();
            status.ClearConditions();
            status.AddCondition(() => background != null, "background is null");
            status.AddCondition(() => roomPrefabs.Length > 0, "no rooms specified");
            status.AddCondition(() => {
                foreach (Transform prefab in roomPrefabs) {
                    if (prefab == null) {
                        return false;
                    }
                }
                return true;
            }, "specified rooms are null");
            status.UpdateStatus();
        }

        public void SelectRoom(int index) {

        }

    }

}
