using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingScoring;

namespace BowlingScoringTest
{
    /// <summary>
    /// UnitTest1 的摘要说明
    /// </summary>
    [TestClass]
    public class GameTest
    {
        private Game mv_game;
        public GameTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            mv_game = new Game();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestFourThrowNoMark()
        {
            //
            // TODO: 在此处添加测试逻辑
            //

            mv_game.Add(2);
            mv_game.Add(5);
            mv_game.Add(6);
            mv_game.Add(7);
            Assert.AreEqual(20, mv_game.score);
            Assert.AreEqual(7, mv_game.ScoreForFrame(1));
            Assert.AreEqual(20, mv_game.ScoreForFrame(2));
            Assert.AreEqual(3, mv_game.currentFrame);
        }

  /*      [TestMethod]
        public void TestOneThrow()
        {
            mv_game.Add(5);
            Assert.AreEqual(5, mv_game.score);
            Assert.AreEqual(1, mv_game.currentFrame);
        }*/

        [TestMethod]
        public void TestTwoThrowNoMark()
        {
            mv_game.Add(4);
            mv_game.Add(5);
            Assert.AreEqual(9, mv_game.score);
            Assert.AreEqual(2, mv_game.currentFrame);
        }

        [TestMethod]
        public void TestSimpleFrameAfterSpare()
        {
            mv_game.Add(3);
            mv_game.Add(7);
            mv_game.Add(3);
            mv_game.Add(2);
            Assert.AreEqual(13, mv_game.ScoreForFrame(1));
            Assert.AreEqual(18, mv_game.ScoreForFrame(2));
            Assert.AreEqual(18, mv_game.score);
            Assert.AreEqual(3, mv_game.currentFrame);

        }

        [TestMethod]
        public void TestSimpleSpare()
        {
            mv_game.Add(3);
            mv_game.Add(7);
            mv_game.Add(3);
            Assert.AreEqual(13, mv_game.ScoreForFrame(1));
            Assert.AreEqual(2, mv_game.currentFrame);
        }

        [TestMethod]
        public void TestSimpleStrike()
        {
            mv_game.Add(10);
            mv_game.Add(3);
            mv_game.Add(6);
            Assert.AreEqual(19, mv_game.ScoreForFrame(1));
            Assert.AreEqual(28,mv_game.score);
            Assert.AreEqual(3, mv_game.currentFrame);
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            for (int i = 0; i < 12; ++i)
            {
                mv_game.Add(10);
            }
            Assert.AreEqual(300, mv_game.score);
            Assert.AreEqual(10, mv_game.currentFrame);
        }

        [TestMethod]
        public void TestEndOfArray()
        {
            for (int i = 0; i < 9; i++)
            {
                mv_game.Add(0);
                mv_game.Add(0);
            }
            mv_game.Add(2);
            mv_game.Add(8);
            mv_game.Add(10);
            Assert.AreEqual(20, mv_game.score);
        }

        [TestMethod]
        public void TestSampleGame()
        {
            mv_game.Add(1);
            mv_game.Add(4);
            mv_game.Add(4);
            mv_game.Add(5);
            mv_game.Add(6);
            mv_game.Add(4);
            mv_game.Add(5);

            mv_game.Add(5);
            mv_game.Add(10);
            mv_game.Add(0);
            mv_game.Add(1);
            mv_game.Add(7);
            mv_game.Add(3);
            mv_game.Add(6);
            mv_game.Add(4);
            mv_game.Add(10);
            mv_game.Add(2);
            mv_game.Add(8);
            mv_game.Add(6);

            Assert.AreEqual(133, mv_game.score);
        }

        [TestMethod]
        public void TestHeartBreak()
        {
            for(int i=0;i<11;i++)
            {
                mv_game.Add(10);
            }
            mv_game.Add(9);
            Assert.AreEqual(299, mv_game.score);
        }

        [TestMethod]
        public void TestTenthFrameSpare()
        {
            for (int i = 0; i < 9; ++i)
            {
                mv_game.Add(10);
            }
            mv_game.Add(9);
            mv_game.Add(1);
            mv_game.Add(1);
            Assert.AreEqual(270, mv_game.score);
        }
    }
}
