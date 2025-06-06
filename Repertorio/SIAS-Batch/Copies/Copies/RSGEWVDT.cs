using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class RSGEWVDT : VarBasis
    {
        /*"01 LK-RSGEWVDT-ANO                   PIC  X(004)*/
        public StringBasis LK_RSGEWVDT_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"01 LK-RSGEWVDT-MES                   PIC  X(002)*/
        public StringBasis LK_RSGEWVDT_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01 LK-RSGEWVDT-DIA                   PIC  X(002)*/
        public StringBasis LK_RSGEWVDT_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01 LK-RSGEWVDT-IND-RETORNO           PIC S9(004)   COMP-5*/
        public IntBasis LK_RSGEWVDT_IND_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-RSGEWVDT-OUT-DATA              PIC  X(010)*/
        public StringBasis LK_RSGEWVDT_OUT_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
    }
}