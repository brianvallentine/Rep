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
    public class PESFIS : VarBasis
    {
        /*"01  DCLPESSOA-FISICA.*/
        public PESFIS_DCLPESSOA_FISICA DCLPESSOA_FISICA { get; set; } = new PESFIS_DCLPESSOA_FISICA();

    }
}