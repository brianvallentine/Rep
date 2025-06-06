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
    public class GE099_DCLGE_MOVIMENTO_SAP : VarBasis
    {
        /*"    10 GE099-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis GE099_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE099-DTH-MOVIMENTO  PIC X(10).*/
        public StringBasis GE099_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE099-NOM-PROGRAMA   PIC X(40).*/
        public StringBasis GE099_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE099-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE099_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}