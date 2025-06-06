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
    public class GE501 : VarBasis
    {
        /*"01  DCLGE-PROCESSA-SUB-SISTEMA.*/
        public GE501_DCLGE_PROCESSA_SUB_SISTEMA DCLGE_PROCESSA_SUB_SISTEMA { get; set; } = new GE501_DCLGE_PROCESSA_SUB_SISTEMA();

    }
}