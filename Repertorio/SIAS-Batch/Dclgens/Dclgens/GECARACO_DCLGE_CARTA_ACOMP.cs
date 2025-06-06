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
    public class GECARACO_DCLGE_CARTA_ACOMP : VarBasis
    {
        /*"    10 GECARACO-NUM-CARTA   PIC S9(9) USAGE COMP.*/
        public IntBasis GECARACO_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECARACO-NUM-OCORR-CARTACO  PIC S9(4) USAGE COMP.*/
        public IntBasis GECARACO_NUM_OCORR_CARTACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GECARACO-COD-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis GECARACO_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GECARACO-DATA-MOVTO-CARTACO  PIC X(10).*/
        public StringBasis GECARACO_DATA_MOVTO_CARTACO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GECARACO-COD-USUARIO  PIC X(8).*/
        public StringBasis GECARACO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GECARACO-TIMESTAMP   PIC X(26).*/
        public StringBasis GECARACO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}