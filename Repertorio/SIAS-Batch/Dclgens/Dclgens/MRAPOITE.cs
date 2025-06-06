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
    public class MRAPOITE : VarBasis
    {
        /*"01  DCLMR-APOLICE-ITEM.*/
        public MRAPOITE_DCLMR_APOLICE_ITEM DCLMR_APOLICE_ITEM { get; set; } = new MRAPOITE_DCLMR_APOLICE_ITEM();

    }
}