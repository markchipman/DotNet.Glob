using System.Text;
using DotNet.Globbing.Token;
using System;

namespace DotNet.Globbing.Generation
{
    internal class WildcardTokenMatchGenerator : IMatchGenerator
    {
        private WildcardToken token;
        private CompositeTokenMatchGenerator _subGenerator;
        private Random _random;
        
        public WildcardTokenMatchGenerator(WildcardToken token, Random random, CompositeTokenMatchGenerator subGenerator)
        {
            this.token = token;
            _subGenerator = subGenerator;
            _random = random;
        }

        public void AppendMatch(StringBuilder builder)
        {
            // append a random literal, between 0 characters and 10 in length
            builder.AppendRandomLiteralString(_random, 10);
            _subGenerator.AppendMatch(builder);
        }

        public void AppendNonMatch(StringBuilder builder)
        {
           // we won't match if our subtokens dont match.
            builder.AppendRandomLiteralString(_random, 10);
            _subGenerator.AppendNonMatch(builder);
            // builder.Append('/');
        }
    }
}