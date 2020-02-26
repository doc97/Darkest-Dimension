using System.Linq;
using System.Collections.Generic;

namespace DarkestDimension {

    public class SpellCastState {

        public int SelectedSpellCount { get => _selectedSpells.Count; }
        public List<SpellElement> SelectedSpells { get => _selectedSpells.Reverse().ToList(); }
        private Stack<SpellElement> _selectedSpells = new Stack<SpellElement>();

        public void SelectSpell(SpellElement elem) {
            if (_selectedSpells.Count < 6) {
                _selectedSpells.Push(elem);
            }
        }

        public void DeselectSpell() {
            if (_selectedSpells.Count > 0) {
                _selectedSpells.Pop();
            }
        }

        public void DeselectAllSpells() {
            while (_selectedSpells.Count > 0) {
                _selectedSpells.Pop();
            }
        }
    }

}