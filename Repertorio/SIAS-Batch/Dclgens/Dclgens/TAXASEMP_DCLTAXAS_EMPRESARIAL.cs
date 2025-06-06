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
    public class TAXASEMP_DCLTAXAS_EMPRESARIAL : VarBasis
    {
        /*"    10 TAXASEMP-PERI-PAGAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis TAXASEMP_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TAXASEMP-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis TAXASEMP_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TAXASEMP-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis TAXASEMP_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TAXASEMP-TAXA-VG     PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis TAXASEMP_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 TAXASEMP-TAXA-AP-MORACID  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis TAXASEMP_TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 TAXASEMP-TAXA-AP-INVPERM  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis TAXASEMP_TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 TAXASEMP-TAXA-AP-AMDS  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis TAXASEMP_TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 TAXASEMP-TAXA-AP-DH  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis TAXASEMP_TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 TAXASEMP-TAXA-AP-DIT  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis TAXASEMP_TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 TAXASEMP-COD-USUARIO  PIC X(8).*/
        public StringBasis TAXASEMP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TAXASEMP-TIMESTAMP   PIC X(26).*/
        public StringBasis TAXASEMP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}