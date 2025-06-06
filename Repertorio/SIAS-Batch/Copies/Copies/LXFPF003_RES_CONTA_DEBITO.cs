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
    public class LXFPF003_RES_CONTA_DEBITO : VarBasis
    {
        /*"      07        RES-AGEN-DEB          PIC  9(004)*/
        public IntBasis RES_AGEN_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      07        RES-OPER-DEB          PIC  9(004)*/
        public IntBasis RES_OPER_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      07        RES-CONTA-DEB         PIC  9(012)*/
        public IntBasis RES_CONTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
        /*"      07        RES-DV-DEB            PIC  9(001)*/
        public IntBasis RES_DV_DEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    05          RES-FILLER            PIC  X(030)*/
    }
}