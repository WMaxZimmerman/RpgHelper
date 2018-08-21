using System;

namespace RpgHelper.BLL.Services
{
    public class DiceService
    {
        private readonly IRandomService _rand;

        public DiceService()
        {
            _rand = new RandomService();
        }

        public DiceService(IRandomService rand)
        {
            _rand = rand;
        }

        public int RollDice(string formula)
        {
            var formulas = formula.Replace(" ", "").Replace("D", "d").Split('+');
            var total = 0;

            foreach (var f in formulas)
            {
                total += RollTheDice(f);
            }

            return total;
        }

        private int RollTheDice(string formula)
        {
            var numbers = formula.Split('d');
            var iterator = Convert.ToInt32(numbers[0]);
            var diceSides = Convert.ToInt32(numbers[1]);
            var total = 0;

            for (var i = 0; i < iterator; i++)
            {
                var roll = _rand.RandomNumber(diceSides);
                total += roll;
            }

            return total;
        }
    }
}
