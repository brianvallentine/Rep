using CobolLanguageConverter.Converter.CSHARP;
using CobolLanguageConverter.Converter.DIVISION;
using CodeAnalyser.Helper;
using System.Reflection;
using System.Text;
using H = CobolLanguageConverter.Converter.Commands.CobolCommandHelper;

namespace CobolLanguageConverter.Converter.Commands.IF
{
    public class IfCommand : ICobolCommand
    {
        public CurrentLineType CurrentLine { get; set; }
        public ResultSet Result { get; set; }
        public string LastStringProcess { get; set; } = "";
        StringBuilder output = new StringBuilder();

        //public bool AwaitingDot(string line, out string invokedString, out List<int>? removeIndex)
        //{
        //    removeIndex = new List<int>();
        //    invokedString = null;
        //    var ret = false;

        //    if (line.Trim().EndsWith("."))
        //    {
        //        var counter = CSharpCommand.WaitingFor.Count(x => x.Method.Name.ToString() == "AwaitingEndIf");
        //        if (counter <= 0)
        //            counter = 1;

        //        invokedString = $"        {string.Concat(Enumerable.Repeat("}//AwaitingDot \n", counter))} \n";

        //        removeIndex.AddRange(CSharpCommand.WaitingFor.Select((x, i) => i));

        //        ret = true;
        //        LastStringProcess = "END-IF WITH DOT";
        //    }

        //    removeIndex = removeIndex.Where(x => x >= 0).ToList();
        //    return ret;
        //}

        //public bool AwaitingEndIf(string line, out string invokedString, out List<int> removeIndex)
        //{
        //    removeIndex = new List<int>();
        //    invokedString = null;
        //    var ret = false;

        //    if (line.StartsWith("END-IF"))
        //    {
        //        invokedString = "        }//AwaitingEndIf1\n";

        //        if (line.Replace(" ", "").StartsWith("END-IF."))
        //        {

        //            var counter = CSharpCommand.WaitingFor.Count(x => x.Method.Name.ToString() == "AwaitingEndIf") - 1;
        //            //if (counter <= 0)
        //            //    counter = 1;

        //            invokedString = $"        {string.Concat(Enumerable.Repeat("}//AwaitingEndIf2 \n", counter))} \n";

        //            removeIndex.Add(CSharpCommand.WaitingFor.IndexOf(AwaitingDot));
        //            //if (AwaitingDot(line, out var invokedStrings, out var removeIndexx))
        //            //    invokedString += invokedStrings;
        //        }

        //        removeIndex.Add(CSharpCommand.WaitingFor.IndexOf(AwaitingElse));

        //        ret = true;
        //        LastStringProcess = "END-IF";
        //    }

        //    removeIndex = removeIndex.Where(x => x >= 0).ToList();
        //    return ret;
        //}

        //public bool AwaitingElse(string line, out string? invokedString, out List<int> removeIndex)
        //{
        //    removeIndex = new List<int>();
        //    invokedString = "";
        //    var ret = false;

        //    if (line.StartsWith("ELSE"))
        //    {
        //        if (LastStringProcess == "ELSE")
        //        {
        //            var counterEi = CSharpCommand.WaitingFor.Count(x => x.Method.Name.ToString() == "AwaitingEndIf") - 1;
        //            var counterElse = CSharpCommand.WaitingFor.Count(x => x.Method.Name.ToString() == "AwaitingElse");
        //            //var counter = counterEi - counterElse;
        //            //if (counter <= 0)
        //            //    counter = 1;

        //            //invokedString = $"       }}//AwaitingElse1 \n";
        //            invokedString = $"        {string.Concat(Enumerable.Repeat("}//AwaitingElse1 \n", counterElse))} \n";
        //            invokedString += $"//{counterElse}\n";
        //            //invokedString = $"        {string.Concat(Enumerable.Repeat("}//AwaitingElse1 \n", counter))} \n";

        //            for (int i = 0; i < counterEi; i++)
        //            {
        //                var fstDef = CSharpCommand.WaitingFor.FirstOrDefault(x => x.Method.Name.ToString() == "AwaitingEndIf");
        //                var idx = CSharpCommand.WaitingFor.IndexOf(fstDef);
        //                CSharpCommand.WaitingFor.RemoveAt(idx);
        //            }
        //        }


