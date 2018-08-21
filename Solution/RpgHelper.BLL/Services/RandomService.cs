using System;

namespace RpgHelper.BLL.Services
{
    public interface IRandomService
    {
        int RandomNumber(int end);
    }


    public class RandomService: IRandomService
    {
        private readonly Random _rand;

        public RandomService()
        {
            _rand = new Random();
        }

        public int RandomNumber(int end)
        {
            return _rand.Next(1, end);
        }
    }
}
