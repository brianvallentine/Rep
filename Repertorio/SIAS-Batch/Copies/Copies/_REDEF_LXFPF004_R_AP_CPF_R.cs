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
    public class _REDEF_LXFPF004_R_AP_CPF_R : VarBasis
    {
        /*"      07        R-AP-NUMERO-CPF            PIC  9(009)*/
        public IntBasis R_AP_NUMERO_CPF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"      07        R-AP-DV-CPF                PIC  9(002)*/
        public IntBasis R_AP_DV_CPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    05          R-AP-DTNASC                PIC  9(008)*/

        public _REDEF_LXFPF004_R_AP_CPF_R()
        {
            R_AP_NUMERO_CPF.ValueChanged += OnValueChanged;
            R_AP_DV_CPF.ValueChanged += OnValueChanged;
        }

    }
}