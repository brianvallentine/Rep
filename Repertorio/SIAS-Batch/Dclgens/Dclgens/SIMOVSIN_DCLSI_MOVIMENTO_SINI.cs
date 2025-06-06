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
    public class SIMOVSIN_DCLSI_MOVIMENTO_SINI : VarBasis
    {
        /*"    10 SIMOVSIN-COD-ESTIPULANTE       PIC S9(9) USAGE COMP.*/
        public IntBasis SIMOVSIN_COD_ESTIPULANTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIMOVSIN-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-NUM-CONTR-ESTIP       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIMOVSIN_NUM_CONTR_ESTIP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIMOVSIN-NUM-OCORR-MOVSIN       PIC S9(9) USAGE COMP.*/
        public IntBasis SIMOVSIN_NUM_OCORR_MOVSIN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIMOVSIN-TIPO-SINISTRO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_TIPO_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-DATA-SINISTRO       PIC X(10).*/
        public StringBasis SIMOVSIN_DATA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOVSIN-PERC-PARTICIPACAO       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SIMOVSIN_PERC_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SIMOVSIN-VAL-INDENIZACAO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SIMOVSIN_VAL_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SIMOVSIN-HORARIO-VISTORIA       PIC X(1).*/
        public StringBasis SIMOVSIN_HORARIO_VISTORIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIMOVSIN-TELEFONE-CONTATO       PIC X(15).*/
        public StringBasis SIMOVSIN_TELEFONE_CONTATO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 SIMOVSIN-OUTRO-ENDERECO       PIC X(1).*/
        public StringBasis SIMOVSIN_OUTRO_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIMOVSIN-ENDERECO-ANTERIOR       PIC X(30).*/
        public StringBasis SIMOVSIN_ENDERECO_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SIMOVSIN-LOCAL-CHAVES       PIC X(30).*/
        public StringBasis SIMOVSIN_LOCAL_CHAVES { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SIMOVSIN-NOME-PROCURADOR       PIC X(40).*/
        public StringBasis SIMOVSIN_NOME_PROCURADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIMOVSIN-OBSERVACAO  PIC X(100).*/
        public StringBasis SIMOVSIN_OBSERVACAO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 SIMOVSIN-COD-GIAFI   PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_COD_GIAFI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-CODUNO      PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_CODUNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-NOME-SEGURADO       PIC X(40).*/
        public StringBasis SIMOVSIN_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIMOVSIN-ENDERECO-SINISTRO       PIC X(65).*/
        public StringBasis SIMOVSIN_ENDERECO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "65", "X(65)."), @"");
        /*"    10 SIMOVSIN-CGCCPF-SEGURADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SIMOVSIN_CGCCPF_SEGURADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIMOVSIN-DATA-NASCIMENTO       PIC X(10).*/
        public StringBasis SIMOVSIN_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOVSIN-SEXO        PIC X(1).*/
        public StringBasis SIMOVSIN_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIMOVSIN-CIDADE      PIC X(25).*/
        public StringBasis SIMOVSIN_CIDADE { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 SIMOVSIN-SIGLA-UF    PIC X(2).*/
        public StringBasis SIMOVSIN_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SIMOVSIN-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis SIMOVSIN_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIMOVSIN-TIPO-IMOVEL       PIC X(1).*/
        public StringBasis SIMOVSIN_TIPO_IMOVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIMOVSIN-SITUACAO-SINI       PIC X(1).*/
        public StringBasis SIMOVSIN_SITUACAO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIMOVSIN-DATA-SIT-INI       PIC X(10).*/
        public StringBasis SIMOVSIN_DATA_SIT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOVSIN-NATUREZA-SINISTRO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_NATUREZA_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-DATA-MOVTO-SINI       PIC X(10).*/
        public StringBasis SIMOVSIN_DATA_MOVTO_SINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOVSIN-DATA-GERACAO-ESTIP       PIC X(10).*/
        public StringBasis SIMOVSIN_DATA_GERACAO_ESTIP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOVSIN-TIMESTAMP   PIC X(26).*/
        public StringBasis SIMOVSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SIMOVSIN-COD-ASHAB   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SIMOVSIN_COD_ASHAB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SIMOVSIN-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-NUM-PROTOCOLO-SINI       PIC S9(9) USAGE COMP.*/
        public IntBasis SIMOVSIN_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIMOVSIN-DAC-PROTOCOLO-SINI       PIC X(1).*/
        public StringBasis SIMOVSIN_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIMOVSIN-OCORR-SEGURADO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_OCORR_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-RAMO-EMISSOR       PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-DATA-COMUNICADO       PIC X(10).*/
        public StringBasis SIMOVSIN_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIMOVSIN-COD-SUBESTIPULANTE       PIC S9(9) USAGE COMP.*/
        public IntBasis SIMOVSIN_COD_SUBESTIPULANTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIMOVSIN-COD-ORIG-MOVIMENTO       PIC X(2).*/
        public StringBasis SIMOVSIN_COD_ORIG_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SIMOVSIN-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOVSIN_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOVSIN-NOM-EMAIL   PIC X(50).*/
        public StringBasis SIMOVSIN_NOM_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 SIMOVSIN-NUM-COMUNICADO       PIC S9(9) USAGE COMP.*/
        public IntBasis SIMOVSIN_NUM_COMUNICADO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}