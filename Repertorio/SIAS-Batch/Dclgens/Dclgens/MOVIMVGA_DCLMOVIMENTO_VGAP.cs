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
    public class MOVIMVGA_DCLMOVIMENTO_VGAP : VarBasis
    {
        /*"    10 MOVIMVGA-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MOVIMVGA-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMVGA_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMVGA-TIPO-SEGURADO       PIC X(1).*/
        public StringBasis MOVIMVGA_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVIMVGA-DAC-CERTIFICADO       PIC X(1).*/
        public StringBasis MOVIMVGA_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-TIPO-INCLUSAO       PIC X(1).*/
        public StringBasis MOVIMVGA_TIPO_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMVGA-COD-AGENCIADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMVGA-COD-CORRETOR       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMVGA-COD-PLANOVGAP       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_PLANOVGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-COD-PLANOAP       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_PLANOAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-AUTOR-AUM-AUTOMAT       PIC X(1).*/
        public StringBasis MOVIMVGA_AUTOR_AUM_AUTOMAT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-TIPO-BENEFICIARIO       PIC X(1).*/
        public StringBasis MOVIMVGA_TIPO_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-PERI-RENOVACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-COD-OCUPACAO       PIC X(4).*/
        public StringBasis MOVIMVGA_COD_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 MOVIMVGA-ESTADO-CIVIL       PIC X(1).*/
        public StringBasis MOVIMVGA_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-IDE-SEXO    PIC X(1).*/
        public StringBasis MOVIMVGA_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-COD-PROFISSAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-NATURALIDADE       PIC X(30).*/
        public StringBasis MOVIMVGA_NATURALIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 MOVIMVGA-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-OCORR-END-COBRAN       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_OCORR_END_COBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-BCO-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-AGE-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-DAC-COBRANCA       PIC X(1).*/
        public StringBasis MOVIMVGA_DAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 MOVIMVGA-NUM-CTA-CORRENTE       PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_NUM_CTA_CORRENTE { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 MOVIMVGA-DAC-CTA-CORRENTE       PIC X(1).*/
        public StringBasis MOVIMVGA_DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-VAL-SALARIO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_VAL_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-TIPO-SALARIO       PIC X(1).*/
        public StringBasis MOVIMVGA_TIPO_SALARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-TIPO-PLANO  PIC X(1).*/
        public StringBasis MOVIMVGA_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-PCT-CONJUGE-VG       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_PCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 MOVIMVGA-PCT-CONJUGE-AP       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_PCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 MOVIMVGA-QTD-SAL-MORNATU       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_QTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-QTD-SAL-MORACID       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_QTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-QTD-SAL-INVPERM       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_QTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-TAXA-AP-MORACID       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVIMVGA-TAXA-AP-INVPERM       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVIMVGA-TAXA-AP-AMDS       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVIMVGA-TAXA-AP-DH  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVIMVGA-TAXA-AP-DIT       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVIMVGA-TAXA-VG     PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 MOVIMVGA-IMP-MORNATU-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_MORNATU_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-MORNATU-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-MORACID-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_MORACID_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-MORACID-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-INVPERM-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_INVPERM_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-INVPERM-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-AMDS-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_AMDS_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-AMDS-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-DH-ANT  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_DH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-DH-ATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-DIT-ANT       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_DIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-IMP-DIT-ATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_IMP_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-PRM-VG-ANT  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_PRM_VG_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-PRM-VG-ATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_PRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-PRM-AP-ANT  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_PRM_AP_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-PRM-AP-ATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis MOVIMVGA_PRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 MOVIMVGA-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-DATA-OPERACAO       PIC X(10).*/
        public StringBasis MOVIMVGA_DATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMVGA-COD-SUBGRUPO-TRANS       PIC S9(4) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_SUBGRUPO_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOVIMVGA-SIT-REGISTRO       PIC X(1).*/
        public StringBasis MOVIMVGA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOVIMVGA-COD-USUARIO       PIC X(8).*/
        public StringBasis MOVIMVGA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 MOVIMVGA-DATA-AVERBACAO       PIC X(10).*/
        public StringBasis MOVIMVGA_DATA_AVERBACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMVGA-DATA-ADMISSAO       PIC X(10).*/
        public StringBasis MOVIMVGA_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMVGA-DATA-INCLUSAO       PIC X(10).*/
        public StringBasis MOVIMVGA_DATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMVGA-DATA-NASCIMENTO       PIC X(10).*/
        public StringBasis MOVIMVGA_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMVGA-DATA-FATURA       PIC X(10).*/
        public StringBasis MOVIMVGA_DATA_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMVGA-DATA-REFERENCIA       PIC X(10).*/
        public StringBasis MOVIMVGA_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMVGA-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis MOVIMVGA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 MOVIMVGA-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis MOVIMVGA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOVIMVGA-LOT-EMP-SEGURADO       PIC X(30).*/
        public StringBasis MOVIMVGA_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"*/
    }
}