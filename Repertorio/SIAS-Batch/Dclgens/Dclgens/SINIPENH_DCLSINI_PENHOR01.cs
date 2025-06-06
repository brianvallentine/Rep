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
    public class SINIPENH_DCLSINI_PENHOR01 : VarBasis
    {
        /*"    10 SINIPENH-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINIPENH_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINIPENH-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis SINIPENH_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIPENH-NUM-CONTRATO  PIC S9(9) USAGE COMP.*/
        public IntBasis SINIPENH_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINIPENH-DV-CONTRATO  PIC X(1).*/
        public StringBasis SINIPENH_DV_CONTRATO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINIPENH-TIMESTAMP   PIC X(26).*/
        public StringBasis SINIPENH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}