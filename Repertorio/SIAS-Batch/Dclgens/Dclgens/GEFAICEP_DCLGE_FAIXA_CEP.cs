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
    public class GEFAICEP_DCLGE_FAIXA_CEP : VarBasis
    {
        /*"    10 GEFAICEP-CEP-INICIAL  PIC S9(9) USAGE COMP.*/
        public IntBasis GEFAICEP_CEP_INICIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEFAICEP-CEP-FINAL   PIC S9(9) USAGE COMP.*/
        public IntBasis GEFAICEP_CEP_FINAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEFAICEP-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis GEFAICEP_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEFAICEP-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis GEFAICEP_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEFAICEP-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis GEFAICEP_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEFAICEP-DESCRICAO-FAIXA  PIC X(72).*/
        public StringBasis GEFAICEP_DESCRICAO_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GEFAICEP-CENTRALIZADOR  PIC X(72).*/
        public StringBasis GEFAICEP_CENTRALIZADOR { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GEFAICEP-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis GEFAICEP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEFAICEP-TIMESTAMP   PIC X(26).*/
        public StringBasis GEFAICEP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GEFAICEP-SIGLA-UF    PIC X(2).*/
        public StringBasis GEFAICEP_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}