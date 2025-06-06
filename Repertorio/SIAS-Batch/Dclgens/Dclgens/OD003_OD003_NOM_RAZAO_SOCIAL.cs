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
    public class OD003_OD003_NOM_RAZAO_SOCIAL : VarBasis
    {
        /*"       49 OD003-NOM-RAZAO-SOCIAL-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis OD003_NOM_RAZAO_SOCIAL_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 OD003-NOM-RAZAO-SOCIAL-TEXT  PIC X(200).*/
        public StringBasis OD003_NOM_RAZAO_SOCIAL_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"    10 OD003-STA-PESSOA     PIC X(1).*/
    }
}