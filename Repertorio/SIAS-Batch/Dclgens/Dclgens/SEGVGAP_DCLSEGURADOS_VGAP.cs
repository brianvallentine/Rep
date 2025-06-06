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
    public class SEGVGAP_DCLSEGURADOS_VGAP : VarBasis
    {
        /*"    10 SEGVGAP-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SEGVGAP-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SEGVGAP-DAC-CERTIFICADO  PIC X(1).*/
        public StringBasis SEGVGAP_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-TIPO-SEGURADO  PIC X(1).*/
        public StringBasis SEGVGAP_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-NUM-ITEM     PIC S9(9) USAGE COMP.*/
        public IntBasis SEGVGAP_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGVGAP-TIPO-INCLUSAO  PIC X(1).*/
        public StringBasis SEGVGAP_TIPO_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGVGAP-COD-FONTE    PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGVGAP_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGVGAP-COD-AGENCIADOR  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGVGAP-COD-CORRETOR  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGVGAP-COD-PLANOVGAP  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_PLANOVGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-COD-PLANOAP  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_PLANOAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-FAIXA        PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-AUTOR-AUM-AUTOMAT  PIC X(1).*/
        public StringBasis SEGVGAP_AUTOR_AUM_AUTOMAT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-TIPO-BENEFICIARIO  PIC X(1).*/
        public StringBasis SEGVGAP_TIPO_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-PERI-PAGAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-PERI-RENOVACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-NUM-CARNE    PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_NUM_CARNE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-COD-OCUPACAO  PIC X(4).*/
        public StringBasis SEGVGAP_COD_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 SEGVGAP-ESTADO-CIVIL  PIC X(1).*/
        public StringBasis SEGVGAP_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-IDE-SEXO     PIC X(1).*/
        public StringBasis SEGVGAP_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-COD-PROFISSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-NATURALIDADE  PIC X(30).*/
        public StringBasis SEGVGAP_NATURALIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SEGVGAP-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-OCORR-END-COBRAN  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_OCORR_END_COBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-BCO-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-AGE-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-DAC-COBRANCA  PIC X(1).*/
        public StringBasis SEGVGAP_DAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-NUM-MATRICULA  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SEGVGAP-VAL-SALARIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_VAL_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SEGVGAP-TIPO-SALARIO  PIC X(1).*/
        public StringBasis SEGVGAP_TIPO_SALARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-TIPO-PLANO   PIC X(1).*/
        public StringBasis SEGVGAP_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis SEGVGAP_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGVGAP-PCT-CONJUGE-VG  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_PCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SEGVGAP-PCT-CONJUGE-AP  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_PCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SEGVGAP-QTD-SAL-MORNATU  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_QTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-QTD-SAL-MORACID  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_QTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-QTD-SAL-INVPERM  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGVGAP_QTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGVGAP-TAXA-AP-MORACID  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGVGAP-TAXA-AP-INVPERM  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGVGAP-TAXA-AP-AMDS  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGVGAP-TAXA-AP-DH   PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGVGAP-TAXA-AP-DIT  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGVGAP-TAXA-AP      PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_TAXA_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGVGAP-TAXA-VG      PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGVGAP-SIT-REGISTRO  PIC X(1).*/
        public StringBasis SEGVGAP_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGVGAP-DATA-ADMISSAO  PIC X(10).*/
        public StringBasis SEGVGAP_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGVGAP-DATA-NASCIMENTO  PIC X(10).*/
        public StringBasis SEGVGAP_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGVGAP-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGVGAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGVGAP-CGCCPF       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SEGVGAP_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SEGVGAP-LOT-EMP-SEGURADO  PIC X(30).*/
        public StringBasis SEGVGAP_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"*/
    }
}