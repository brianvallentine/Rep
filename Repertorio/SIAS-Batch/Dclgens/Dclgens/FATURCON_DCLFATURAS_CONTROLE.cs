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
    public class FATURCON_DCLFATURAS_CONTROLE : VarBasis
    {
        /*"    10 FATURCON-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FATURCON_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FATURCON-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis FATURCON_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FATURCON-DATA-REFERENCIA  PIC X(10).*/
        public StringBasis FATURCON_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FATURCON-DATA-ULT-FATURAMEN  PIC X(10).*/
        public StringBasis FATURCON_DATA_ULT_FATURAMEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FATURCON-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis FATURCON_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}