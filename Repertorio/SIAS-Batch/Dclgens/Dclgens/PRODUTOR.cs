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
    public class PRODUTOR : VarBasis
    {
        /*"01  DCLPRODUTORES.*/
        public PRODUTOR_DCLPRODUTORES DCLPRODUTORES { get; set; } = new PRODUTOR_DCLPRODUTORES();

    }
}