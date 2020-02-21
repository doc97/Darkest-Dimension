using System;

namespace DarkestDimension {

    public class PlayerLevelSystem {

        #region Properties
        public int MaxLevel { get => lvlExp.Length; }
        public int MaxExperience { get => lvlExp[lvlExp.Length - 1]; }
        #endregion

        private int[] lvlExp = new int[] { 100, 225, 400 };

        public void AddExp(Player player, int exp) {
            player.Exp = player.Exp + Math.Abs(exp);
            CheckLevelUp(player);
        }

        private void CheckLevelUp(Player player) {
            while (player.Level < MaxLevel && player.Exp >= lvlExp[player.Level - 1]) {
                player.Level++;
                player.Exp = Math.Min(player.Exp, MaxExperience);
            }
        }

    }

}