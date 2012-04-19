using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScoring
{
    public class Game
    {
        private int mv_score;
        private int[] mv_throws = new int[21];
        private int mv_currentThrow;
        private int mv_currentFrame = 1;
        private bool mv_isFirstThrow = true;

        public int currentFrame
        {
            get { return mv_currentFrame; }
        }
        public int score
        {
            get { return ScoreForFrame(mv_currentFrame); }
        }

        public int GetCurrentFrame()
        {
            return mv_currentFrame;
        }

        public void Add(int pins)
        {
            mv_throws[mv_currentThrow++] = pins;
            mv_score += pins;

            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (Strike(pins) || (!mv_isFirstThrow))
            {
                AdvanceFrame();
                mv_isFirstThrow = true;
            }
            else
                mv_isFirstThrow = false;
            /*
            if (mv_isFirstThrow)
            {
                if(AdjustFrameForStrike(pins)==false)
                mv_isFirstThrow = false;
            }
            else
            {
                mv_isFirstThrow = true;
                AdvanceFrame();
            }*/
        }

        private bool AdjustFrameForStrike(int pins)
        {
            if (pins == 10)
            {
                AdvanceFrame();
                return true;
            }
            return false;
        }

        private void AdvanceFrame()
        {
            mv_currentFrame++;
            if (mv_currentFrame > 10)
                mv_currentFrame = 10;
        }

        private int ball;
        private int firstThrow;
        private int secondThrow;

        public int ScoreForFrame(int theFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0;
                currentFrame < theFrame;
                currentFrame++)
            {
                firstThrow = mv_throws[ball];
                if (Strike())
                {
                    score += 10 + NextTwoBallsForStrike;
                    ball++;
                }
                else if (Spare())
                {
                    score += 10 + NextBallForSpare;
                    ball += 2;
                }
                else
                {
                    score += TwoBallsInframe;
                    ball += 2;//谁先谁后让人很恶心
                }
            }
            return score;
        }

        private int NextTwoBallsForStrike
        {
            get { return (mv_throws[ball+1] + mv_throws[ball + 2]); }
        }
        private bool Strike(int pins)
        {
            return (mv_isFirstThrow && pins == 10);
        }

        private bool Strike()
        {
            return mv_throws[ball] == 10;
        }

        private int HandleSecondThrow()
        {
            int score=0;
            secondThrow = mv_throws[ball+1];

            //分瓶时需要知道下一轮的第一投
            if (Spare())
            {
                ball += 2;//谁先谁后让人很恶心
                score += 10 + NextBallForSpare;
            }
            else
            {
                score += TwoBallsInframe;
                ball += 2;//谁先谁后让人很恶心
            }
            return score;
        }

        private int TwoBallsInframe
        {
            get { return mv_throws[ball] + mv_throws[ball + 1]; }
        }

        private int NextBallForSpare
        {
            get { return mv_throws[ball+2]; }
        }

        private bool Spare()
        {
            return mv_throws[ball]+mv_throws[ball+1]==10;
        }
    }
}
