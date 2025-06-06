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
    public class LBTB3201_TB_VIG_PLURI : VarBasis
    {
        /*"      15   TB-IND-ANO-PLURI      PIC  9(002)*/
        public IntBasis TB_IND_ANO_PLURI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      15   FILLER                PIC  X(001)*/
        public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      15   TB-QTD-PCL-PLURI      PIC  9(002)*/
        public IntBasis TB_QTD_PCL_PLURI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      15   FILLER                PIC  X(001)*/
        public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      15   TB-DTTER-PLURI        PIC  X(010)*/
        public StringBasis TB_DTTER_PLURI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"      15   FILLER                PIC  X(001)*/
        public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      15   TB-NOME-PLURI         PIC  X(030)*/
        public StringBasis TB_NOME_PLURI { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"01       TABELA-MESES*/

        public LBTB3201_TB_VIG_PLURI()
        {
            TB_IND_ANO_PLURI.ValueChanged += OnValueChanged;
            FILLER_9.ValueChanged += OnValueChanged;
            TB_QTD_PCL_PLURI.ValueChanged += OnValueChanged;
            FILLER_10.ValueChanged += OnValueChanged;
            TB_DTTER_PLURI.ValueChanged += OnValueChanged;
            FILLER_11.ValueChanged += OnValueChanged;
            TB_NOME_PLURI.ValueChanged += OnValueChanged;
        }

    }
}