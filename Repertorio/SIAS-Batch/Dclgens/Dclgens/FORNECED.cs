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
    public class FORNECED : VarBasis
    {
        /*"01  DCLFORNECEDORES.*/
        public FORNECED_DCLFORNECEDORES DCLFORNECEDORES { get; set; } = new FORNECED_DCLFORNECEDORES();

    }
}