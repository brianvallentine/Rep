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
    public class APOLCOSS : VarBasis
    {
        /*"01  DCLAPOL-COSSEGURADORA.*/
        public APOLCOSS_DCLAPOL_COSSEGURADORA DCLAPOL_COSSEGURADORA { get; set; } = new APOLCOSS_DCLAPOL_COSSEGURADORA();

    }
}