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
    public class LXFPF004_R_AP_COMUM : VarBasis
    {
        /*"      07        R-AP-TIPO-REG              PIC  9(001)*/
        public IntBasis R_AP_TIPO_REG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"      07        R-AP-FILIAL-DOC            PIC  9(003)*/
        public IntBasis R_AP_FILIAL_DOC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      07        R-AP-LOTE                  PIC  9(003)*/
        public IntBasis R_AP_LOTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      07        R-AP-TIPO-DOC              PIC  9(005)*/
        public IntBasis R_AP_TIPO_DOC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"    05          R-AP-NUMBIL                PIC  9(011)*/
    }
}