using System.Collections.Generic;
using System.Linq;

namespace Kata.Bowling
{
    public class Frame
    {
        public Frame AddRoll(Roll roll)
        {
            _rolls.Add(roll);
            return this;
        }

        public int GetScore(RankedFrame nextFrame)
            => GetDownPinCount() + GetBonus(nextFrame);

        private int GetBonus(RankedFrame nextFrame)
        {
            if (IsStrike)
            {
                if (nextFrame.IsTenthFrame)
                {
                    return nextFrame.Rolls.Take(2).Sum(r => r.DownPinCount);
                }
                return nextFrame.Rolls.Sum(r => r.DownPinCount);
            }
            else if (IsSpare)
            {
                var first = nextFrame.Rolls.FirstOrDefault();
                return first != null ? first.DownPinCount : 0;
            }
            return 0;
        }

        private readonly List<Roll> _rolls = new List<Roll>();
        public IReadOnlyCollection<Roll> Rolls
        {
            get { return _rolls; }
        }

        public bool IsStrike
            => IsAllPinDown && HasSingleRoll;

        public bool IsSpare
            => IsAllPinDown && !HasSingleRoll;

        public bool IsMaxRollLimitReached
            => Rolls.Count == Constants.MaxRollCount;

        private int GetDownPinCount()
            => Rolls.Sum(r => r.DownPinCount);

        private bool IsAllPinDown
            => GetDownPinCount() == Constants.MaxPinCount;

        private bool HasSingleRoll
            => Rolls.Count == 1;

    }
}
