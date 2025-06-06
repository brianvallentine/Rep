using FileResolver.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Executor.ConsoleApp;

public class BuildAndShowProcess
{
    public static void BuildAndShowFromData()
    {
        Console.WriteLine($"");
        Console.WriteLine($"Starting Build and show...");

        try
        {
            var resultConfig = JsonConvert.DeserializeObject<FileResolverConfig>(JsonConvert.SerializeObject(FileResolverHelper.Conf)) ?? new FileResolverConfig();
            resultConfig.BuildAndShow = false;
            resultConfig.JustAnalyse = false;
            resultConfig.ParallelExecution = false;

            var beforeProg = false;
            var progBefore = "";
            if (string.IsNullOrEmpty(progBefore)) beforeProg = true;

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            foreach (var module in resultConfig.InputConfig.Modules)
            {
                foreach (var file in module.Files)
                {
                    if (!file.Convert)
                    {
                        if (file.Name.Contains(progBefore)) beforeProg = true;
                        if (!beforeProg) continue;

                        file.OnlyMe = true;
                        file.ReadBuildMark = true;

                        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "app.json"), JsonConvert.SerializeObject(resultConfig, Formatting.Indented, new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            ContractResolver = contractResolver,
                        }));

                        Program.Main(null);
                        Console.Clear();
                        //rodar programa
                        //fazer análise: dando certo convert para true

                        var buildSuccess = CompilarSln(Path.Combine(Directory.GetCurrentDirectory(), resultConfig.OutputDirectory, resultConfig.SolutionName, $"{resultConfig.SolutionName}.sln"));
                        if (buildSuccess)
                        {
                            file.Convert = true;
                        }

                        file.OnlyMe = null;
                        Thread.Sleep(200);

                        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "outApp.json"), JsonConvert.SerializeObject(resultConfig, Formatting.Indented, new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            ContractResolver = contractResolver,
                        }));
                    }
                }
            }

            resultConfig.BuildAndShow = true;
            resultConfig.JustAnalyse = true;
            resultConfig.ParallelExecution = true;

            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "outApp.json"), JsonConvert.SerializeObject(resultConfig, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver,
            }));
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERR -> " + ex.Message);
        }
    }

    public static bool CompilarSln(string caminhoSln)
    {
        try
        {
            var processInfo = new ProcessStartInfo("dotnet", $"build {caminhoSln}")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processInfo))
            {
                process.OutputDataReceived += (sender, args) =>
                {
                    if (args?.Data?.Contains(Environment.CurrentDirectory) != true)
                        Console.WriteLine(args?.Data);
                };

                process.ErrorDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrEmpty(args?.Data))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"ERROR: {args.Data}");
                        Console.ResetColor();
                    }
                };

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Compilação bem-sucedida!");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"A compilação falhou com código de erro: {process.ExitCode}");
                    Console.ResetColor();
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
        }

        return false;
    }
}
