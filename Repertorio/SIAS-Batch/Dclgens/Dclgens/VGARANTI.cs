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
    public class VGARANTI : VarBasis
    {
        /*"01  DCLVG-GARANTIA.*/
        public VGARANTI_DCLVG_GARANTIA DCLVG_GARANTIA { get; set; } = new VGARANTI_DCLVG_GARANTIA();

    }
}