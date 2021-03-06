using System;
using WarpDeck.Application;
using WarpDeck.Application.Rules;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Icons
{
    public class PressAndHoldIconGenerator : IconGenerator
    {

        private int Middle => IconHeight / 2;

        protected override KeyIcon DrawIconElements(KeyModel keyModel, KeyIcon wipIcon)
        {
            return wipIcon
                .Background(Helpers.GetColorFromHex(Rule.GetStyleValue("background.color", keyModel, "#000")))
                .Text(
                    Rule.GetStyleValue("behaviors.pressAndHold.pressAction.text", keyModel, keyModel.KeyId.ToString()),
                    int.Parse(Rule.GetStyleValue("behaviors.pressAndHold.pressAction.text.top", keyModel, "5")),
                    int.Parse(Rule.GetStyleValue("behaviors.pressAndHold.pressAction.text.left", keyModel, "5")),
                    Rule.GetStyleValue("behaviors.pressAndHold.pressAction.text.fontFamily", keyModel, "Arial"),
                    float.Parse(Rule.GetStyleValue("behaviors.pressAndHold.pressAction.text.fontSize", keyModel, "14")))
                .Text(
                    Rule.GetStyleValue("behaviors.pressAndHold.holdAction.text", keyModel, keyModel.KeyId.ToString()),
                    int.Parse(Rule.GetStyleValue("behaviors.pressAndHold.holdAction.text.top", keyModel, Middle.ToString())),
                    int.Parse(Rule.GetStyleValue("behaviors.pressAndHold.holdAction.text.left", keyModel, "5")),
                    Rule.GetStyleValue("behaviors.pressAndHold.holdAction.text.fontFamily", keyModel, "Arial"),
                    float.Parse(Rule.GetStyleValue("behaviors.pressAndHold.holdAction.text.fontSize", keyModel, "14")));
        }

        public PressAndHoldIconGenerator(RuleManager ruleManager, int iconWidth = 244, int iconHeight = 244) 
            : base(ruleManager, iconWidth, iconHeight)
        {
        }
    }
}