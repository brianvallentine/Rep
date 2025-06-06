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
    public class PF037 : VarBasis
    {
        /*"01  DCLPF-ERRO-DEVOLUCAO.*/
        public PF037_DCLPF_ERRO_DEVOLUCAO DCLPF_ERRO_DEVOLUCAO { get; set; } = new PF037_DCLPF_ERRO_DEVOLUCAO();

    }
}