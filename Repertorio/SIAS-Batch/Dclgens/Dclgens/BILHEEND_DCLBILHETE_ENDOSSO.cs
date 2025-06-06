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
    public class BILHEEND_DCLBILHETE_ENDOSSO : VarBasis
    {
        /*"    10 BILHEEND-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis BILHEEND_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 BILHEEND-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis BILHEEND_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 BILHEEND-NUM-BILHETE  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BILHEEND_NUM_BILHETE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 BILHEEND-TIMESTAMP   PIC X(26).*/
        public StringBasis BILHEEND_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}