namespace DarkestDimension {

    /// <summary>
    /// A Singleton for accessing global systems.
    /// Source: https://csharpindepth.com/Articles/Singleton
    /// </summary>
    public sealed class G {

        #region Fields
        private static readonly G instance = new G();
        public static G Instance { get => instance; }

        public Player Player { get; }
        #endregion

        static G() { }

        private G() {
            Player = new Player(new PlayerStats(100, 10));
        }

        public void Update(float deltaTime) { }
    }

}