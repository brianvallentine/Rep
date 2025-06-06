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
    public class FC239 : VarBasis
    {
        /*"01  DCLFC-PLANO-EMP-PARC.*/
        public FC239_DCLFC_PLANO_EMP_PARC DCLFC_PLANO_EMP_PARC { get; set; } = new FC239_DCLFC_PLANO_EMP_PARC();

    }
}