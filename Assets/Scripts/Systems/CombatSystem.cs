namespace DarkestDimension {

    public class CombatSystem {

        public bool IsPlayerTurn { get; private set; } = true;

        private int turnCounter;
        private Entity target;

        public void Init() {
            G.Instance.Events.CmdEndTurn += OnCmdEndTurn;
            G.Instance.Events.CmdSelectSpell += OnCmdSelectSpell;
            G.Instance.Events.CmdDeselectSpell += OnCmdDeselectSpell;
            G.Instance.Events.CmdSelectSpellTarget += OnCmdSelectSpellTarget;

            G.Instance.SpellDB.Clear();
            G.Instance.SpellDB.Add(SpellElement.Fire, new DamageSpell(4));
            G.Instance.SpellDB.Add(SpellElement.Water, new HealingSpell(3));
        }

        public void Reset() {
            target = null;
            turnCounter = 0;
            IsPlayerTurn = true;
        }

        private void OnCmdEndTurn(object sender, GameEventArgs e) {
            if (IsPlayerTurn) {
                CastPlayerSpells();

                // Simulate AI turn
                G.Instance.Pipeline.New().Delay(2).Func(() => {
                    G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdEndTurn);
                });

                if (++turnCounter == 3) {
                    G.Instance.Pipeline.Abort();
                    G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdExitCombat);
                }
            }

            IsPlayerTurn = !IsPlayerTurn;
            G.Instance.SpellCast.DeselectAllSpells();
        }

        private void OnCmdSelectSpell(object sender, GameEventArgs e) {
            G.Instance.SpellCast.SelectSpell((SpellElement) e.Data);
        }

        private void OnCmdDeselectSpell(object sender, GameEventArgs e) {
            G.Instance.SpellCast.DeselectSpell();
        }

        private void OnCmdSelectSpellTarget(object sender, GameEventArgs e) {
            Entity entity = e.Data is Entity ? (Entity) e.Data : null;
            SetTarget(entity);
        }

        private void SetTarget(Entity target) {
            this.target = target;
        }

        private void CastPlayerSpells() {
            foreach (SpellElement e in G.Instance.SpellCast.SelectedSpells) {
                ISpell spell = G.Instance.SpellDB.Get(e);
                if (IsSelfTargetingSpell(spell)) {
                    spell.Trigger(G.Instance.Player);
                } else {
                    spell.Trigger(target);
                }
            }
        }

        private bool IsSelfTargetingSpell(ISpell spell) {
            return spell is HealingSpell;
        }

    }

}