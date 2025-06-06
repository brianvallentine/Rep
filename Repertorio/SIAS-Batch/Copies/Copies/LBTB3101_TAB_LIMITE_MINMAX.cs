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
    public class LBTB3101_TAB_LIMITE_MINMAX : VarBasis
    {
        /*"    15   TB-LIMITE-MIN         PIC  9(08)*/
        public IntBasis TB_LIMITE_MIN { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"    15   FILLER                PIC  X(01)*/
        public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15   TB-LIMITE-PCTMIN      PIC  9(03)*/
        public IntBasis TB_LIMITE_PCTMIN { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"    15   FILLER                PIC  X(04)*/
        public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
        /*"    15   TB-LIMITE-MAX         PIC  9(08)*/
        public IntBasis TB_LIMITE_MAX { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"    15   FILLER                PIC  X(01)*/
        public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15   TB-LIMITE-PCTMAX      PIC  9(03)*/
        public IntBasis TB_LIMITE_PCTMAX { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"    15   FILLER                PIC  X(02)*/
        public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"01  TAB-EQUIP*/

        public LBTB3101_TAB_LIMITE_MINMAX()
        {
            TB_LIMITE_MIN.ValueChanged += OnValueChanged;
            FILLER_24.ValueChanged += OnValueChanged;
            TB_LIMITE_PCTMIN.ValueChanged += OnValueChanged;
            FILLER_25.ValueChanged += OnValueChanged;
            TB_LIMITE_MAX.ValueChanged += OnValueChanged;
            FILLER_26.ValueChanged += OnValueChanged;
            TB_LIMITE_PCTMAX.ValueChanged += OnValueChanged;
            FILLER_27.ValueChanged += OnValueChanged;
        }

    }
}