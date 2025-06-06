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
    public class FONTES_DCLFONTES : VarBasis
    {
        /*"    10 FONTES-COD-FONTE     PIC S9(4) USAGE COMP.*/
        public IntBasis FONTES_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FONTES-TIPO-FONTE    PIC X(1).*/
        public StringBasis FONTES_TIPO_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FONTES-NOME-FONTE    PIC X(40).*/
        public StringBasis FONTES_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FONTES-ORGAO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis FONTES_ORGAO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FONTES-REGIAO        PIC S9(4) USAGE COMP.*/
        public IntBasis FONTES_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FONTES-ENDERECO      PIC X(40).*/
        public StringBasis FONTES_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FONTES-BAIRRO        PIC X(20).*/
        public StringBasis FONTES_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 FONTES-CEP           PIC S9(9) USAGE COMP.*/
        public IntBasis FONTES_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FONTES-CIDADE        PIC X(20).*/
        public StringBasis FONTES_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 FONTES-SIGLA-UF      PIC X(2).*/
        public StringBasis FONTES_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 FONTES-DDD           PIC S9(4) USAGE COMP.*/
        public IntBasis FONTES_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FONTES-TELEFONE      PIC S9(9) USAGE COMP.*/
        public IntBasis FONTES_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FONTES-TELEX         PIC S9(9) USAGE COMP.*/
        public IntBasis FONTES_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FONTES-CGCCPF        PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FONTES_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FONTES-INSC-ESTADUAL  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FONTES_INSC_ESTADUAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FONTES-INSC-PREFEITURA  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FONTES_INSC_PREFEITURA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FONTES-TITULAR-FONTE  PIC X(40).*/
        public StringBasis FONTES_TITULAR_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FONTES-SIT-REGISTRO  PIC X(1).*/
        public StringBasis FONTES_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FONTES-VINCU-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis FONTES_VINCU_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FONTES-ANTEC-EMIS-CHEQ  PIC S9(4) USAGE COMP.*/
        public IntBasis FONTES_ANTEC_EMIS_CHEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FONTES-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis FONTES_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FONTES-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis FONTES_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FONTES-ULT-PROP-AUTOMAT  PIC S9(9) USAGE COMP.*/
        public IntBasis FONTES_ULT_PROP_AUTOMAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FONTES-COD-BANCO     PIC S9(4) USAGE COMP.*/
        public IntBasis FONTES_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FONTES-COD-AGENCIA   PIC S9(4) USAGE COMP.*/
        public IntBasis FONTES_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FONTES-COD-EMPRESA   PIC S9(9) USAGE COMP.*/
        public IntBasis FONTES_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FONTES-COD-SUPERINTEND  PIC S9(9) USAGE COMP.*/
        public IntBasis FONTES_COD_SUPERINTEND { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FONTES-TIMESTAMP     PIC X(26).*/
        public StringBasis FONTES_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FONTES-PCT-DESC-ISS  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis FONTES_PCT_DESC_ISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 FONTES-EMAIL         PIC X(40).*/
        public StringBasis FONTES_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FONTES-NOME-ABREV-FONTE  PIC X(5).*/
        public StringBasis FONTES_NOME_ABREV_FONTE { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"*/
    }
}