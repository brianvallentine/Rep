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
    public class EF025 : VarBasis
    {
        /*"01  DCLEF-CONTR-TERC-HAB.*/
        public EF025_DCLEF_CONTR_TERC_HAB DCLEF_CONTR_TERC_HAB { get; set; } = new EF025_DCLEF_CONTR_TERC_HAB();

    }
}