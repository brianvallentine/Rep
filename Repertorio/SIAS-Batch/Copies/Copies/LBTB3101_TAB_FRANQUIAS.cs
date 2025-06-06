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
    public class LBTB3101_TAB_FRANQUIAS : VarBasis
    {
        /*"    15   TB-FRANQUIAS       PIC  X(35)*/
        public StringBasis TB_FRANQUIAS { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"");
        /*"01  TABELA-DE-LIM-MINMAX*/

        public LBTB3101_TAB_FRANQUIAS()
        {
            TB_FRANQUIAS.ValueChanged += OnValueChanged;
        }

    }
}