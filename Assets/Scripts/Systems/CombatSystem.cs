using System.Threading.Tasks;

namespace DarkestDimension {

    public class CombatSystem {

        public bool IsPlayerTurn { get; private set; } = true;

        private int turnCounter;

        public void Init() {
            G.Instance.Events.CmdEndTurn += OnCmdEndTurn;
            G.Instance.Events.CmdSelectSpell += OnCmdSelectSpell;
            G.Instance.Events.CmdDeselectSpell += OnCmdDeselectSpell;
        }

        public void Reset() {
            turnCounter = 0;
            IsPlayerTurn = true;
        }

        private void OnCmdEndTurn(object sender, GameEventArgs e) {
            IsPlayerTurn = !IsPlayerTurn;
            G.Instance.SpellCast.DeselectAllSpells();

            if (!IsPlayerTurn) {
                turnCounter++;
                if (turnCounter == 3) {
                    G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdExitCombat);
                } else {
                    // Simulate AI turn
                    Task.Delay(2000).ContinueWith(t => {
                        G.Instance.Events.RaiseGameEvent(this, GameEventType.CmdEndTurn);
                    });
                }
            }
        }

        private void OnCmdSelectSpell(object sender, GameEventArgs e) {
            G.Instance.SpellCast.SelectSpell((SpellElement) e.Data);
        }

        private void OnCmdDeselectSpell(object sender, GameEventArgs e) {
            G.Instance.SpellCast.DeselectSpell();
        }
    }

}