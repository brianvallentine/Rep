using CobolLanguageConverter.Converter.Commands.IF;
using CobolLanguageConverter.Converter.DIVISION;
using DocumentFormat.OpenXml.Drawing;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands
{
    public class IF_ResolveLastParametersCommand : IIfCommand
    {
        public int Order { get; set; } = 7;
        public CurrentLineType? CurrentLine { get; set; }
        public ResultSet Result { get; set; }

        public string Execute(string line, ref Dictionary<string, string> markedList)
        {
            var ret = line;

            ret = ResolveLastParameters(ret);

            return ret;
        }

        string ResolveLastParameters(string line)
        {
            var ret = line.Trim();

            //controle para usar apenas as condições
            if (Result.IfControl.Contains("DONT_PUT_IF"))
                return ret;

            // Adiciona a condição convertida ao StringBuilder
            var ignoreParenthesis = ret.StartsWith("(") && ret.EndsWith(")");
            if (ignoreParenthesis)
            {
                var subStr = ret.Substring(1, ret.Length - 1);
                ignoreParenthesis = subStr.IndexOf(')') < subStr.IndexOf(')');
            }

            if (!ignoreParenthesis)
                ret = $"\nif ({ret})";
            else
                ret = $"\nif {ret}";

            ret += "\n{";
            //fix para validar aspa dupla
            if (ret.Contains("double_quote")) ret = ret.Replace("double_quote", "\\\"");
            //fix para objects == string
            if (ret.Contains("==") && !ret.Contains("SQLCODE") && ret.Contains("if (") && !ret.Contains(".In("))
            {
                var parts = ret.Split(new[] { "==" }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string left = parts[0].Trim();
                    string right = parts[1].Trim();

                    int lastDotIndex = left.LastIndexOf('.');
                    if (lastDotIndex != -1)
                    {
                        string lastField = lastDotIndex >= 0 ? left.Substring(lastDotIndex + 1) : left;
                        var localVar = H.GetReferenceProperty(lastField, Result);
                        bool isBasis = localVar != null ? localVar.PropertyType.Contains("Basis") : false;

                        bool isStringLiteral = right.StartsWith("\"") && right.IndexOf('"', 1) > 0;

                        if (!isBasis && localVar != null && isStringLiteral)
                        {
                            string originalSuffix = "";
                            int closingQuote = right.IndexOf('"', 1);
                            if (closingQuote != -1 && closingQuote + 1 < right.Length)
                            {
                                originalSuffix = right.Substring(closingQuote + 1);
                                right = right.Substring(0, closingQuote + 1);
                            }
                            ret = $"{left}.GetMoveValues() == {right}{originalSuffix}";
                        }
                    }
                }
            }
            return ret;
        }
    }
}
