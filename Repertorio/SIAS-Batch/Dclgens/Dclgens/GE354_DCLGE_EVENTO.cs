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
    public class GE354_DCLGE_EVENTO : VarBasis
    {
        /*"    10 GE354-COD-EVENTO     PIC S9(4) USAGE COMP.*/
        public IntBasis GE354_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE354-IDE-SISTEMA    PIC X(2).*/
        public StringBasis GE354_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE354-DES-EVENTO     PIC X(80).*/
        public StringBasis GE354_DES_EVENTO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"    10 GE354-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis GE354_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}