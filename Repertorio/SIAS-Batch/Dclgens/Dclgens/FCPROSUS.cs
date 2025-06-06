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
    public class FCPROSUS : VarBasis
    {
        /*"01  DCLFC-PROCESSO-SUSEP.*/
        public FCPROSUS_DCLFC_PROCESSO_SUSEP DCLFC_PROCESSO_SUSEP { get; set; } = new FCPROSUS_DCLFC_PROCESSO_SUSEP();

    }
}