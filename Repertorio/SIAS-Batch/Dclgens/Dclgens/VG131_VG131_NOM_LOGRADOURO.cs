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
    public class VG131_VG131_NOM_LOGRADOURO : VarBasis
    {
        /*"       49 VG131-NOM-LOGRADOURO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG131_NOM_LOGRADOURO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG131-NOM-LOGRADOURO-TEXT          PIC X(200).*/
        public StringBasis VG131_NOM_LOGRADOURO_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"    10 VG131-NUM-LOGRADOURO       PIC X(10).*/
    }
}