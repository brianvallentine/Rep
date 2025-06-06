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
    public class PESFONE : VarBasis
    {
        /*"01  DCLPESSOA-TELEFONE.*/
        public PESFONE_DCLPESSOA_TELEFONE DCLPESSOA_TELEFONE { get; set; } = new PESFONE_DCLPESSOA_TELEFONE();

    }
}