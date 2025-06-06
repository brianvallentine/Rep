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
    public class LBSI0005_TB_OCORRENCIA : VarBasis
    {
        /*"        20     TB-COD-MSG        PIC  9(002)*/
        public IntBasis TB_COD_MSG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"        20     TB-MENSAGEM       PIC  X(058)*/
        public StringBasis TB_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "58", "X(058)"), @"");
        /*"*/

        public LBSI0005_TB_OCORRENCIA()
        {
            TB_COD_MSG.ValueChanged += OnValueChanged;
            TB_MENSAGEM.ValueChanged += OnValueChanged;
        }

    }
}