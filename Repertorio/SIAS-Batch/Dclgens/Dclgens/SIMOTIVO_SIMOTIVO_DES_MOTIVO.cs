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
    public class SIMOTIVO_SIMOTIVO_DES_MOTIVO : VarBasis
    {
        /*"       49 SIMOTIVO-DES-MOTIVO-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis SIMOTIVO_DES_MOTIVO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 SIMOTIVO-DES-MOTIVO-TEXT  PIC X(2000).*/
        public StringBasis SIMOTIVO_DES_MOTIVO_TEXT { get; set; } = new StringBasis(new PIC("X", "2000", "X(2000)."), @"");
        /*"    10 SIMOTIVO-COD-TIPO-MOTIVO  PIC S9(4) USAGE COMP.*/
    }
}