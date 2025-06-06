using IA_ConverterCommons;

using Microsoft.CodeAnalysis;

namespace Copybook.Converter;

public class ReferenceModel
{

    public string? PropertyParent
    {
        get
        {
            var spliter = PropertyName.Split('.');
            if (spliter.Length == 0) return null;

            return spliter.Skip(spliter.Length - 2).FirstOrDefault();
        }
    }
    public string PropertyName { get; set; }
    public string PropertyNameOnModel { get; set; }
    public string CurrentLine { get; set; }
    public string PropertyType { get; set; }
    public bool PropertyIsClass { get; set; }
    public bool PropertyIsCopy { get; set; }
    public int PropertyPrecision { get; set; }
    public List<string> DCLColumns { get; set; } = new List<string>();
    public PIC PIC { get; set; }
    public string Times { get; set; }
    public bool IsRedefine { get; set; }
    public string RedefineName { get; set; }
    public DataTypeModel DataType
    {
        get
        {
            //var ret = DataTypeModel.GetDataType(PIC.CobolType, PIC.FullPic);
            var ret = DataTypeModel.GetDataType(PIC.FullPic, PIC.CobolType);

            return ret;
        }
    }

    private string initialValue;
    public string InitialValue
    {
        get
        {
            var noGoList = new List<string>
            {
                "SPACES",
                "SPACE",
                "ZERO",
                "ZEROS",
                "ZEROES",
                "0",
                "+0",
            };

            if (!noGoList.Contains(initialValue))
                return initialValue;

            return "";
        }
        set => initialValue = value;
    }

    public string IndexedFor { get; set; }
    public string IndexedBy { get; set; }

    public string Namespace { get; set; }

    public ReferenceModel(string propertyName, string propertyType, bool propertyIsClass = false, bool propertyIsCopy = false, PIC pic = null, string initialValue = null, string times = "", bool isRedefine = false, string redefineName = null, List<string> dCLColumns = null, string nameSpace = "", string propertyNameOnModel = "")
    {
        PropertyName = propertyName;
        PropertyNameOnModel = propertyNameOnModel;
        PropertyType = propertyType;
        PropertyIsClass = propertyIsClass;
        PropertyIsCopy = propertyIsCopy;
        PIC = pic;
        InitialValue = initialValue;
        Times = times;
        IsRedefine = isRedefine;
        RedefineName = redefineName;
        DCLColumns = dCLColumns;
        Namespace = nameSpace;
    }
}
