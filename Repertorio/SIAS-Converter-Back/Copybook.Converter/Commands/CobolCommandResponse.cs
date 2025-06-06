using System.Text;

namespace CobolLanguageConverter.Converter.Commands
{
    public class CobolCommandResponse
    {
        public string Error { get; set; } = "";
        public bool Executed { get; set; }
        public bool Success => string.IsNullOrEmpty(Error);
        public StringBuilder Output { get; set; } = new StringBuilder();
        public string Input { get; set; }
        public string AfterExecuted { get; set; }

        public CobolCommandResponse(string input)
        {
            Input = input;
        }

        public void SetResponse(StringBuilder output)
        {
            Output = output;
        }

        public void SetError(Exception ex)
        {
            Error += ex.Message;
        }
    }
}
