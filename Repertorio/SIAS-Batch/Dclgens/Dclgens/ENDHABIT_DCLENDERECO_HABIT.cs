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
    public class ENDHABIT_DCLENDERECO_HABIT : VarBasis
    {
        /*"    10 ENDHABIT-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDHABIT_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDHABIT-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis ENDHABIT_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDHABIT-OPERACAO    PIC S9(4) USAGE COMP.*/
        public IntBasis ENDHABIT_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDHABIT-PONTO-VENDA  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDHABIT_PONTO_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDHABIT-NUM-CONTRATO  PIC S9(9) USAGE COMP.*/
        public IntBasis ENDHABIT_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDHABIT-OCORR-ENDER  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDHABIT_OCORR_ENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDHABIT-NOME-LOGRADOURO  PIC X(35).*/
        public StringBasis ENDHABIT_NOME_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "35", "X(35)."), @"");
        /*"    10 ENDHABIT-CIDADE      PIC X(20).*/
        public StringBasis ENDHABIT_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 ENDHABIT-UF          PIC X(2).*/
        public StringBasis ENDHABIT_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 ENDHABIT-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis ENDHABIT_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDHABIT-SITUACAO    PIC X(1).*/
        public StringBasis ENDHABIT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDHABIT-DATA-SIT-INI  PIC X(10).*/
        public StringBasis ENDHABIT_DATA_SIT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ENDHABIT-USUARIO     PIC X(8).*/
        public StringBasis ENDHABIT_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ENDHABIT-TIMESTAMP   PIC X(26).*/
        public StringBasis ENDHABIT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 ENDHABIT-TIPO-LOGRADOURO  PIC X(3).*/
        public StringBasis ENDHABIT_TIPO_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 ENDHABIT-NUM-IMOVEL  PIC X(5).*/
        public StringBasis ENDHABIT_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 ENDHABIT-COMPL-ENDER  PIC X(15).*/
        public StringBasis ENDHABIT_COMPL_ENDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 ENDHABIT-BAIRRO      PIC X(20).*/
        public StringBasis ENDHABIT_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 ENDHABIT-DATA-SIT-FIM  PIC X(10).*/
        public StringBasis ENDHABIT_DATA_SIT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}