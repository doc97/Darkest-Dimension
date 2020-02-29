namespace DarkestDimension {
    public class HealthComponent : IComponent, ICopiable<HealthComponent> {
        public int Health { get; set; }

        public HealthComponent(int health = 0) {
            Health = health;
        }

        public HealthComponent Copy() {
            return new HealthComponent(Health);
        }
    }
}