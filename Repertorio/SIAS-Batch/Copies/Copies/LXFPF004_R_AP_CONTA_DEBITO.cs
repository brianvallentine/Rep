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
    public class LXFPF004_R_AP_CONTA_DEBITO : VarBasis
    {
        /*"      07        R-AP-AGEN-DEB              PIC  9(004)*/
        public IntBasis R_AP_AGEN_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      07        R-AP-OPER-DEB              PIC  9(004)*/
        public IntBasis R_AP_OPER_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      07        R-AP-CONTA-DEB             PIC  9(012)*/
        public IntBasis R_AP_CONTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
        /*"      07        R-AP-DV-DEB                PIC  9(001)*/
        public IntBasis R_AP_DV_DEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"*/
    }
}