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
    public class LBTB3201_TAB_LIMITE_MINMAX_CCAT : VarBasis
    {
        /*"    15   TB-LIMITE-MIN-CCAT     PIC  9(08)*/
        public IntBasis TB_LIMITE_MIN_CCAT { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"    15   FILLER                PIC  X(01)*/
        public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15   TB-LIMITE-PCTMIN-CCAT  PIC  9(03)*/
        public IntBasis TB_LIMITE_PCTMIN_CCAT { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"    15   FILLER                PIC  X(04)*/
        public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
        /*"    15   TB-LIMITE-MAX-CCAT     PIC  9(08)*/
        public IntBasis TB_LIMITE_MAX_CCAT { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"    15   FILLER                PIC  X(01)*/
        public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15   TB-LIMITE-PCTMAX-CCAT  PIC  9(03)*/
        public IntBasis TB_LIMITE_PCTMAX_CCAT { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"    15   FILLER                PIC  X(02)*/
        public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"*/

        public LBTB3201_TAB_LIMITE_MINMAX_CCAT()
        {
            TB_LIMITE_MIN_CCAT.ValueChanged += OnValueChanged;
            FILLER_50.ValueChanged += OnValueChanged;
            TB_LIMITE_PCTMIN_CCAT.ValueChanged += OnValueChanged;
            FILLER_51.ValueChanged += OnValueChanged;
            TB_LIMITE_MAX_CCAT.ValueChanged += OnValueChanged;
            FILLER_52.ValueChanged += OnValueChanged;
            TB_LIMITE_PCTMAX_CCAT.ValueChanged += OnValueChanged;
            FILLER_53.ValueChanged += OnValueChanged;
        }

    }
}