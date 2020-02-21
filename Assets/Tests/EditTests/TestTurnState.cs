using NUnit.Framework;
using System.Collections.Generic;

namespace DarkestDimension.Tests {

    [TestFixture]
    public class TestTurnState {

        [Test]
        public void SelectSpell_MoreThanSix() {
            TurnState state = new TurnState();
            for (int i = 0; i < 7; i++) {
                state.SelectSpell(SpellElement.Fire);
            }
            Assert.AreEqual(6, state.SelectedSpellCount);
        }

        [Test]
        public void SelectSpell_TypeMatches() {
            TurnState state = new TurnState();
            state.SelectSpell(SpellElement.Fire);
            state.SelectSpell(SpellElement.Water);

            List<SpellElement> spells = state.SelectedSpells;
            Assert.AreEqual(SpellElement.Fire, spells[0]);
            Assert.AreEqual(SpellElement.Water, spells[1]);
        }

        [Test]
        public void DeselectSpell_Empty() {
            TurnState state = new TurnState();
            state.DeselectSpell();
            Assert.AreEqual(0, state.SelectedSpellCount);
        }

        [Test]
        public void DeselectSpell_One() {
            TurnState state = new TurnState();
            state.SelectSpell(SpellElement.Fire);
            state.DeselectSpell();
            Assert.AreEqual(0, state.SelectedSpellCount);
        }

        [Test]
        public void DeselectSpell_LIFO() {
            TurnState state = new TurnState();
            state.SelectSpell(SpellElement.Fire);
            state.SelectSpell(SpellElement.Water);
            state.DeselectSpell();
            Assert.AreEqual(SpellElement.Fire, state.SelectedSpells[0]);
        }
    }

}