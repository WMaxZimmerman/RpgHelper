using System;
using Moq;
using NUnit.Framework;
using RpgHelper.BLL.Services;

namespace RpgHelper.Tests.BLL.Services
{
    [TestFixture]
    public class DiceServiceTests
    {
        private Mock<IRandomService> _rand;
        private DiceService _service;

        [SetUp]
        public void Init()
        {
            _rand = new Mock<IRandomService>();
            _service = new DiceService(_rand.Object);
        }

        [Test]
        public void RollTheDiceShouldRollDice()
        {
            _rand.Setup(r => r.RandomNumber(20)).Returns(4);

            var expected = 4;
            var diceFormula = "1d20";
            var result = _service.RollDice(diceFormula);

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void RollTheDiceShouldRollDiceForEachTimeTold()
        {
            _rand.Setup(r => r.RandomNumber(20)).Returns(4);

            var expected = 8;
            var diceFormula = "2d20";
            var result = _service.RollDice(diceFormula);

            _rand.Verify(r => r.RandomNumber(20), Times.Exactly(2));
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void RollTheDiceShouldRollDiceForEachTimeToldAndAddMultipleRolls()
        {
            _rand.Setup(r => r.RandomNumber(20)).Returns(4);
            _rand.Setup(r => r.RandomNumber(6)).Returns(2);

            var expected = 10;
            var diceFormula = "2d20+1d6";
            var result = _service.RollDice(diceFormula);

            _rand.Verify(r => r.RandomNumber(20), Times.Exactly(2));
            _rand.Verify(r => r.RandomNumber(6), Times.Once);
            Assert.AreEqual(result, expected);
        }
    }
}
