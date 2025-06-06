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
    public class EMISSDIA_DCLEMISSAO_DIARIA : VarBasis
    {
        /*"    10 EMISSDIA-COD-RELATORIO  PIC X(8).*/
        public StringBasis EMISSDIA_COD_RELATORIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 EMISSDIA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis EMISSDIA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 EMISSDIA-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis EMISSDIA_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EMISSDIA-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis EMISSDIA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EMISSDIA-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis EMISSDIA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMISSDIA-ORGAO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis EMISSDIA_ORGAO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EMISSDIA-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis EMISSDIA_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EMISSDIA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis EMISSDIA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EMISSDIA-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis EMISSDIA_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EMISSDIA-COD-CORRETOR  PIC S9(9) USAGE COMP.*/
        public IntBasis EMISSDIA_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EMISSDIA-SIT-REGISTRO  PIC X(1).*/
        public StringBasis EMISSDIA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EMISSDIA-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis EMISSDIA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EMISSDIA-TIMESTAMP   PIC X(26).*/
        public StringBasis EMISSDIA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}