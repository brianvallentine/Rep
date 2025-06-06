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
    public class MOVVGAP_DCLMOVIMENTO_VGAP : VarBasis
    {
        /*"    10 MOVVGAP-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVVGAP-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-COD-FONTE    PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVVGAP_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVVGAP-TIPO-SEGURADO       PIC X(1).*/
        public StringBasis MOVVGAP_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVVGAP-DAC-CERTIFICADO       PIC X(1).*/
        public StringBasis MOVVGAP_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-TIPO-INCLUSAO       PIC X(1).*/
        public StringBasis MOVVGAP_TIPO_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVVGAP-COD-AGENCIADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVVGAP-COD-CORRETOR       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVVGAP-COD-PLANOVGAP       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_PLANOVGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-COD-PLANOAP  PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_PLANOAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-FAIXA        PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-AUTOR-AUM-AUTOMAT       PIC X(1).*/
        public StringBasis MOVVGAP_AUTOR_AUM_AUTOMAT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-TIPO-BENEFICIARIO       PIC X(1).*/
        public StringBasis MOVVGAP_TIPO_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-PERI-RENOVACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-COD-OCUPACAO       PIC X(4).*/
        public StringBasis MOVVGAP_COD_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 MOVVGAP-ESTADO-CIVIL       PIC X(1).*/
        public StringBasis MOVVGAP_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-IDE-SEXO     PIC X(1).*/
        public StringBasis MOVVGAP_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-COD-PROFISSAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-NATURALIDADE       PIC X(30).*/
        public StringBasis MOVVGAP_NATURALIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 MOVVGAP-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-OCORR-END-COBRAN       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_OCORR_END_COBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-BCO-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-AGE-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-DAC-COBRANCA       PIC X(1).*/
        public StringBasis MOVVGAP_DAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVVGAP-NUM-CTA-CORRENTE       PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_NUM_CTA_CORRENTE { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 MOVVGAP-DAC-CTA-CORRENTE       PIC X(1).*/
        public StringBasis MOVVGAP_DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-VAL-SALARIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_VAL_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-TIPO-SALARIO       PIC X(1).*/
        public StringBasis MOVVGAP_TIPO_SALARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-TIPO-PLANO   PIC X(1).*/
        public StringBasis MOVVGAP_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-PCT-CONJUGE-VG       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_PCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 MOVVGAP-PCT-CONJUGE-AP       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_PCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 MOVVGAP-QTD-SAL-MORNATU       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_QTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-QTD-SAL-MORACID       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_QTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-QTD-SAL-INVPERM       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_QTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-TAXA-AP-MORACID       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVVGAP-TAXA-AP-INVPERM       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVVGAP-TAXA-AP-AMDS       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVVGAP-TAXA-AP-DH   PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVVGAP-TAXA-AP-DIT  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVVGAP-TAXA-VG      PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVVGAP-IMP-MORNATU-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_MORNATU_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-MORNATU-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-MORACID-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_MORACID_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-MORACID-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-INVPERM-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_INVPERM_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-INVPERM-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-AMDS-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_AMDS_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-AMDS-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-DH-ANT   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_DH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-DH-ATU   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-DIT-ANT  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_DIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-IMP-DIT-ATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_IMP_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-PRM-VG-ANT   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_PRM_VG_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-PRM-VG-ATU   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_PRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-PRM-AP-ANT   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_PRM_AP_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-PRM-AP-ATU   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVVGAP_PRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVVGAP-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-DATA-OPERACAO       PIC X(10).*/
        public StringBasis MOVVGAP_DATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVVGAP-COD-SUBGRUPO-TRANS       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_SUBGRUPO_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVVGAP-SIT-REGISTRO       PIC X(1).*/
        public StringBasis MOVVGAP_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVVGAP-COD-USUARIO  PIC X(8).*/
        public StringBasis MOVVGAP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 MOVVGAP-DATA-AVERBACAO       PIC X(10).*/
        public StringBasis MOVVGAP_DATA_AVERBACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVVGAP-DATA-ADMISSAO       PIC X(10).*/
        public StringBasis MOVVGAP_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVVGAP-DATA-INCLUSAO       PIC X(10).*/
        public StringBasis MOVVGAP_DATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVVGAP-DATA-NASCIMENTO       PIC X(10).*/
        public StringBasis MOVVGAP_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVVGAP-DATA-FATURA  PIC X(10).*/
        public StringBasis MOVVGAP_DATA_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVVGAP-DATA-REFERENCIA       PIC X(10).*/
        public StringBasis MOVVGAP_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVVGAP-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis MOVVGAP_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVVGAP-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis MOVVGAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVVGAP-LOT-EMP-SEGURADO       PIC X(30).*/
        public StringBasis MOVVGAP_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"*/
    }
}