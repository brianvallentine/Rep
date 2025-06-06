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
    public class LBTB3201_TAB_FRANQUIAS : VarBasis
    {
        /*"    15   TB-FRANQUIAS-RED   PIC  X(06)*/
        public StringBasis TB_FRANQUIAS_RED { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
        /*"    15   FILLER             PIC  X(01)*/
        public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15   TB-FRANQUIAS       PIC  X(28)*/
        public StringBasis TB_FRANQUIAS { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"");
        /*"01  TABELA-DE-LIM-MINMAX*/

        public LBTB3201_TAB_FRANQUIAS()
        {
            TB_FRANQUIAS_RED.ValueChanged += OnValueChanged;
            FILLER_37.ValueChanged += OnValueChanged;
            TB_FRANQUIAS.ValueChanged += OnValueChanged;
        }

    }
}