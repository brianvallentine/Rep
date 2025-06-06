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
    public class JVBKINCL_JV_CONTROLE : VarBasis
    {
        /*"  05  JV-VERSAO                    PIC  X(004)   VALUE 'V.04'*/
        public StringBasis JV_VERSAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"V.04");
        /*"  05  JV-DATA-ALTERACAO            PIC  X(010)                                   VALUE '2020-10-21'*/
        public StringBasis JV_DATA_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"2020-10-21");
        /*"01    JV-CONVENIOS*/
    }
}