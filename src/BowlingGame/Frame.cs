using System;
namespace BowlingGame
{
    public class Frame
    {
        private Roll _secondRoll = new(0);
        private Frame _next;

        protected bool _isSecondRollAdded;

        public Roll FirstRoll { get; }
        public Roll SecondRoll => _secondRoll;

        protected bool IsSpare => !IsStrike && FirstRoll.Pins + SecondRoll.Pins == 10;
        public bool IsStrike => FirstRoll.Pins == 10;
        public virtual bool IsCompleted => IsStrike || IsSpare || _isSecondRollAdded;

        public virtual int Score
        {
            get
            {
                if (IsStrike)
                {
                    return 10 + _next.StrikeBonus();
                }
                else if (IsSpare)
                {
                    return 10 + _next.SpareBonus();
                }
                else
                {
                    return TotalPins();
                }
            }
        }

        public Frame(Roll roll) => FirstRoll = roll;

        public virtual void AddRoll(Roll roll)
        {
            if (IsCompleted)
            {
                throw new InvalidOperationException("Frame completo.");
            }

            _secondRoll = roll;
            _isSecondRollAdded = true;
        }

        public Frame CreateNext(Roll roll, bool isLastFrame = false)
            => _next = isLastFrame ? new TenthFrame(roll) : new Frame(roll);

        protected int SpareBonus()
            => FirstRoll.Pins;

        protected virtual int StrikeBonus()
            => FirstRoll.Pins + (IsStrike ? _next.FirstRoll.Pins : SecondRoll.Pins);

        protected virtual int TotalPins()
            => FirstRoll.Pins + SecondRoll.Pins;
    }
}
