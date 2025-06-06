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
    public class SILOTDC2_DCLSINI_LOT_DOC02 : VarBasis
    {
        /*"    10 SILOTDC2-COD-DOCUMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SILOTDC2_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SILOTDC2-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis SILOTDC2_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SILOTDC2-DESCRICAO   PIC X(40).*/
        public StringBasis SILOTDC2_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SILOTDC2-TIMESTAMP   PIC X(26).*/
        public StringBasis SILOTDC2_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}