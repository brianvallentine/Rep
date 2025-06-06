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
    public class LBTB3101_TAB_UF_4 : VarBasis
    {
        /*"   15 TB-REG-4    PIC 9(02)*/
        public IntBasis TB_REG_4 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"   15 TB-UF-4     PIC X(02)*/
        public StringBasis TB_UF_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"   15 FILLER      PIC X(01)*/
        public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"   15 TB-EST-4    PIC X(25)*/
        public StringBasis TB_EST_4 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
        /*"01       TABELA-REGIAO*/

        public LBTB3101_TAB_UF_4()
        {
            TB_REG_4.ValueChanged += OnValueChanged;
            TB_UF_4.ValueChanged += OnValueChanged;
            FILLER_12.ValueChanged += OnValueChanged;
            TB_EST_4.ValueChanged += OnValueChanged;
        }

    }
}