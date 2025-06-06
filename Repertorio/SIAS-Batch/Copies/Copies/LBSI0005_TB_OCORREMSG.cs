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
    public class LBSI0005_TB_OCORREMSG : VarBasis
    {
        /*"      15     TB-OCORRENCIA*/
        public LBSI0005_TB_OCORRENCIA TB_OCORRENCIA { get; set; } = new LBSI0005_TB_OCORRENCIA();


        public LBSI0005_TB_OCORREMSG()
        {
            TB_OCORRENCIA.ValueChanged += OnValueChanged;
        }

    }
}