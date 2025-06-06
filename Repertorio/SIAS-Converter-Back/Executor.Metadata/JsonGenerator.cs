using FileResolver.Helper;
using Newtonsoft.Json;

namespace Executor.Metadata
{
    public static class JsonGenerator
    {
        public static void CreateFileJson(string[] metadataFiles)
        {
            var inputModules = new List<InputConfigModules>();
            var inputFiles = Directory.GetFiles(FileResolverHelper.Conf.InputDirectory, "*").ToList();

            foreach (var pathInner in metadataFiles)
            {
                var name = Path.GetFileNameWithoutExtension(pathInner);
                var inputmodulo = new InputConfigModules();
                var files = new InputConfigModulesFiles();

                var ini = name.Substring(0, 2);
                var namemodulo = "";

                switch (ini)
                {
                    case "AC":
                        namemodulo = "Sias.Cosseguro";
                        break;
                    case "BI":
                        namemodulo = "Sias.Bilhetes";
                        break;
                    case "CB":
                        namemodulo = "Sias.Cobranca";
                        break;
                    case "EM":
                        namemodulo = "Sias.Emissao";
                        break;
                    case "CO":
                        namemodulo = "Sias.Comissao";
                        break;
                    case "GE":
                        namemodulo = "Sias.Geral";
                        break;
                    case "LT":
                        namemodulo = "Sias.Loterico";
                        break;
                    case "PF":
                        namemodulo = "Sias.PessoaFisica";
                        break;
                    case "SI":
                        namemodulo = "Sias.Sinistro";
                        break;
                    case "VA":
                        namemodulo = "Sias.VidaAzul";
                        break;
                    case "VG":
                        namemodulo = "Sias.VidaEmGrupo";
                        break;

                    default:
                        namemodulo = "Sias.Outros";
                        break;
                }

                files.Convert = true;
                files.Name = name;
                inputmodulo.Name = namemodulo;
                inputmodulo.Files.Add(files);

                var moduloexiste = inputModules.Where(x => x.Name == namemodulo).FirstOrDefault();

                if (moduloexiste != null)
                    moduloexiste.Files.Add(files);
                else
                    inputModules.Add(inputmodulo);

            }

            var fileconfig = JsonConvert.DeserializeObject<FileResolverConfig>(JsonConvert.SerializeObject(FileResolverHelper.Conf));

            //manipulados
            fileconfig.InputDirectory = FileResolverHelper.Conf.OutputDirectory;
            fileconfig.OutputDirectory = FileResolverHelper.Conf.OutputCobolDirectory;
            fileconfig.OutputCobolDirectory = null;

            fileconfig.InputConfig.Modules = inputModules;

            var text = JsonConvert.SerializeObject(fileconfig, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var jsonfile = Path.Combine(Environment.CurrentDirectory, "app.json");
            File.WriteAllText(jsonfile, text);
        }
    }
}
