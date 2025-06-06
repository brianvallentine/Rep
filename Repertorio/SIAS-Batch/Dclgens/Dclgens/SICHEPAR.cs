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
    public class SICHEPAR : VarBasis
    {
        /*"01  DCLSI-CHECKLIST-PARAM.*/
        public SICHEPAR_DCLSI_CHECKLIST_PARAM DCLSI_CHECKLIST_PARAM { get; set; } = new SICHEPAR_DCLSI_CHECKLIST_PARAM();

    }
}