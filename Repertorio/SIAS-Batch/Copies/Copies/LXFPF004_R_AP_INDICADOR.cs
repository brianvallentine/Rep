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
    public class LXFPF004_R_AP_INDICADOR : VarBasis
    {
        /*"      07        R-AP-AGEN-IND              PIC  9(004)*/
        public IntBasis R_AP_AGEN_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      07        R-AP-OPER-IND              PIC  9(004)*/
        public IntBasis R_AP_OPER_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      07        R-AP-CONTA-IND             PIC  9(012)*/
        public IntBasis R_AP_CONTA_IND { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
        /*"      07        R-AP-DV-IND                PIC  9(001)*/
        public IntBasis R_AP_DV_IND { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"      07        R-AP-MATRIC-IND            PIC  9(007)*/
        public IntBasis R_AP_MATRIC_IND { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05          R-AP-FILIAL                PIC  9(003)*/
    }
}