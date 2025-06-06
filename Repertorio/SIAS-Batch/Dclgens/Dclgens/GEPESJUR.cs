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
    public class GEPESJUR : VarBasis
    {
        /*"01  DCLGE-PESSOA-JURIDICA.*/
        public GEPESJUR_DCLGE_PESSOA_JURIDICA DCLGE_PESSOA_JURIDICA { get; set; } = new GEPESJUR_DCLGE_PESSOA_JURIDICA();

    }
}