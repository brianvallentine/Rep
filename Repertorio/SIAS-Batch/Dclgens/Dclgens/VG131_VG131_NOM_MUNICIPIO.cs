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
    public class VG131_VG131_NOM_MUNICIPIO : VarBasis
    {
        /*"       49 VG131-NOM-MUNICIPIO-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG131_NOM_MUNICIPIO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG131-NOM-MUNICIPIO-TEXT          PIC X(100).*/
        public StringBasis VG131_NOM_MUNICIPIO_TEXT { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 VG131-COD-CEP        PIC X(8).*/
    }
}