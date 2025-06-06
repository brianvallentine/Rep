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
    public class LBSI0005_TAB_MENSAGENS : VarBasis
    {
        /*"    10       FILLER            PIC  X(060)    VALUE         '01COD LOTERICO NAO NUMERICO'*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"01COD LOTERICO NAO NUMERICO");
        /*"    10       FILLER            PIC  X(060)    VALUE         '02DATA DA OCORRENCIA NAO NUMERICA   '*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"02DATA DA OCORRENCIA NAO NUMERICA   ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '03HORA DA OCORRENCIA NAO NUMERICA '*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"03HORA DA OCORRENCIA NAO NUMERICA ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '04DATA DA GERACAO DO ARQUIVO NAO NUMERICA '*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"04DATA DA GERACAO DO ARQUIVO NAO NUMERICA ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '05DATA DO AVISO NAO NUMERICA '*/
        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"05DATA DO AVISO NAO NUMERICA ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '06HORA DO AVISO NAO NUMERICA '*/
        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"06HORA DO AVISO NAO NUMERICA ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '07DATA DO ULTIMO DOCUMENTO NAO NUMERICO  '*/
        public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"07DATA DO ULTIMO DOCUMENTO NAO NUMERICO  ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '08VALOR INFORMADO DO SINISTRO NAO NUMERICO'*/
        public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"08VALOR INFORMADO DO SINISTRO NAO NUMERICO");
        /*"    10       FILLER            PIC  X(060)    VALUE         '09CODIGO DA NATUREZA NAO NUMERICO   '*/
        public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"09CODIGO DA NATUREZA NAO NUMERICO   ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '10CODIGO DA CAUSA NAO NUMERICO    '*/
        public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"10CODIGO DA CAUSA NAO NUMERICO    ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '11VALOR DO SINISTRO NAO INFORMADO  '*/
        public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"11VALOR DO SINISTRO NAO INFORMADO  ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '12DATA DA OCORRENCIA INVALIDA      '*/
        public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"12DATA DA OCORRENCIA INVALIDA      ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '13DATA DA GERACAO INVALIDA         '*/
        public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"13DATA DA GERACAO INVALIDA         ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '14DATA DO AVISO INVALIDA          '*/
        public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"14DATA DO AVISO INVALIDA          ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '15DATA DO ULTIMO DOCUMENTO INVALIDA'*/
        public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"15DATA DO ULTIMO DOCUMENTO INVALIDA");
        /*"    10       FILLER            PIC  X(060)    VALUE         '16DATA DO AVISO ANTERIOR A OCORRENCIA  '*/
        public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"16DATA DO AVISO ANTERIOR A OCORRENCIA  ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '17DATA DA DA GERACAO ANTERIOR A OCORRENCIA '*/
        public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"17DATA DA DA GERACAO ANTERIOR A OCORRENCIA ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '18DATA ULTIMO DOC ANTERIOR A DATA DO AVISO '*/
        public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"18DATA ULTIMO DOC ANTERIOR A DATA DO AVISO ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '19DATA ULTIMO DOC POSTERIOR A DATA DA GERACAO'*/
        public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"19DATA ULTIMO DOC POSTERIOR A DATA DA GERACAO");
        /*"    10       FILLER            PIC  X(060)    VALUE         '20DATA DA OCORRENCIA INVALIDA      '*/
        public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"20DATA DA OCORRENCIA INVALIDA      ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '21HORA DO AVISO INVALIDA            '*/
        public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"21HORA DO AVISO INVALIDA            ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '22LOTERICO NAO ESTA VIGENTE NA DATA DA OCORRENCIA '*/
        public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"22LOTERICO NAO ESTA VIGENTE NA DATA DA OCORRENCIA ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '23JA EXISTE SINISTRO ATIVO NA MESMA  DATA DE OCOR.'*/
        public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"23JA EXISTE SINISTRO ATIVO NA MESMA  DATA DE OCOR.");
        /*"    10       FILLER            PIC  X(060)    VALUE         '24CODIGO DA NATUREZ INVALIDO      '*/
        public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"24CODIGO DA NATUREZ INVALIDO      ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '25CODIGO DA CAUS INVALIDO PARA A NATUREZA '*/
        public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"25CODIGO DA CAUS INVALIDO PARA A NATUREZA ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '26LORTERICO NAO POSSUI COBERTURA PARA A NATUREZA'*/
        public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"26LORTERICO NAO POSSUI COBERTURA PARA A NATUREZA");
        /*"    10       FILLER            PIC  X(060)    VALUE         '27PRE.LIB DE ADIANT.PENDENTE DE LIBERACAO '*/
        public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"27PRE.LIB DE ADIANT.PENDENTE DE LIBERACAO ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '28(1)-SIN INF A FRANQUIA DE VALORES R$ 500,00'*/
        public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"28(1)-SIN INF A FRANQUIA DE VALORES R$ 500,00");
        /*"    10       FILLER            PIC  X(060)    VALUE         '29(1)-SIN INF A FRANQUIA DE DANOSELET R$ 600,00'*/
        public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"29(1)-SIN INF A FRANQUIA DE DANOSELET R$ 600,00");
        /*"    10      FILLER            PIC  X(060)    VALUE         '30(1)-SIN INF A FRANQUIA DE R.C. R$ 1000,00'*/
        public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"30(1)-SIN INF A FRANQUIA DE R.C. R$ 1000,00");
        /*"    10       FILLER            PIC  X(060)    VALUE         '31INDICADOR DE ADIANTAMENTO OBRIG. P/ROUBO EM TRANS'*/
        public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"31INDICADOR DE ADIANTAMENTO OBRIG. P/ROUBO EM TRANS");
        /*"    10       FILLER            PIC  X(060)    VALUE         '32QTD.DE PORTADORES OBRIG.P/ROUBO EM TRANS '*/
        public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"32QTD.DE PORTADORES OBRIG.P/ROUBO EM TRANS ");
        /*"    10       FILLER            PIC  X(060)    VALUE         '33*** GERADO AUTOMATICO A PRELIB/LIB DE ADIANT.'*/
        public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"33*** GERADO AUTOMATICO A PRELIB/LIB DE ADIANT.");
        /*"    10       FILLER            PIC  X(060)    VALUE         '34*** VALOR AVISADO SUPERIOR A 200.000,00     '*/
        public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"34*** VALOR AVISADO SUPERIOR A 200.000,00     ");
        /*"  05         TAB-MENSAGENS-R    REDEFINES TAB-MENSAGENS*/
    }
}