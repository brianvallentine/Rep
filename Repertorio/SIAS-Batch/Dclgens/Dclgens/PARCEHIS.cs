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
    public class PARCEHIS : VarBasis
    {
        /*"01  DCLPARCELA-HISTORICO.*/
        public PARCEHIS_DCLPARCELA_HISTORICO DCLPARCELA_HISTORICO { get; set; } = new PARCEHIS_DCLPARCELA_HISTORICO();

    }
}