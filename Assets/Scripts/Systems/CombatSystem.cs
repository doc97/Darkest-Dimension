namespace DarkestDimension {

    public class CombatSystem {

        private int turnCounter;

        public void Init() {
            G.Instance.Events.CmdEndTurn += OnCmdEndTurn;
            G.Instance.Events.CmdSelectSpell += OnCmdSelectSpell;
            G.Instance.Events.CmdDeselectSpell += OnCmdDeselectSpell;
        }

        private void OnCmdEndTurn(object sender, GameEventArgs e) {
            turnCounter++;
            if (turnCounter == 3) {
                G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdExitCombat);
            }
        }

        private void OnCmdSelectSpell(object sender, GameEventArgs e) {
            SpellElement element = (SpellElement) e.Data;
            G.Instance.SpellCast.SelectSpell(element);
        }

        private void OnCmdDeselectSpell(object sender, GameEventArgs e) {
            G.Instance.SpellCast.DeselectSpell();
        }
    }

}