namespace DarkestDimension {

    /// <summary>
    /// A Singleton for accessing global systems.
    /// Source: https://csharpindepth.com/Articles/Singleton
    /// </summary>
    public sealed class G {

        #region Fields
        private static readonly G instance = new G();
        public static G Instance { get => instance; }

        public PipelineManager Pipeline { get; }
        public EventManager Events { get; }
        public Player Player { get; }
        public CombatSystem Combat { get; }
        public SpellDatabase SpellDB { get; }
        public SpellCastState SpellCast { get; }
        #endregion

        static G() { }

        private G() {
            Pipeline = new PipelineManager();
            Events = new EventManager();
            Player = new Player(new PlayerStats(100, 10));
            Combat = new CombatSystem();
            SpellDB = new SpellDatabase();
            SpellCast = new SpellCastState();
        }

        public void Init() {
            Combat.Init();
        }

        public void Update(float deltaTime) {
            Pipeline.Update(deltaTime);
        }
    }

}