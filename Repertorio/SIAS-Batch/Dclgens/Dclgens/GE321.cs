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
    public class GE321 : VarBasis
    {
        /*"01  DCLGE-DNE-GRD-USUARIO.*/
        public GE321_DCLGE_DNE_GRD_USUARIO DCLGE_DNE_GRD_USUARIO { get; set; } = new GE321_DCLGE_DNE_GRD_USUARIO();

    }
}