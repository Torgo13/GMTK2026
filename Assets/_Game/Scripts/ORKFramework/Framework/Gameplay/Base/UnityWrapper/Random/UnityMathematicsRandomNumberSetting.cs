
namespace GamingIsLove.Makinom
{
    [EditorSettingInfo("Unity Mathematics", "Uses Unity Mathematics' random number generation (Random.Next).")]
    public class UnityMathematicsRandomNumberSetting : BaseRandomNumberSetting
    {
        bool _variableHandlerFound;
        VariableHandler _variableHandler;
        public VariableHandler Variables { get { if (!_variableHandlerFound) { _variableHandler = Maki.Game.Variables; _variableHandlerFound = _variableHandler != null; } return _variableHandler; } }

        private const string stateKey = "state";

        public override int Range(int min, int max)
        {
            bool initialised = Seed(Variables, out var rand);
            var value = rand.NextInt(min, max);

            if (initialised)
                Variables.SetWithoutNotify(stateKey, unchecked((int)rand.state));

            return value;
        }

        public override float Range(float min, float max)
        {
            bool initialised = Seed(Variables, out var rand);
            var value = rand.NextFloat(min, max);

            if (initialised)
                Variables.SetWithoutNotify(stateKey, unchecked((int)rand.state));

            return value;
        }

        [System.Runtime.CompilerServices.MethodImpl(256)]
        private static bool Seed(VariableHandler variables, out Unity.Mathematics.Random rand)
        {
            uint state = unchecked((uint)variables.GetInt(stateKey));
            bool initialised = state != 0U;
            if (!initialised)
            {
                state = GetUninitialised();
            }

            rand = new Unity.Mathematics.Random(state);
            return initialised;
        }

        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc"/>
        [System.Runtime.CompilerServices.MethodImpl(256)]
        private static uint GetUninitialised()
        {
            System.Span<uint> uninitialisedSpan = stackalloc uint[1];
            uint uninitialised = uninitialisedSpan[0];
            uint state = uninitialised == 0 ? PKGE.RandomExtensions.SecureRandomUInt : uninitialised;
            return 1U + (state % uint.MaxValue);
        }
    }
}