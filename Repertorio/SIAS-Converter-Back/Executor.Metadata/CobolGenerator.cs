using Executor.Metadata.Model;
using FileResolver.Helper;
using System.Text.RegularExpressions;

namespace Executor.Metadata
{
    public static class CobolGenerator
    {

        public static void CreateFileCob(List<MetadataFileModel> metaFiles)
        {
            var templateFile = string.Join(Environment.NewLine, File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Template", "Template.cob")));

            foreach (var metaFile in metaFiles)
            {
                try
                {
                    var parametros = new List<string?>();
                    var variaves = new List<string?>();
                    var body = new List<string?>();
                    var stream = templateFile;
                    var stringauxparametro = "";
                    var stringauxvariavel = "";
                    var stringPadLeft = "";

                    stringPadLeft = stringPadLeft.PadLeft(9, ' ');


                    foreach (var item2 in metaFile.Inputs)
                    {
                        stringauxparametro = $"{item2.Field.Replace(":", "").Replace("_", "-")}";
                        parametros.Add(stringauxparametro.PadLeft(15, ' '));
                        stringauxvariavel = "77  ".PadLeft(15, ' ');
                        stringauxvariavel = stringauxvariavel + $"{item2.Field.Replace(":", "").Replace("_", "-").PadRight(35, ' ')}PIC X(254).";
                        variaves.Add(stringauxvariavel);
                    }

                    foreach (var item3 in metaFile.Outputs)
                    {
                        if (!metaFile.Inputs.Where(x => x.Field.Contains(item3.Field)).Any())
                        {
                            stringauxparametro = $"{item3.Field.Replace(":", "").Replace("_", "-")}";
                            parametros.Add(stringauxparametro.PadLeft(15, ' '));
                            stringauxvariavel = "77  ".PadLeft(15, ' ');
                            stringauxvariavel = stringauxvariavel + $"{item3.Field.Replace(":", "").Replace("_", "-").PadRight(35, ' ')}PIC X(254).";
                            variaves.Add(stringauxvariavel.PadLeft(15, ' '));
                        }
                    }

                    metaFile.Code = metaFile.Code.ToUpper().Replace("\n/\n", "|")
                        .Replace("\n \n", "|")
                        .Replace("\n", "|")
                        .Replace("END SQL", "END-EXEC");

                    //apenas considerar cursor quando o metadado for select
                    if (Regex.IsMatch(metaFile.Code, @"EXEC\s+SQL\s+SELECT"))
                        metaFile.Code = metaFile.Code.Replace("EXEC SQL", "EXEC SQL DECLARE CUR_1 CURSOR WITH RETURN\n              WITH HOLD FOR \n              ");

                    metaFile.Code = metaFile.Code.TrimEnd('.') + ".";

                    var bodytext = metaFile.Code.Split("|");

                    foreach (var text in bodytext)
                    {
                        body.Add(stringPadLeft + text);
                    }

                    if ((metaFile.Inputs.Count + metaFile.Outputs.Count) > 0)
                        parametros[parametros.Count - 1] = parametros[parametros.Count - 1] + ".";

                    stream = stream.Replace("<PARAMETROS>", $"     {string.Join(Environment.NewLine + "     ", parametros)}");
                    stream = stream.Replace("<VARIAVEIS>", string.Join(Environment.NewLine, variaves));
                    stream = stream.Replace("<CODIGO>", string.Join(Environment.NewLine, body));

                    var pathDir = Path.Combine(Environment.CurrentDirectory, FileResolverHelper.Conf.OutputDirectory);
                    if (!Directory.Exists(pathDir))
                        Directory.CreateDirectory(pathDir);

                    var filePath = Path.Combine(pathDir, metaFile?.NameFile?.ToUpper() + ".cob");
                    File.WriteAllText(filePath, stream);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"Erro grave no template do programa: {metaFile.NameFile}");
                }
            }
        }
        //}
    }
}
