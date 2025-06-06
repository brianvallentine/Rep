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
    public class LBTB3101_TAB_UF : VarBasis
    {
        /*"    15 TB-REG  PIC 9(02)*/
        public IntBasis TB_REG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"    15 TB-UF   PIC X(02)*/
        public StringBasis TB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"    15 FILLER  PIC X(01)*/
        public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"    15 TB-EST  PIC X(25)*/
        public StringBasis TB_EST { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
        /*"01 TABELA-UF-4*/

        public LBTB3101_TAB_UF()
        {
            TB_REG.ValueChanged += OnValueChanged;
            TB_UF.ValueChanged += OnValueChanged;
            FILLER_11.ValueChanged += OnValueChanged;
            TB_EST.ValueChanged += OnValueChanged;
        }

    }
}