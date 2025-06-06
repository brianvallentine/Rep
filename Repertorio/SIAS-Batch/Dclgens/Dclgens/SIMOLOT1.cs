using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class SIMOLOT1 : VarBasis
    {
        /*"01  DCLSI-MOV-LOTERICO1.*/
        public SIMOLOT1_DCLSI_MOV_LOTERICO1 DCLSI_MOV_LOTERICO1 { get; set; } = new SIMOLOT1_DCLSI_MOV_LOTERICO1();

    }
}