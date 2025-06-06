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
    public class AGENCIAS_DCLAGENCIAS : VarBasis
    {
        /*"    10 AGENCIAS-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis AGENCIAS_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGENCIAS-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis AGENCIAS_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGENCIAS-DAC-AGENCIA       PIC X(1).*/
        public StringBasis AGENCIAS_DAC_AGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGENCIAS-NOME-AGENCIA       PIC X(40).*/
        public StringBasis AGENCIAS_NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 AGENCIAS-CIDADE      PIC X(20).*/
        public StringBasis AGENCIAS_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 AGENCIAS-SIGLA-UF    PIC X(2).*/
        public StringBasis AGENCIAS_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 AGENCIAS-ENDERECO    PIC X(40).*/
        public StringBasis AGENCIAS_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 AGENCIAS-TELEFONE    PIC S9(9) USAGE COMP.*/
        public IntBasis AGENCIAS_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AGENCIAS-DDD         PIC S9(4) USAGE COMP.*/
        public IntBasis AGENCIAS_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGENCIAS-FAX         PIC S9(9) USAGE COMP.*/
        public IntBasis AGENCIAS_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AGENCIAS-TELEX       PIC S9(9) USAGE COMP.*/
        public IntBasis AGENCIAS_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AGENCIAS-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis AGENCIAS_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AGENCIAS-TIPO-CONTA  PIC X(1).*/
        public StringBasis AGENCIAS_TIPO_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGENCIAS-NUM-CTA-CORRENTE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis AGENCIAS_NUM_CTA_CORRENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 AGENCIAS-DAC-CTA-CORRENTE       PIC X(1).*/
        public StringBasis AGENCIAS_DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGENCIAS-SIT-REGISTRO       PIC X(1).*/
        public StringBasis AGENCIAS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGENCIAS-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis AGENCIAS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}