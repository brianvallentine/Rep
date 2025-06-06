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
    public class GE404 : VarBasis
    {
        /*"01  DCLGE-CONTROLE-SIGCB-HIST.*/
        public GE404_DCLGE_CONTROLE_SIGCB_HIST DCLGE_CONTROLE_SIGCB_HIST { get; set; } = new GE404_DCLGE_CONTROLE_SIGCB_HIST();

    }
}