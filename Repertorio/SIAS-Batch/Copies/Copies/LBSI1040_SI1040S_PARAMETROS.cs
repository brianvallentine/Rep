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
    public class LBSI1040_SI1040S_PARAMETROS : VarBasis
    {
        /*"    03 SI1040S-RAMO-EMISSOR     PIC S9(005) COMP-3*/
        public IntBasis SI1040S_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"    03 SI1040S-COD-OPERACAO     PIC S9(005) COMP-3*/
        public IntBasis SI1040S_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"    03 SI1040S-TIP-REGISTRO     PIC X(01)*/
        public StringBasis SI1040S_TIP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    03 SI1040S-COD-DESPESA      PIC S9(004) COMP*/
        public IntBasis SI1040S_COD_DESPESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    03 SI1040S-RC               PIC 99*/
        public IntBasis SI1040S_RC { get; set; } = new IntBasis(new PIC("9", "2", "99"));
        /*"    03 SI1040S-ERRO-PARAGRAFO   PIC X(003)*/
        public StringBasis SI1040S_ERRO_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"    03 SI1040S-ERRO-SQLCODE     PIC S9(003) COMP-3*/
        public IntBasis SI1040S_ERRO_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"    03 SI1040S-ERRO-MENSAGEM    PIC X(080)*/
        public StringBasis SI1040S_ERRO_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
    }
}