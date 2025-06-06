using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using Executor.Metadata.Model;
using FileResolver.Helper;

namespace Executor.Metadata
{
    public static class ReadFile
    {
        public static MetadataFileModel? Read(string path)
        {
            var file = new MetadataFileModel();
            var stream = string.Join(" ", System.IO.File.ReadAllLines(path));
            try
            {

                file = JsonSerializer.Deserialize<MetadataFileModel>(stream);
                if (string.IsNullOrEmpty(file?.Endpoint))
                    file.Endpoint = $"{string.Join("/", path.Split("\\").TakeLast(2)).Replace(".json", "")}";

                file.NameFile = file.Endpoint.Split("/")[1];
            }
            catch
            {
                try
                {
                    var filebroked = JsonSerializer.Deserialize<FileBroked>(stream);
                    if (string.IsNullOrEmpty(filebroked.Endpoint))
                    {
                        filebroked.Endpoint = $"{string.Join("/", path.Split("\\").TakeLast(2)).Replace(".json", "")}";
                    }
                    filebroked.NomeArquivo = filebroked.Endpoint.Split("/")[1];
                    file = filebroked.Map();
                }
                catch (Exception ex)
                {
                    file.Err = ex.Message;
                    file.NameFile = path;
                }

            }
            return file;
        }

        public static void Write(string? arquivo)
        {
            try
            {
                var logPathFile = Path.Combine("Log", "log.txt");
                File.AppendAllText(logPathFile, arquivo);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
