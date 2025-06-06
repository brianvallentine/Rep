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
    public class GEWEW001_LK_NOM_PARAMETRO_WE001 : VarBasis
    {
        /*"   49 LK-NOM-PARAMETRO-LEN-WE001     PIC S9(004) COMP*/
        public IntBasis LK_NOM_PARAMETRO_LEN_WE001 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   49 LK-NOM-PARAMETRO-TXT-WE001     PIC X(255)*/
        public StringBasis LK_NOM_PARAMETRO_TXT_WE001 { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01 LK-NUM-LINHA-WE001                PIC S9(009) COMP*/
    }
}