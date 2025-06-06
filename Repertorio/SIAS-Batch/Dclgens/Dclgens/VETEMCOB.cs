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
    public class VETEMCOB : VarBasis
    {
        /*"01  DCLVE-TERMO-MOD-COBER.*/
        public VETEMCOB_DCLVE_TERMO_MOD_COBER DCLVE_TERMO_MOD_COBER { get; set; } = new VETEMCOB_DCLVE_TERMO_MOD_COBER();

    }
}