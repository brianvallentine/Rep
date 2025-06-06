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
    public class SI042_DCLSI_DETALHE_PROC_JURID : VarBasis
    {
        /*"    10 SI042-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI042_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI042-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SI042_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI042-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI042_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI042-COD-PROCESSO-JURID       PIC X(15).*/
        public StringBasis SI042_COD_PROCESSO_JURID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 SI042-COD-USUARIO    PIC X(8).*/
        public StringBasis SI042_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI042-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis SI042_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}