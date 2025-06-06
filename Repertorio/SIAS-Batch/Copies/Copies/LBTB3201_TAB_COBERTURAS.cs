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
    public class LBTB3201_TAB_COBERTURAS : VarBasis
    {
        /*"    15   TB-COBERTURAS-RES  PIC  X(15)*/
        public StringBasis TB_COBERTURAS_RES { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
        /*"    15   FILLER             PIC  X(01)*/
        public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15   TB-COBERTURAS      PIC  X(34)*/
        public StringBasis TB_COBERTURAS { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
        /*"01  TABELA-DE-FRANQUIAS*/

        public LBTB3201_TAB_COBERTURAS()
        {
            TB_COBERTURAS_RES.ValueChanged += OnValueChanged;
            FILLER_36.ValueChanged += OnValueChanged;
            TB_COBERTURAS.ValueChanged += OnValueChanged;
        }

    }
}