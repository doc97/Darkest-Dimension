using System.Collections.Generic;
using UnityEngine;

namespace DarkestDimension {

    [RequireComponent(typeof(StatusValidation))]
    public class SpellShape : MonoBehaviour {

        private int prevSpellCount;
        private Transform[] spells = new Transform[6];
        private Dictionary<SpellElement, Color> colors;

        private void Awake() {
            colors = new Dictionary<SpellElement, Color> {
                { SpellElement.Fire,    Color.red     },
                { SpellElement.Water,   Color.blue    },
                { SpellElement.Earth,   Color.green   },
                { SpellElement.Air,     Color.gray    },
                { SpellElement.Divine,  Color.yellow  },
                { SpellElement.Unholy,  Color.magenta },
            };
        }

        private void Start() {
            for (int i = 0; i < 6; i++) {
                spells[i] = transform.GetChild(i);
            }
        }

        private void OnValidate() {
            StatusValidation status = GetComponent<StatusValidation>();
            status.ClearConditions();
            status.AddCondition(() => transform.childCount == 6);
            status.UpdateStatus();
        }

        private void Update() {
            // can be changed to event-based updates if performance is
            // necessary.
            int curSpellCount = G.Instance.SpellCast.SelectedSpellCount;
            if (curSpellCount != prevSpellCount) {
                UpdateSpells(curSpellCount);
                prevSpellCount = curSpellCount;
            }
        }

        private void UpdateSpells(int spellCount) {
            // Sets color based on element type, will be changed to
            // sprite later
            List<SpellElement> elements = G.Instance.SpellCast.SelectedSpells;
            for (int i = 0; i < elements.Count; i++) {
                spells[i].GetComponent<SpriteRenderer>().color = colors[elements[i]];
            }

            GetComponent<Animator>().SetInteger("count", spellCount);
        }
    }

}