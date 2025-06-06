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
    public class LBTB3101_TB_MESES : VarBasis
    {
        /*"     15   TB-MES                PIC  9(002)*/
        public IntBasis TB_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     15   TB-NOME-MES           PIC  X(009)*/
        public StringBasis TB_NOME_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
        /*"01 TABELA-UF*/

        public LBTB3101_TB_MESES()
        {
            TB_MES.ValueChanged += OnValueChanged;
            TB_NOME_MES.ValueChanged += OnValueChanged;
        }

    }
}