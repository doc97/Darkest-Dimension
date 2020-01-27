using NUnit.Framework;

namespace DarkestDimension.Tests {

    [TestFixture]
    public class TestLevelSystem {

        [Test]
        public void AddExp_Positive() {
            LevelSystem sys = new LevelSystem();
            Player p = new Player(new PlayerStats(0, 0));
            sys.AddExp(p, 10);
            Assert.AreEqual(10, p.Exp);
        }

        [Test]
        public void AddExp_Negative() {
            LevelSystem sys = new LevelSystem();
            Player p = new Player(new PlayerStats(0, 0));
            sys.AddExp(p, -10);
            Assert.AreEqual(10, p.Exp);
        }

        [Test]
        public void AddExp_LevelUp() {
            LevelSystem sys = new LevelSystem();
            Player p = new Player(new PlayerStats(0, 0));
            sys.AddExp(p, 100);
            Assert.AreEqual(2, p.Level);
        }

        [Test]
        public void AddExp_LevelUp_Max() {
            LevelSystem sys = new LevelSystem();
            Player p = new Player(new PlayerStats(0, 0));
            sys.AddExp(p, 1000000);
            Assert.AreEqual(sys.MaxExperience, p.Exp);
            Assert.AreEqual(sys.MaxLevel, p.Level);
        }
    }

}
