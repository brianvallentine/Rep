using Executor.ConsoleApp;
using Executor.Metadata;
using FileResolver.Helper;
using System.Diagnostics;
using Executor.Metadata.Model;

Console.Clear();
ConfigLoad.Load("appMeta.json");

//var isParallelExecution = FileResolverHelper.Conf.ParallelExecution;
var stopWatchConversion = new Stopwatch();

stopWatchConversion.Start();

//TODO: remover arquivos existentes
var metadataFiles = FileResolverHelper.GetAllInputFiles();
var take = metadataFiles.Length;

if (FileResolverHelper.Conf.InputConfig.AnalisysBlock > 0)
    take = FileResolverHelper.Conf.InputConfig.AnalisysBlock;

Console.WriteLine($"{take}/{metadataFiles.Length} taken metadata");
Console.WriteLine($"");

//var listInputConfigModules = new List<InputConfigModules>();

var errorFiles = new List<MetadataFileModel>();
var okFiles = new List<MetadataFileModel>();

foreach (var item in metadataFiles.Take(take))
{
    var arq = ReadFile.Read(item);

    if (arq != null && string.IsNullOrEmpty(arq.Err))
    {
        //var itemInputConfigModules = new InputConfigModules();
        //var controller = arq.Endpoint.Split('/')[0];
        //var endpoint = arq.Endpoint.Split('/')[1];

        //itemInputConfigModules.Name = controller;
        //itemInputConfigModules.Files.Add(new InputConfigModulesFiles { Name = endpoint, Convert = true, Error = "" });

        //var exist = listInputConfigModules.Where(x => x.Name == controller).FirstOrDefault();
        //if (exist != null)
        //    exist.Files.Add(new InputConfigModulesFiles { Name = endpoint, Convert = true, Error = "" });
        //else
        //    listInputConfigModules.Add(itemInputConfigModules);

        okFiles.Add(arq);
    }
    else
    {
        errorFiles.Add(arq);
        ReadFile.Write(arq.NameFile);
    }
}

JsonGenerator.CreateFileJson(metadataFiles);

try
{
    CobolGenerator.CreateFileCob(okFiles);
    Executor.ConsoleApp.Program.Main(null);
}
catch (Exception ex)
{
    Console.WriteLine(" - Erro grave na conversão do metadado: {0} {1}", Path.GetFileNameWithoutExtension("metadataFile"), ex.Message);
}