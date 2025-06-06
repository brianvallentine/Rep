using Dapper;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;

namespace IA_ConverterCommons;

public class DatabaseBasis
{
    static DatabaseBasis()
    {
        Clear();
    }

    public static IntBasis SQLCODE { get; set; }
    public static StringBasis SQLERRMC { get; set; }
    public static StringBasis SQLSTATE { get; set; }
    public static ListBasis<StringBasis> SQLERRD { get; set; }
    public static StringBasis SQLCAID { get; set; }
    public static IntBasis SQLCABC { get; set; }
    public static StringBasis SQLERRP { get; set; }
    public static StringBasis SQLWARN { get; set; }

    [JsonIgnore]
    public SQLCA SQLCA_Internal { get; set; } = new SQLCA();

    public static void Clear()
    {
        SQLCODE = new IntBasis(new PIC("9", "4", "9(4)"));
        SQLERRMC = new StringBasis(new PIC("X", "70", "X(70)"));
        SQLSTATE = new StringBasis(new PIC("X", "5", "X(5)"));
        SQLERRD = new ListBasis<StringBasis>(7);
        SQLCAID = new StringBasis(new PIC("X", "8", "X(8)"));
        SQLCABC = new IntBasis(new PIC("9", "4", "9(4)"));
        SQLERRP = new StringBasis(new PIC("X", "8", "X(8)."));
        SQLWARN = new StringBasis(new PIC("X", "8", "X(8)."));
    }

    public static string SQLCA
    {
        get
        {
            return
                SQLCODE.GetMoveValues() +
                SQLERRMC.GetMoveValues() +
                SQLSTATE.GetMoveValues() +
                SQLERRD.GetMoveValues() +
                SQLCAID.GetMoveValues() +
                SQLCABC.GetMoveValues() +
                SQLERRP.GetMoveValues() +
                SQLWARN.GetMoveValues();
        }
    }
}