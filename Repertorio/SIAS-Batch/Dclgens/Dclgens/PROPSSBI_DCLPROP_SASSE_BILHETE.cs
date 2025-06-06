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
    public class PROPSSBI_DCLPROP_SASSE_BILHETE : VarBasis
    {
        /*"    10 PROPSSBI-NUM-IDENTIFICACAO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPSSBI_NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPSSBI-RENOVACAO-AUTOM  PIC X(1).*/
        public StringBasis PROPSSBI_RENOVACAO_AUTOM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPSSBI-COD-USUARIO  PIC X(8).*/
        public StringBasis PROPSSBI_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROPSSBI-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPSSBI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPSSBI-DATA-INCLUSAO  PIC X(10).*/
        public StringBasis PROPSSBI_DATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PROPSSBI-NUM-TP-MORA-IMOVEL  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPSSBI_NUM_TP_MORA_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}