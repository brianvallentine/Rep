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
    public class SISTEMAS : VarBasis
    {
        /*"01  DCLSISTEMAS.*/
        public SISTEMAS_DCLSISTEMAS DCLSISTEMAS { get; set; } = new SISTEMAS_DCLSISTEMAS();

    }
}