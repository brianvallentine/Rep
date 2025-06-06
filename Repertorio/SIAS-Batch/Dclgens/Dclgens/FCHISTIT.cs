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
    public class FCHISTIT : VarBasis
    {
        /*"01  DCLFC-HIST-TITULO.*/
        public FCHISTIT_DCLFC_HIST_TITULO DCLFC_HIST_TITULO { get; set; } = new FCHISTIT_DCLFC_HIST_TITULO();

    }
}