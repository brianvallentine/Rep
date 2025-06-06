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
    public class OD002_OD002_NOM_PESSOA : VarBasis
    {
        /*"       49 OD002-NOM-PESSOA-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis OD002_NOM_PESSOA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 OD002-NOM-PESSOA-TEXT          PIC X(200).*/
        public StringBasis OD002_NOM_PESSOA_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"    10 OD002-DTH-NASCIMENTO       PIC X(10).*/
    }
}