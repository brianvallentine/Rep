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
    public class GEPESSOA_DCLGE_PESSOA : VarBasis
    {
        /*"    10 GEPESSOA-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis GEPESSOA_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEPESSOA-NOM-PESSOA  PIC X(60).*/
        public StringBasis GEPESSOA_NOM_PESSOA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GEPESSOA-IND-PESSOA  PIC X(1).*/
        public StringBasis GEPESSOA_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEPESSOA-STA-PESSOA  PIC X(1).*/
        public StringBasis GEPESSOA_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}