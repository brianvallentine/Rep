using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class DEVOLVID_DEVOLVID_DESC_DEVOLUCAO : VarBasis
    {
        /*"       49 DEVOLVID-DESC-DEVOLUCAO-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis DEVOLVID_DESC_DEVOLUCAO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 DEVOLVID-DESC-DEVOLUCAO-TEXT  PIC X(120).*/
        public StringBasis DEVOLVID_DESC_DEVOLUCAO_TEXT { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
        /*"    10 DEVOLVID-COD-USUARIO  PIC X(8).*/
    }
}