using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Test.Library
{
    public class CheckShotsTest
    {
        [Test]
        public void WaterShotsTest()
        {
            User user = new User("Nacho");
            User user2 = new User("Pepe");
            Game game = new Game(user, user2, "Classic");
            game.boardPlayer1.shots.Add("A");
            game.boardPlayer1.shots.Add("5");
            game.boardPlayer1.shots.Add("A");
            game.boardPlayer1.shots.Add("7");
            game.boardPlayer2.shots.Add("B");
            game.boardPlayer2.shots.Add("3");
            (int water, int hit) = game.CheckShots();
            Assert.AreEqual(3, water);
        }

        [Test]
        public void ShipShotsTest()
        {
            ArrayList ships1 = new ArrayList();
            ArrayList ships2 = new ArrayList();
            User user = new User("Nacho");
            User user2 = new User("Pepe");
            Game game = new Game(user, user2, "Classic");
            ships1.Add("B");
            ships1.Add("3");
            ships1.Add("B");
            ships1.Add("4");
            ships1.Add("B");
            ships1.Add("5");
            ships2.Add("A");
            ships2.Add("5");
            ships2.Add("B");
            ships2.Add("5");
            ships2.Add("C");
            ships2.Add("5");
            game.boardPlayer1.shipPos.Add(ships1);
            game.boardPlayer2.shipPos.Add(ships2);
            game.boardPlayer1.shots.Add("A");
            game.boardPlayer1.shots.Add("5");
            game.boardPlayer1.shots.Add("A");
            game.boardPlayer1.shots.Add("7");
            game.boardPlayer2.shots.Add("B");
            game.boardPlayer2.shots.Add("3");
            game.boardPlayer2.shots.Add("B");
            game.boardPlayer2.shots.Add("2");
            (int water, int hit) = game.CheckShots();
            Assert.AreEqual(2, hit);
        }
    }
}