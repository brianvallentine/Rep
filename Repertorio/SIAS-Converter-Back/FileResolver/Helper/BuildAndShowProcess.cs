using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileResolver.Helper
{
    public class BuildAndShowProcess
    {
        public static void BuildAndShowFromData()
        {
            Console.WriteLine($"");
            Console.WriteLine($"Starting Build and show...");

            try
            {
                var resultConfig = JsonConvert.DeserializeObject<FileResolverConfig>(JsonConvert.SerializeObject(FileResolverHelper.Conf)) ?? new FileResolverConfig();

                foreach (var module in resultConfig.InputConfig.Modules)
                {
                    foreach (var file in module.Files)
                    {
                        if (!file.Convert)
                        {
                            file.OnlyMe = true;

                            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "app.json"), JsonConvert.SerializeObject(resultConfig, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
                            
                            //rodar programa
                            
                            //fazer análise: dando certo convert para true

                            file.OnlyMe = false;
                        }
                    }
                }

                File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "outApp.json"), JsonConvert.SerializeObject(resultConfig, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERR -> " + ex.Message);
            }
        }
    }
}
