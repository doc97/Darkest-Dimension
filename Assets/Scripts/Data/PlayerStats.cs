namespace DarkestDimension {

    public class PlayerStats {

        public int MaxHealth { get; }
        public int BaseDamage { get; }

        public PlayerStats(int maxHealth, int baseDamage) {
            MaxHealth = maxHealth;
            BaseDamage = baseDamage;
        }

    }

}