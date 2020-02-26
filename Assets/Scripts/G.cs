namespace DarkestDimension {

    /// <summary>
    /// A Singleton for accessing global systems.
    /// Source: https://csharpindepth.com/Articles/Singleton
    /// </summary>
    public sealed class G {

        #region Fields
        private static readonly G instance = new G();
        public static G Instance { get => instance; }

        public EventManager Events { get; }
        public Player Player { get; }
        public TurnState TurnState { get; }
        #endregion

        static G() { }

        private G() {
            Events = new EventManager();
            Player = new Player(new PlayerStats(100, 10));
            TurnState = new TurnState();
        }

        public void Update(float deltaTime) { }
    }

}