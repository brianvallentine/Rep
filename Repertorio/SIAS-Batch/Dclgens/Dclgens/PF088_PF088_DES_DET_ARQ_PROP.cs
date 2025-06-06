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
    public class PF088_PF088_DES_DET_ARQ_PROP : VarBasis
    {
        /*"       49 PF088-DES-DET-ARQ-PROP-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis PF088_DES_DET_ARQ_PROP_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 PF088-DES-DET-ARQ-PROP-TEXT          PIC X(200).*/
        public StringBasis PF088_DES_DET_ARQ_PROP_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"*/
    }
}