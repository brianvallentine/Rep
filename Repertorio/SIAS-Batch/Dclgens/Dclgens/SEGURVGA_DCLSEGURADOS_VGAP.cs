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
    public class SEGURVGA_DCLSEGURADOS_VGAP : VarBasis
    {
        /*"    10 SEGURVGA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SEGURVGA-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SEGURVGA-DAC-CERTIFICADO  PIC X(1).*/
        public StringBasis SEGURVGA_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-TIPO-SEGURADO  PIC X(1).*/
        public StringBasis SEGURVGA_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURVGA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGURVGA-TIPO-INCLUSAO  PIC X(1).*/
        public StringBasis SEGURVGA_TIPO_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGURVGA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURVGA_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGURVGA-COD-AGENCIADOR  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGURVGA-COD-CORRETOR  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGURVGA-COD-PLANOVGAP  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_PLANOVGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-COD-PLANOAP  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_PLANOAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-AUTOR-AUM-AUTOMAT  PIC X(1).*/
        public StringBasis SEGURVGA_AUTOR_AUM_AUTOMAT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-TIPO-BENEFICIARIO  PIC X(1).*/
        public StringBasis SEGURVGA_TIPO_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-PERI-PAGAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-PERI-RENOVACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-NUM-CARNE   PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_NUM_CARNE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-COD-OCUPACAO  PIC X(4).*/
        public StringBasis SEGURVGA_COD_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 SEGURVGA-ESTADO-CIVIL  PIC X(1).*/
        public StringBasis SEGURVGA_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-IDE-SEXO    PIC X(1).*/
        public StringBasis SEGURVGA_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-COD-PROFISSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-NATURALIDADE  PIC X(30).*/
        public StringBasis SEGURVGA_NATURALIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SEGURVGA-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-OCORR-END-COBRAN  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_OCORR_END_COBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-BCO-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-AGE-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-DAC-COBRANCA  PIC X(1).*/
        public StringBasis SEGURVGA_DAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-NUM-MATRICULA  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SEGURVGA-VAL-SALARIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_VAL_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SEGURVGA-TIPO-SALARIO  PIC X(1).*/
        public StringBasis SEGURVGA_TIPO_SALARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-TIPO-PLANO  PIC X(1).*/
        public StringBasis SEGURVGA_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis SEGURVGA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGURVGA-PCT-CONJUGE-VG  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_PCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SEGURVGA-PCT-CONJUGE-AP  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_PCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 SEGURVGA-QTD-SAL-MORNATU  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_QTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-QTD-SAL-MORACID  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_QTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-QTD-SAL-INVPERM  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURVGA_QTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURVGA-TAXA-AP-MORACID  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGURVGA-TAXA-AP-INVPERM  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGURVGA-TAXA-AP-AMDS  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGURVGA-TAXA-AP-DH  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGURVGA-TAXA-AP-DIT  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGURVGA-TAXA-AP     PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_TAXA_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGURVGA-TAXA-VG     PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SEGURVGA-SIT-REGISTRO  PIC X(1).*/
        public StringBasis SEGURVGA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SEGURVGA-DATA-ADMISSAO  PIC X(10).*/
        public StringBasis SEGURVGA_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGURVGA-DATA-NASCIMENTO  PIC X(10).*/
        public StringBasis SEGURVGA_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGURVGA-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURVGA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGURVGA-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SEGURVGA_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SEGURVGA-LOT-EMP-SEGURADO  PIC X(30).*/
        public StringBasis SEGURVGA_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"*/
    }
}