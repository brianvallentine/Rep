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
    public class LBFPF012_REG_ENDERECO : VarBasis
    {
        /*"     10  R2-TIPO-REG                 PIC  X(001)*/
        public StringBasis R2_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R2-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R2_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R2-TIPO-ENDER               PIC  9(001)*/
        public IntBasis R2_TIPO_ENDER { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R2-ENDERECO                 PIC  X(050)*/
        public StringBasis R2_ENDERECO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"     10  R2-BAIRRO                   PIC  X(030)*/
        public StringBasis R2_BAIRRO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"     10  R2-CIDADE                   PIC  X(035)*/
        public StringBasis R2_CIDADE { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
        /*"     10  R2-SIGLA-UF                 PIC  X(002)*/
        public StringBasis R2_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"     10  R2-CEP                      PIC  9(008)*/
        public IntBasis R2_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  FILLER                      PIC  X(159)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "159", "X(159)"), @"");
        /*"*/
    }
}