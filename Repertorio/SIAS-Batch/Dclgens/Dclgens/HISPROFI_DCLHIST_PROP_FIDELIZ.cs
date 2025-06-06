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
    public class HISPROFI_DCLHIST_PROP_FIDELIZ : VarBasis
    {
        /*"    10 HISPROFI-NUM-IDENTIFICACAO       PIC S9(15)V USAGE COMP-3*/
        public DoubleBasis HISPROFI_NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 HISPROFI-DATA-SITUACAO       PIC X(10)*/
        public StringBasis HISPROFI_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 HISPROFI-NSAS-SIVPF  PIC S9(9) USAGE COMP*/
        public IntBasis HISPROFI_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISPROFI-NSL         PIC S9(9) USAGE COMP*/
        public IntBasis HISPROFI_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISPROFI-SIT-PROPOSTA       PIC X(3)*/
        public StringBasis HISPROFI_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)"), @"");
        /*"    10 HISPROFI-SIT-COBRANCA-SIVPF       PIC X(3)*/
        public StringBasis HISPROFI_SIT_COBRANCA_SIVPF { get; set; } = new StringBasis(new PIC("X", "3", "X(3)"), @"");
        /*"    10 HISPROFI-SIT-MOTIVO-SIVPF       PIC S9(9) USAGE COMP*/
        public IntBasis HISPROFI_SIT_MOTIVO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISPROFI-COD-EMPRESA-SIVPF       PIC S9(4) USAGE COMP*/
        public IntBasis HISPROFI_COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISPROFI-COD-PRODUTO-SIVPF       PIC S9(4) USAGE COMP*/
        public IntBasis HISPROFI_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISPROFI-IND-TP-ACAO       PIC X(1)*/
        public StringBasis HISPROFI_IND_TP_ACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 HISPROFI-IND-TP-SENSIBILIZACAO       PIC X(1)*/
        public StringBasis HISPROFI_IND_TP_SENSIBILIZACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 HISPROFI-IND-ENVIO   PIC X(1)*/
        public StringBasis HISPROFI_IND_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 HISPROFI-DTA-INI-VIGENCIA       PIC X(10)*/
        public StringBasis HISPROFI_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 HISPROFI-DTA-FIM-VIGENCIA       PIC X(10)*/
        public StringBasis HISPROFI_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 HISPROFI-NUM-PARCELA       PIC S9(9) USAGE COMP*/
        public IntBasis HISPROFI_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISPROFI-COD-TP-LANCAMENTO       PIC S9(4) USAGE COMP*/
        public IntBasis HISPROFI_COD_TP_LANCAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISPROFI-VLR-PREMIO  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis HISPROFI_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISPROFI-COD-ERRO    PIC S9(9) USAGE COMP*/
        public IntBasis HISPROFI_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISPROFI-COD-USUARIO       PIC X(8)*/
        public StringBasis HISPROFI_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)"), @"");
        /*"    10 HISPROFI-NOM-PROGRAMA       PIC X(10)*/
        public StringBasis HISPROFI_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 HISPROFI-DTH-CADASTRAMENTO       PIC X(26)*/
        public StringBasis HISPROFI_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"    10 HISPROFI-DTA-PROCESSAMENTO-CEF       PIC X(10)*/
        public StringBasis HISPROFI_DTA_PROCESSAMENTO_CEF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"*/
    }
}