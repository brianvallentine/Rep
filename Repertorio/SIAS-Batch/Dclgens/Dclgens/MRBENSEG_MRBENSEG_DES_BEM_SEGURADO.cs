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
    public class MRBENSEG_MRBENSEG_DES_BEM_SEGURADO : VarBasis
    {
        /*"       49 MRBENSEG-DES-BEM-SEGURADO-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis MRBENSEG_DES_BEM_SEGURADO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 MRBENSEG-DES-BEM-SEGURADO-TEXT  PIC X(100).*/
        public StringBasis MRBENSEG_DES_BEM_SEGURADO_TEXT { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 MRBENSEG-VLR-BEM-SEGURADO  PIC S9(13)V9(2) USAGE COMP-3.*/
    }
}