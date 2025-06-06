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
    public class _REDEF_LXFPF003_RES_CPF_R : VarBasis
    {
        /*"      07        RES-NUMERO-CPF        PIC  9(009)*/
        public IntBasis RES_NUMERO_CPF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"      07        RES-DV-CPF            PIC  9(002)*/
        public IntBasis RES_DV_CPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    05          RES-DDD               PIC  9(004)*/

        public _REDEF_LXFPF003_RES_CPF_R()
        {
            RES_NUMERO_CPF.ValueChanged += OnValueChanged;
            RES_DV_CPF.ValueChanged += OnValueChanged;
        }

    }
}