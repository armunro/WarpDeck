using System;
using System.IO;
using WarpDeck.Application;
using WarpDeck.Application.Rules;
using WarpDeck.Domain;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.Icons
{
    public class SinglePressIconGenerator : IconGenerator
    {
        public SinglePressIconGenerator(RuleManager ruleManager, int iconWidth = 244, int iconHeight = 244) : base(
            ruleManager, iconWidth, iconHeight)
        {
        }

        private string CalculateSvgFilePath(KeyModel key)
        {
            string svgBaseDir = Rule.GetStyleValue("svg.baseDirectory", key, string.Empty);
            string svgPath = Rule.GetStyleValue("svg.path", key, string.Empty);

            return !string.IsNullOrWhiteSpace(svgBaseDir)
                ? Path.Combine(svgBaseDir, svgPath)
                : svgPath;
        }

        protected override KeyIcon DrawIconElements(KeyModel key, KeyIcon wipIcon)
        {
            return wipIcon
                .Background(Helpers.GetColorFromHex(Rule.GetStyleValue("background.color", key, "#000")))
                .Border(
                    int.Parse(Rule.GetStyleValue("border.thickness", key, "0")),
                    Helpers.GetColorFromHex(Rule.GetStyleValue("border.color", key, "#000")))
                .Svg(
                    CalculateSvgFilePath(key),
                    int.Parse(Rule.GetStyleValue("svg.position.top", key, "20")),
                    int.Parse(Rule.GetStyleValue("svg.position.left", key, "5")),
                    float.Parse(Rule.GetStyleValue("svg.scale.width", key, "1")),
                    float.Parse(Rule.GetStyleValue("svg.scale.height", key, "1")))
                .Text(
                    Rule.GetStyleValue("text", key, key.KeyId.ToString()),
                    int.Parse(Rule.GetStyleValue("text.top", key, "5")),
                    int.Parse(Rule.GetStyleValue("text.left", key, "5")),
                    Rule.GetStyleValue("text.fontFamily", key, "Arial"),
                    float.Parse(Rule.GetStyleValue("text.fontSize", key, "14"))
                );
        }
    }
}