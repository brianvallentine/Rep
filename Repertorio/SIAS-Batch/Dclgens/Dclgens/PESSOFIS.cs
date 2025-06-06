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
    public class PESSOFIS : VarBasis
    {
        /*"01  DCLPESSOA-FISICA.*/
        public PESSOFIS_DCLPESSOA_FISICA DCLPESSOA_FISICA { get; set; } = new PESSOFIS_DCLPESSOA_FISICA();

    }
}