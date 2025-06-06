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
    public class LXFPF003_RES_INDICADOR : VarBasis
    {
        /*"      07        RES-AGEN-IND          PIC  9(004)*/
        public IntBasis RES_AGEN_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      07        RES-OPER-IND          PIC  9(004)*/
        public IntBasis RES_OPER_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      07        RES-CONTA-IND         PIC  9(012)*/
        public IntBasis RES_CONTA_IND { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
        /*"      07        RES-DV-IND            PIC  9(001)*/
        public IntBasis RES_DV_IND { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"      07        RES-MATRIC-IND        PIC  9(007)*/
        public IntBasis RES_MATRIC_IND { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05          RES-FILIAL            PIC  9(003)*/
    }
}