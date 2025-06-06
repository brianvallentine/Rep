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
    public class FUNCICEF_DCLFUNCIONARIOS_CEF : VarBasis
    {
        /*"    10 FUNCICEF-COD-SUREG   PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-COD-UNIDADE       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_COD_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-DIG-UNIDADE       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_DIG_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-NOME-UNIDADE       PIC X(40).*/
        public StringBasis FUNCICEF_NOME_UNIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FUNCICEF-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FUNCICEF-NOME-FUNCIONARIO       PIC X(40).*/
        public StringBasis FUNCICEF_NOME_FUNCIONARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FUNCICEF-TIPO-VINCULO       PIC X(13).*/
        public StringBasis FUNCICEF_TIPO_VINCULO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
        /*"    10 FUNCICEF-NASCIMENTO  PIC S9(9) USAGE COMP.*/
        public IntBasis FUNCICEF_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FUNCICEF-NUM-CPF     PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 FUNCICEF-ENDERECO-CEF       PIC X(49).*/
        public StringBasis FUNCICEF_ENDERECO_CEF { get; set; } = new StringBasis(new PIC("X", "49", "X(49)."), @"");
        /*"    10 FUNCICEF-CIDADE-CEF  PIC X(22).*/
        public StringBasis FUNCICEF_CIDADE_CEF { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
        /*"    10 FUNCICEF-SIGLA-UF    PIC X(2).*/
        public StringBasis FUNCICEF_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 FUNCICEF-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis FUNCICEF_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FUNCICEF-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-NUM-CONTA   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_NUM_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FUNCICEF-DIG-CONTA   PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-COD-RUBRICA       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-TIPO1       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_TIPO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-TIPO2       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_TIPO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-TIPO3       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_TIPO3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-VALOR1      PIC S9(7)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_VALOR1 { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(7)V9(2)"), 2);
        /*"    10 FUNCICEF-VALOR2      PIC S9(7)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_VALOR2 { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(7)V9(2)"), 2);
        /*"    10 FUNCICEF-VALOR3      PIC S9(7)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_VALOR3 { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(7)V9(2)"), 2);
        /*"    10 FUNCICEF-MES-VIGENCIA       PIC S9(9) USAGE COMP.*/
        public IntBasis FUNCICEF_MES_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FUNCICEF-COD-ANGARIADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis FUNCICEF_COD_ANGARIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FUNCICEF-CERTIF-PREF       PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_CERTIF_PREF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 FUNCICEF-STATUS731   PIC X(1).*/
        public StringBasis FUNCICEF_STATUS731 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FUNCICEF-PREMIO731   PIC S9(5)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_PREMIO731 { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(5)V9(2)"), 2);
        /*"    10 FUNCICEF-PCT-AUMENTO       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCICEF_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 FUNCICEF-UNIDADE-ORIGEM       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCICEF_UNIDADE_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCICEF-CLASSE-ORIGEM       PIC X(1).*/
        public StringBasis FUNCICEF_CLASSE_ORIGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FUNCICEF-SITUACAO    PIC X(1).*/
        public StringBasis FUNCICEF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}