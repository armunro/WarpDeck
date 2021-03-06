using WarpDeck.Domain.Model.Collections;

namespace WarpDeck.Domain
{
    public abstract class TagRule
    {
        public string StyleKey { get; }
        protected string DesiredValue { get; }

        protected TagRule(string desiredValue, string styleKey)
        {
            DesiredValue = desiredValue;
            StyleKey = styleKey;
        }

        public abstract bool IsMetBy(TagMap tags);
        
        // ReSharper disable once UnusedParameter.Global
        //TODO: Implement value calculation
        public abstract string CalculateValue(TagMap tags);
      
    }

 
    
}