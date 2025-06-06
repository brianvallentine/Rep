using CobolLanguageConverter.Converter.CobolDivisions;
using CobolLanguageConverter.Converter.DIVISION;
using CodeAnalyser.Helper;
using Copybook.Converter;
using FileResolver.Helper;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;

namespace Cobol.Converter;

public class CobolConverter
{
    private readonly string filePath;
    private Dictionary<string, string> sectionDictionary = new Dictionary<string, string>();
    private bool hasReturnCode = false;
    public string VALID_LINES = "";
    public ResultSet Result = new ResultSet();
    public static Stopwatch StopWatch { get; set; } = new Stopwatch();

    public CobolConverter(string filePath)
    {
        this.filePath = filePath;
    }

    #region GENERIC
    public string Run()
    {
        var allCommands = ConvertHelper.FindCommands<IConverterCommand>(Assembly.GetExecutingAssembly()).OrderBy(x => x.Order);
        var divisionAndLines = new Dictionary<string, List<CurrentLineType>>();
        //var lines = File.ReadAllText(filePath);
        var lines = SanitizedReadFileLines(filePath);
        var ret = lines;
        Result.programName = Path.GetFileNameWithoutExtension(filePath);
        Result.module = FileResolverHelper.Conf?.InputConfig?.Modules?.FirstOrDefault(x => x.Files.Any(f => Path.GetFileNameWithoutExtension(f.Name) == Result?.programName))?.Name;

        //DIVISIONS WORKER
        foreach (var command in allCommands)
        {
            command.Result = Result;
            ret = command.Execute(ret, ref divisionAndLines);

            if (FileResolverHelper.Conf.LogTimeLine)
                Console.WriteLine($"Comando -> {command.GetType().Name} em {StopWatch.Elapsed.ToString()}");

            StopWatch.Restart();
        }

        return ret;
    }
    #endregion

    private string SanitizedReadFileLines(string filePath)
    {
        // Realizar a leitura de baixo nível com FileStream
        using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        // Buffer para armazenar os bytes lidos
        var buffer = new byte[1024];
        var bytesRead = 0;

        // StringBuilder para armazenar o texto convertido
        var contentBuilder = new StringBuilder();

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        // Ler o arquivo em blocos
        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
        {
            // Interpreta os bytes como Latin1 (ou Windows-1252, se preferir)
            //var content = Encoding.GetEncoding("Windows-1252").GetString(buffer, 0, bytesRead);
            var content = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            // Corrige as quebras de linha (de LF para CRLF, por exemplo)
            var contentLineEndingsFormat = content.ReplaceLineEndings();

            // Remove caracteres inválidos do Unicode, se existirem
            var sanitizedContent = RemoveInvalidUnicodeCharacters(contentLineEndingsFormat);

            // Adiciona ao StringBuilder
            contentBuilder.Append(sanitizedContent);
        }

        return contentBuilder.ToString();
    }

    // Função para substituir caracteres Unicode inválidos
    static string RemoveInvalidUnicodeCharacters(string input)
    {
        var builder = new StringBuilder();

        foreach (char c in input)
        {
            // Verifica se o caractere é válido no intervalo Unicode
            if (char.IsControl(c) && c == '\0') // Permite \n, \r, \t
            {
                builder.Append('\n'); // Substitui o caractere inválido por '�' ou outro caractere
            }
            else
            {
                builder.Append(c); // Adiciona o caractere válido
            }
        }

        return builder.ToString();
    }
}
