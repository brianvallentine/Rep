using IBM.Data.Db2;

namespace IA_ConverterCommons;

public class SQLCA : VarBasis
{
    public SQLCA(int sqlCode = 0)
    {
        SQLCODE.Value = sqlCode;
    }

    public SQLCA(SQLCA sqlca)
    {
        SQLCODE.Value = sqlca.SQLCODE.Value;
        SQLERRMC.Value = sqlca.SQLERRMC.Value;
        SQLSTATE.Value = sqlca.SQLSTATE.Value;
        SQLERRD.Items = sqlca.SQLERRD.Items;
        SQLCAID.Value = sqlca.SQLCAID.Value;
        SQLCABC.Value = sqlca.SQLCABC.Value;
        SQLERRP.Value = sqlca.SQLERRP.Value;
        SQLWARN.Value = sqlca.SQLWARN.Value;
    }

    public IntBasis SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
    public StringBasis SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(70)"));
    public StringBasis SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(5)"));
    public ListBasis<StringBasis> SQLERRD { get; set; } = new ListBasis<StringBasis>(7);
    public StringBasis SQLCAID { get; set; } = new StringBasis(new PIC("X", "8", "X(8)"));
    public IntBasis SQLCABC { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
    public StringBasis SQLERRP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."));
    public StringBasis SQLWARN { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."));


}
