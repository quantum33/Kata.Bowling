using System.Collections.Generic;
using System.Linq;

namespace Kata.Bowling
{
    public class Frame
    {
        public Frame(int rank)
        {
            Rank = rank;
        }

        public int Rank { get; }

        public IReadOnlyCollection<Roll> Rolls
        {
            get { return _rolls; }
        }

        public Frame AddRoll(Roll roll)
        {
            if (!IsTenthFrame)
            {
                _rolls.Add(roll);
            }
            else if (IsTenthFrame && !IsMaxRollsLimitReached)
            {
                _rolls.Add(roll);
            }
            else if (IsTenthFrame && IsEligibleForExtraBall)
            {
                _rolls.Add(roll);                
            }
            return this;
        }

        public int GetScore(Frame nextFrame)
            => GetDownPinCount() + GetBonus(nextFrame);

        private int GetBonus(Frame nextFrame)
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

        public bool IsTenthFrame
            => Rank == Constants.MaxFrameCount - 1;

        public bool NotIsTenthFrame
            => !IsTenthFrame;

        public bool IsStrike
            => IsAllPinDown && HasSingleRoll;

        public bool IsSpare
            => IsAllPinDown && !HasSingleRoll;

        public bool IsMaxRollLimitReached
            => Rolls.Count == Constants.MaxRollCount;

        public int GetDownPinCount()
            => Rolls.Sum(r => r.DownPinCount);

        private bool IsAllPinDown
            => GetDownPinCount() == Constants.MaxPinCount;

        private bool HasSingleRoll
            => Rolls.Count == 1;

        private bool IsMaxRollsLimitReached
            => Rolls.Count == Constants.MaxRollCount;

        private bool IsEligibleForExtraBall
            => IsTenthFrame
            && (IsStrike || IsSpare);

        private readonly List<Roll> _rolls = new List<Roll>();
    }
}
