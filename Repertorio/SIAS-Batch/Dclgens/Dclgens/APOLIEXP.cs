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
    public class APOLIEXP : VarBasis
    {
        /*"01  DCLAPOLICE-EXPURGO.*/
        public APOLIEXP_DCLAPOLICE_EXPURGO DCLAPOLICE_EXPURGO { get; set; } = new APOLIEXP_DCLAPOLICE_EXPURGO();

    }
}