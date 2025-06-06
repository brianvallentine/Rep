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
    public class LBTB3101_TAB_LIMITE_MINMAX_CCA : VarBasis
    {
        /*"    15   TB-LIMITE-MIN-CCA     PIC  9(08)*/
        public IntBasis TB_LIMITE_MIN_CCA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"    15   FILLER                PIC  X(01)*/
        public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15   TB-LIMITE-PCTMIN-CCA  PIC  9(03)*/
        public IntBasis TB_LIMITE_PCTMIN_CCA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"    15   FILLER                PIC  X(04)*/
        public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
        /*"    15   TB-LIMITE-MAX-CCA     PIC  9(08)*/
        public IntBasis TB_LIMITE_MAX_CCA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"    15   FILLER                PIC  X(01)*/
        public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15   TB-LIMITE-PCTMAX-CCA  PIC  9(03)*/
        public IntBasis TB_LIMITE_PCTMAX_CCA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"    15   FILLER                PIC  X(02)*/
        public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"01  TABELA-DE-LIM-MINMAX-CCAT*/

        public LBTB3101_TAB_LIMITE_MINMAX_CCA()
        {
            TB_LIMITE_MIN_CCA.ValueChanged += OnValueChanged;
            FILLER_30.ValueChanged += OnValueChanged;
            TB_LIMITE_PCTMIN_CCA.ValueChanged += OnValueChanged;
            FILLER_31.ValueChanged += OnValueChanged;
            TB_LIMITE_MAX_CCA.ValueChanged += OnValueChanged;
            FILLER_32.ValueChanged += OnValueChanged;
            TB_LIMITE_PCTMAX_CCA.ValueChanged += OnValueChanged;
            FILLER_33.ValueChanged += OnValueChanged;
        }

    }
}