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
    public class APOLICOB : VarBasis
    {
        /*"01  DCLAPOLICE-COBERTURAS.*/
        public APOLICOB_DCLAPOLICE_COBERTURAS DCLAPOLICE_COBERTURAS { get; set; } = new APOLICOB_DCLAPOLICE_COBERTURAS();

    }
}