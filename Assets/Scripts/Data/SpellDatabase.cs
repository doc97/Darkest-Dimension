using System.Collections.Generic;

namespace DarkestDimension {

    public class SpellDatabase {

        private static NoneSpell noneSpell = new NoneSpell();

        private Dictionary<SpellElement, ISpell> spells;

        public SpellDatabase() {
            spells = new Dictionary<SpellElement, ISpell>();
        }

        public void Clear() {
            spells.Clear();
        }

        public void Add(SpellElement element, ISpell spell) {
            spells.Add(element, spell);
        }

        public ISpell Get(SpellElement element) {
            if (spells.ContainsKey(element)) {
                return spells[element];
            }
            return noneSpell;
        }
    }

}