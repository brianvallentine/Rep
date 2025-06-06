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
    public class COBMENVG_DCLCOBRANCA_MENS_VGAP : VarBasis
    {
        /*"    10 COBMENVG-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis COBMENVG_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COBMENVG-CODSUBES    PIC S9(4) USAGE COMP.*/
        public IntBasis COBMENVG_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBMENVG-IDFORM      PIC X(2).*/
        public StringBasis COBMENVG_IDFORM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 COBMENVG-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis COBMENVG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBMENVG-JDE         PIC X(8).*/
        public StringBasis COBMENVG_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 COBMENVG-JDL         PIC X(8).*/
        public StringBasis COBMENVG_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}