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
    public class GE100_DCLGE_CONTROLE_INTERF_SAP : VarBasis
    {
        /*"    10 GE100-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE100_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE100-COD-IDLG       PIC X(40).*/
        public StringBasis GE100_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE100-DTA-MOVIMENTO-LEGADO       PIC X(10).*/
        public StringBasis GE100_DTA_MOVIMENTO_LEGADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE100-DTH-GERACAO-LEGADO       PIC X(26).*/
        public StringBasis GE100_DTH_GERACAO_LEGADO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE100-DTH-GERACAO-ARQA       PIC X(26).*/
        public StringBasis GE100_DTH_GERACAO_ARQA { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE100-COD-IDE-PAGTO-SAP       PIC X(10).*/
        public StringBasis GE100_COD_IDE_PAGTO_SAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE100-COD-IDE-RECEBE-SAP       PIC X(12).*/
        public StringBasis GE100_COD_IDE_RECEBE_SAP { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
        /*"    10 GE100-DTH-PROCESSA-ARQG       PIC X(10).*/
        public StringBasis GE100_DTH_PROCESSA_ARQG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE100-IND-ACEITE-SAP       PIC S9(4) USAGE COMP.*/
        public IntBasis GE100_IND_ACEITE_SAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE100-DTA-MOVIMENTO-ARQH       PIC X(10).*/
        public StringBasis GE100_DTA_MOVIMENTO_ARQH { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}