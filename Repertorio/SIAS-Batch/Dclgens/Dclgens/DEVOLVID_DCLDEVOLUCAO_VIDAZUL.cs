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
    public class DEVOLVID_DCLDEVOLUCAO_VIDAZUL : VarBasis
    {
        /*"    10 DEVOLVID-COD-DEVOLUCAO  PIC S9(4) USAGE COMP.*/
        public IntBasis DEVOLVID_COD_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DEVOLVID-DESC-DEVOLUCAO.*/
        public DEVOLVID_DEVOLVID_DESC_DEVOLUCAO DEVOLVID_DESC_DEVOLUCAO { get; set; } = new DEVOLVID_DEVOLVID_DESC_DEVOLUCAO();

        public StringBasis DEVOLVID_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 DEVOLVID-TIMESTAMP   PIC X(26).*/
        public StringBasis DEVOLVID_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}