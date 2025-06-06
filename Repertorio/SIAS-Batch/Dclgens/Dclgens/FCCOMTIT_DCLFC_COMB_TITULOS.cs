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
    public class FCCOMTIT_DCLFC_COMB_TITULOS : VarBasis
    {
        /*"    10 FCCOMTIT-NUM-TITULO  PIC S9(9) USAGE COMP.*/
        public IntBasis FCCOMTIT_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCCOMTIT-NUM-COMBINACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis FCCOMTIT_NUM_COMBINACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCCOMTIT-IDE-SERIEPADRAO  PIC S9(4) USAGE COMP.*/
        public IntBasis FCCOMTIT_IDE_SERIEPADRAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCCOMTIT-DES-COMBINACAO  PIC X(20).*/
        public StringBasis FCCOMTIT_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
    }
}