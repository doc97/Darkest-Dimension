using UnityEngine;

namespace DarkestDimension {

    [RequireComponent(typeof(SpriteRenderer))]
    public class SpellShape : MonoBehaviour {

        private int prevSpellCount;
        private Transform[] spells = new Transform[6];

        private void Start() {
            for (int i = 0; i < 6; i++) {
                spells[i] = transform.GetChild(i);
            }
        }

        private void OnValidate() {
            bool hasCorrectChildCount = transform.childCount == 6;

            if (hasCorrectChildCount) {
                GetComponent<SpriteRenderer>().color = Color.green;
            } else {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Return)) {
                G.Instance.TurnState.SelectSpell(SpellElement.Fire);
            }
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                G.Instance.TurnState.DeselectSpell();
            }

            // can be changed to event-based updates if performance is
            // necessary.
            int curSpellCount = G.Instance.TurnState.SelectedSpellCount;
            if (curSpellCount != prevSpellCount) {
                UpdateSpells(curSpellCount);
                prevSpellCount = curSpellCount;
            }
        }

        private void UpdateSpells(int spellCount) {
            GetComponent<Animator>().SetInteger("count", spellCount);
        }
    }

}