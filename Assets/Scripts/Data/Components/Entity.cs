using System.Collections.Generic;

namespace DarkestDimension {

    public class Entity {

        private string name;
        private List<IComponent> components;

        public Entity(string name, params IComponent[] components) {
            this.name = name;
            this.components = new List<IComponent>(components);
        }

        public T GetComponent<T>() where T : IComponent {
            foreach (IComponent c in components) {
                if (c is T) {
                    return (T) c;
                }
            }
            return default(T);
        }

        public override string ToString() {
            return string.Format("<{0}>", name);
        }

    }
}