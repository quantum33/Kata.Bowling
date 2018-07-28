﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Bowling
{
    public class Game
    {
        public void Roll(int knockedDownPins)
        {
            var currentRoll = new Roll(knockedDownPins);

            GetOrAddFrame().AddRoll(currentRoll);
        }

        public int GetScore()
        {
            if (GetFrameCount() != Constants.MaxFrameCount)
            {
                throw new InvalidOperationException($"maximum frame count is NOT reached ({_frames.Count}). You must continue gaming!");
            }

            int totalScore = 0;
            _frames.ForEach(frame =>
            {
                var nextFrame = GetNextFrame(frame);
                totalScore += frame.GetScore(nextFrame);
            });
            return totalScore;
        }

        public int GetFrameCount() => _frames.Count;

        private RankedFrame GetNextFrame(RankedFrame currentFrame)
            => currentFrame.IsTenthFrame
            ? null
            : _frames.ElementAt(currentFrame.Rank + 1);

        private RankedFrame GetOrAddFrame()
        {
            CreateFrame().AddTo(_frames);
            return _frames.Last();

            RankedFrame CreateFrame()
                => FrameFactory.CreateIf(_frames.HasNoElement(), frameRank: 0)
                ?? FrameFactory.CreateIf(_frames.Last().NotIsTenthFrame && _frames.Last().IsMaxRollLimitReached, frameRank: _frames.Last().Rank + 1)
                ?? FrameFactory.CreateIf(_frames.Last().NotIsTenthFrame && _frames.Last().IsStrike, frameRank: _frames.Last().Rank + 1);
        }

        private readonly List<RankedFrame> _frames = new List<RankedFrame>();
    }
}