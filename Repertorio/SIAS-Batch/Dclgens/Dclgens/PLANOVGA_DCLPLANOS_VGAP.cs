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
    public class PLANOVGA_DCLPLANOS_VGAP : VarBasis
    {
        /*"    10 PLANOVGA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PLANOVGA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PLANOVGA-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVGA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVGA-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVGA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVGA-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis PLANOVGA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PLANOVGA-IMP-MORNATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVGA_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVGA-IMP-MORACID  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVGA_IMP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVGA-IMP-INVPERM  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVGA_IMP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVGA-IMP-AMDS    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVGA_IMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVGA-IMP-DH      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVGA_IMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVGA-IMP-DIT     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVGA_IMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVGA-SIT-REGISTRO  PIC X(1).*/
        public StringBasis PLANOVGA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PLANOVGA-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PLANOVGA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PLANOVGA-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis PLANOVGA_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}