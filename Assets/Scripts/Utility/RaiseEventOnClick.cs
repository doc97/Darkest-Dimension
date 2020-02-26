using UnityEngine;
using UnityEngine.UI;

namespace DarkestDimension {
    [RequireComponent(typeof(Button))]
    public class RaiseEventOnClick : MonoBehaviour {

        [SerializeField]
        private GameEventArgsParam gameEvent;

        private void Start() {
            Button button = GetComponent<Button>();
            button.onClick.RemoveListener(OnClick);
            button.onClick.AddListener(OnClick);
        }

        private void OnClick() {
            G.Instance.Events.RaiseGameEvent(this, new GameEventArgs(gameEvent));
        }

    }
}