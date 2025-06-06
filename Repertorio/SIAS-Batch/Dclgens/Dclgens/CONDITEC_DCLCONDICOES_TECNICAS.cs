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
    public class CONDITEC_DCLCONDICOES_TECNICAS : VarBasis
    {
        /*"    10 CONDITEC-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CONDITEC_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CONDITEC-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONDITEC_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDITEC-QTD-SAL-MORNATU  PIC S9(4) USAGE COMP.*/
        public IntBasis CONDITEC_QTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDITEC-QTD-SAL-MORACID  PIC S9(4) USAGE COMP.*/
        public IntBasis CONDITEC_QTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDITEC-QTD-SAL-INVPERM  PIC S9(4) USAGE COMP.*/
        public IntBasis CONDITEC_QTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDITEC-TAXA-AP-MORACID  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 CONDITEC-TAXA-AP-INVPERM  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 CONDITEC-TAXA-AP-AMDS  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 CONDITEC-TAXA-AP-DH  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 CONDITEC-TAXA-AP-DIT  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 CONDITEC-TAXA-AP     PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_TAXA_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 CONDITEC-CARREGA-PRINCIPAL  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_CARREGA_PRINCIPAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-CARREGA-CONJUGE  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_CARREGA_CONJUGE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-CARREGA-FILHOS  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_CARREGA_FILHOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-GARAN-ADIC-IEA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_GARAN_ADIC_IEA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-GARAN-ADIC-IPA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_GARAN_ADIC_IPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-GARAN-ADIC-IPD  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_GARAN_ADIC_IPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-GARAN-ADIC-HD  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_GARAN_ADIC_HD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-TAXA-DESPESA-ADM  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_TAXA_DESPESA_ADM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-TAXA-IRB    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_TAXA_IRB { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 CONDITEC-LIM-CAP-MORNATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_LIM_CAP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDITEC-LIM-CAP-MORACID  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_LIM_CAP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDITEC-LIM-CAP-INVAPER  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDITEC_LIM_CAP_INVAPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDITEC-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis CONDITEC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}