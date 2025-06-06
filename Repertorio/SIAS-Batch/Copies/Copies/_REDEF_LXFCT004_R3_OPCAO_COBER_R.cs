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
    public class _REDEF_LXFCT004_R3_OPCAO_COBER_R : VarBasis
    {
        /*"       15  R3-COBERTURA                PIC  9(001)*/
        public IntBasis R3_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10    R3-COD-PLANO                PIC  9(004)*/

        public _REDEF_LXFCT004_R3_OPCAO_COBER_R()
        {
            R3_COBERTURA.ValueChanged += OnValueChanged;
        }

    }
}