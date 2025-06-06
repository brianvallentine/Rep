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
    public class PESSOEND : VarBasis
    {
        /*"01  DCLPESSOA-ENDERECO.*/
        public PESSOEND_DCLPESSOA_ENDERECO DCLPESSOA_ENDERECO { get; set; } = new PESSOEND_DCLPESSOA_ENDERECO();

    }
}