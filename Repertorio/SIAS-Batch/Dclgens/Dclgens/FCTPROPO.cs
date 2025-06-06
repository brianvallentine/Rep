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
    public class FCTPROPO : VarBasis
    {
        /*"01  DCLFC-TP-PROPOSTA.*/
        public FCTPROPO_DCLFC_TP_PROPOSTA DCLFC_TP_PROPOSTA { get; set; } = new FCTPROPO_DCLFC_TP_PROPOSTA();

    }
}