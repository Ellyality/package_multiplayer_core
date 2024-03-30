namespace Ellyality.RPG
{
    public sealed class EffectInstance
    {
        public readonly EffectStructure Effect;
        public int Level { get; set; } = 1;
        public float Countdown { get; set; } = float.MinValue;
        public bool ShouldDestroy => Countdown <= 0f && Countdown != float.MinValue;

        public EffectInstance(EffectStructure effect)
        {
            Effect = effect;
        }

        /// <summary>
        /// Update the effect countdown variable
        /// </summary>
        /// <param name="t">Passtime</param>
        /// <returns>Return if this effect should be destroy</returns>
        public bool UpdateCountdown(float t)
        {
            if (Countdown == float.MinValue) return false;
            Countdown -= t;
            return Countdown <= 0f;
        }
    }
}
