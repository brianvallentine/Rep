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
    public class SINISCON_DCLSINISTRO_CONTROLE : VarBasis
    {
        /*"    10 SINISCON-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-NUM-PROTOCOLO-SINI       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISCON_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISCON-DAC-PROTOCOLO-SINI       PIC X(1).*/
        public StringBasis SINISCON_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCON-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINISCON_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINISCON-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-PEND-VISTORIA       PIC X(1).*/
        public StringBasis SINISCON_PEND_VISTORIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCON-PEND-RESSEGURO       PIC X(1).*/
        public StringBasis SINISCON_PEND_RESSEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCON-SIT-REGISTRO       PIC X(1).*/
        public StringBasis SINISCON_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCON-PEND-VIST-COMPL       PIC X(1).*/
        public StringBasis SINISCON_PEND_VIST_COMPL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISCON-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISCON_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISCON-TIMESTAMP   PIC X(26).*/
        public StringBasis SINISCON_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINISCON-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SINISCON_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SINISCON-RAMO-EMISSOR       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-COD-CAUSA   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-COD-SUREG   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-NUM-CONTRATO       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISCON_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISCON-CONTRATO-DIGITO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISCON_CONTRATO_DIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISCON-DATA-OCORRENCIA       PIC X(10).*/
        public StringBasis SINISCON_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISCON-NOM-SISTEMA-ORIGEM       PIC X(8).*/
        public StringBasis SINISCON_NOM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINISCON-NOM-PROGRAMA       PIC X(8).*/
        public StringBasis SINISCON_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINISCON-COD-USUARIO       PIC X(8).*/
        public StringBasis SINISCON_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}