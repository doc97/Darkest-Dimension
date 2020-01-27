namespace DarkestDimension {

    public class Player {

        #region Properties
        public int Exp { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }

        public PlayerStats Stats { get; }
        #endregion

        public Player(PlayerStats stats, int exp = 0, int level = 1, int health = 100) {
            Exp = exp;
            Level = level;
            Health = health;
            Stats = stats;
        }

    }

}