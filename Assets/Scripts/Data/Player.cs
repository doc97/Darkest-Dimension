namespace DarkestDimension {

    public class Player : Entity {

        #region Properties
        public int Exp { get; set; }
        public int Level { get; set; }
        public int Health { get => health.Health; set => health.Health = value; }

        public PlayerStats Stats { get; }
        #endregion

        private HealthComponent health = new HealthComponent();

        public Player(PlayerStats stats, int exp = 0, int level = 1, int health = 100)
            : base("Player", new HealthComponent()) {
            Exp = exp;
            Level = level;
            Health = health;
            Stats = stats;
        }

        public void SetHealthComponent(HealthComponent component) {
            if (component != null) {
                health = component;
            }
        }

        public HealthComponent GetHealthComponent() {
            return health;
        }
    }

}