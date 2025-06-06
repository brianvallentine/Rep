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
    public class VG078_VG078_DES_ANDAMENTO : VarBasis
    {
        /*"       49 VG078-DES-ANDAMENTO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG078_DES_ANDAMENTO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG078-DES-ANDAMENTO-TEXT          PIC X(800).*/
        public StringBasis VG078_DES_ANDAMENTO_TEXT { get; set; } = new StringBasis(new PIC("X", "800", "X(800)."), @"");
        /*"    10 VG078-COD-USUARIO    PIC X(8).*/
    }
}