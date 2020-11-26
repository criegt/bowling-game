using System;

namespace BowlingGame
{
    public class TenthFrame : Frame
    {
        private Roll _thirdRoll = new(0);
        protected bool _isThirdRollAdded;

        public Roll ThirdRoll => _thirdRoll;

        public override int Score => TotalPins();

        public override bool IsCompleted
            => IsStrike && _isThirdRollAdded || !IsStrike && _isSecondRollAdded;

        public TenthFrame(Roll roll) : base(roll)
        {
        }

        public override void AddRoll(Roll roll)
        {
            if (IsCompleted)
            {
                throw new InvalidOperationException("Frame completo.");
            }

            if (IsStrike && _isSecondRollAdded)
            {
                _thirdRoll = roll;
                _isThirdRollAdded = true;
            }
            else
            {
                base.AddRoll(roll);
            }
        }

        protected override int StrikeBonus()
            => FirstRoll.Pins + SecondRoll.Pins;

        protected override int TotalPins()
            => FirstRoll.Pins + SecondRoll.Pins + ThirdRoll.Pins;
    }
}
