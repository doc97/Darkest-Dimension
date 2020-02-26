using NUnit.Framework;
using System.Collections.Generic;

namespace DarkestDimension.Tests {

    [TestFixture]
    public class TestSpellCastState {

        [Test]
        public void SelectSpell_MoreThanSix() {
            SpellCastState state = new SpellCastState();
            for (int i = 0; i < 7; i++) {
                state.SelectSpell(SpellElement.Fire);
            }
            Assert.AreEqual(6, state.SelectedSpellCount);
        }

        [Test]
        public void SelectSpell_TypeMatches() {
            SpellCastState state = new SpellCastState();
            state.SelectSpell(SpellElement.Fire);
            state.SelectSpell(SpellElement.Water);

            List<SpellElement> spells = state.SelectedSpells;
            Assert.AreEqual(SpellElement.Fire, spells[0]);
            Assert.AreEqual(SpellElement.Water, spells[1]);
        }

        [Test]
        public void DeselectSpell_Empty() {
            SpellCastState state = new SpellCastState();
            state.DeselectSpell();
            Assert.AreEqual(0, state.SelectedSpellCount);
        }

        [Test]
        public void DeselectSpell_One() {
            SpellCastState state = new SpellCastState();
            state.SelectSpell(SpellElement.Fire);
            state.DeselectSpell();
            Assert.AreEqual(0, state.SelectedSpellCount);
        }

        [Test]
        public void DeselectSpell_LIFO() {
            SpellCastState state = new SpellCastState();
            state.SelectSpell(SpellElement.Fire);
            state.SelectSpell(SpellElement.Water);
            state.DeselectSpell();
            Assert.AreEqual(SpellElement.Fire, state.SelectedSpells[0]);
        }
    }

}