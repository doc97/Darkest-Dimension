namespace DarkestDimension {

    public class DamageSpell : ISpell {

        public int damage;

        public DamageSpell(int damage) {
            this.damage = damage;
        }

        public void Trigger(Entity target) {
            HealthComponent component = target?.GetComponent<HealthComponent>()?.Copy();
            if (component != null) {
                Logger.Log("spell", "Cast damage spell (-{0} hp) on '{1}'", damage, target);
                component.Health -= damage;
            }
        }
    }
}