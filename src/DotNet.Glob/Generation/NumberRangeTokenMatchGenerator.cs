using System;
using System.Text;
using DotNet.Globbing.Token;

namespace DotNet.Globbing.Generation
{
    internal class NumberRangeTokenMatchGenerator : IMatchGenerator
    {
        private NumberRangeToken token;
        private Random _random;

        public NumberRangeTokenMatchGenerator(NumberRangeToken token, Random _random)
        {
            this.token = token;
            this._random = _random;
        }

        public void AppendMatch(StringBuilder builder)
        {
            if (token.IsNegated)
            {
                builder.AppendRandomNumberCharacterNotBetween(_random, token.Start, token.End);
            }
            else
            {
                builder.AppendRandomLiteralCharacterBetween(_random, token.Start, token.End);
            }
        }

        public void AppendNonMatch(StringBuilder builder)
        {
            if (token.IsNegated)
            {
                builder.AppendRandomLiteralCharacterBetween(_random, token.Start, token.End);
            }
            else
            {
                builder.AppendRandomLiteralCharacterNotBetween(_random, token.Start, token.End);
            }
        }
    }
}