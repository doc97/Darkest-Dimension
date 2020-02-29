namespace DarkestDimension {

    public class HealingSpell : ISpell {

        private int healing;

        public HealingSpell(int healing) {
            this.healing = healing;
        }

        public void Trigger(Entity target) {
            HealthComponent component = target?.GetComponent<HealthComponent>()?.Copy();
            if (component != null) {
                Logger.Log("spell", "Cast healing spell (+{0} hp) on '{1}'", healing, target);
                component.Health += healing;
            }
        }
    }

}