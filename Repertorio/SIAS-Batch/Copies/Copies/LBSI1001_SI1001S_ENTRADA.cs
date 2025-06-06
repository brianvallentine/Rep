using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBSI1001_SI1001S_ENTRADA : VarBasis
    {
        /*"    10    SI1001S-IDE-SISTEMA          PIC   X(002)*/
        public StringBasis SI1001S_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"    10    SI1001S-IDE-SISTEMA-OPER     PIC   X(002)*/
        public StringBasis SI1001S_IDE_SISTEMA_OPER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"    10    SI1001S-COD-FUNCAO           PIC  S9(009) COMP*/
        public IntBasis SI1001S_COD_FUNCAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"    10    SI1001S-NUM-APOL-SINISTRO    PIC  S9(013) COMP-3*/
        public IntBasis SI1001S_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"    10    SI1001S-COD-PRODUTO          PIC  S9(004) COMP*/
        public IntBasis SI1001S_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    10    SI1001S-RAMO                 PIC  S9(004) COMP*/
        public IntBasis SI1001S_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    10    SI1001S-DATA-INICIO          PIC   X(010)*/
        public StringBasis SI1001S_DATA_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"    10    SI1001S-DATA-FIM             PIC   X(010)*/
        public StringBasis SI1001S_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05      SI1001S-SAIDA*/
    }
}