        //        invokedString += "}//AwaitingElse2 \nelse { \n";

        //        ret = true;
        //        LastStringProcess = "ELSE";
        //        IfControl.Add("ELSE");
        //    }

        //    removeIndex = removeIndex.Where(x => x >= 0).ToList();
        //    return ret;
        //}

        //DONE

        public CobolCommandResponse Execute(string line)
        {
            var response = new CobolCommandResponse(line);

            try
            {

                //if (line.Trim().EndsWith("."))
                //{
                //    if (line.StartsWith("END-IF"))
                //        if (line.StartsWith("ELSE"))
                //            if (line.StartsWith("IF "))
                //                    }
                if (!line.Trim().StartsWith("END-IF") && line.Trim().EndsWith(".") && Result.IfControl.Count > 0)
                {
                    for (int i = Result.IfControl.Count - 1; i >= 0; i--)
                    {
                        var itm = Result.IfControl[i];
                        if (itm == "NOT_INSIDE_IF") continue;
                        if (itm == "DONT_PUT_IF") continue;

                        output.AppendLine("}\n");
                        Result.IfControl.RemoveAt(i);
                    }

                    response.Executed = true;
                }

                //ELSE DO EVALUATE
                if (line.StartsWith("ELSE IF "))
                {
                    line = line.Replace("ELSE IF ", "IF ");
                    output.AppendLine("} else");

                    if (Result.IfControl.Count > 0)
                        Result.IfControl.RemoveAt(Result.IfControl.Count - 1);
                }

                if (line.StartsWith("ELSE"))
                {
                    var last = Result.IfControl.LastOrDefault();
                    if (last == "ELSE")
                    {
                        for (int i = Result.IfControl.Count - 1; i >= 0; i--)
                        {
                            var localControl = Result.IfControl[i];
                            if (localControl == "IF") break;

                            Result.IfControl.RemoveAt(i);
                            output.AppendLine("}\n");
                        }
                    }

                    if (Result.IfControl.Count > 0)
                        Result.IfControl.RemoveAt(Result.IfControl.Count - 1);

                    output.AppendLine("}else{\n");
                    response.Executed = true;

                    Result.IfControl.Add("ELSE");
                }

                if (line.StartsWith("END-IF"))
                {
                    if (Result.IfControl.Count > 0)
                        Result.IfControl.RemoveAt(Result.IfControl.Count - 1);

                    output.AppendLine("}\n");

                    if (line.Trim().EndsWith("."))
                    {
                        for (int i = Result.IfControl.Count - 1; i >= 0; i--)
                        {
                            output.AppendLine("}\n");
                            Result.IfControl.RemoveAt(i);
                        }
                    }
                    response.Executed = true;
                }

                if (line.StartsWith("IF "))
                {
                    var ret = line;
                    var allCommands = ConvertHelper.FindCommands<IIfCommand>(Assembly.GetExecutingAssembly()).OrderBy(x => x.Order);
                    var markedList = new Dictionary<string, string>();

                    try
                    {
                        foreach (var command in allCommands)
                        {
                            command.CurrentLine = CurrentLine;
                            command.Result = Result;
                            var exec = command.Execute(ret, ref markedList);
                            ret = exec;
                        }

                        output.AppendLine(ret);
                        response.Executed = true;

                        //if (!CSharpCommand.WaitingFor.Any(x => x.Method.Name.ToString() == "AwaitingDot"))
                        //    CSharpCommand.WaitingFor.Add(AwaitingDot);

                        //CSharpCommand.WaitingFor.Add(AwaitingElse);
                        //CSharpCommand.WaitingFor.Add(AwaitingEndIf);
                        //LastStringProcess = "IF";
                        if (!Result.IfControl.Contains("NOT_INSIDE_IF"))
                            Result.IfControl.Add("IF");
                    }
                    catch (Exception ex)
                    {
                        var ax = new Exception($"ERRO - IF - {ex.Message}");
                        response.SetError(ax);

                        response.Executed = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            response.SetResponse(output);
            return response;
        }

    }
}