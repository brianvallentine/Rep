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
    public class GEDESCLA : VarBasis
    {
        /*"01  DCLGE-DESTINAT-CLASSE.*/
        public GEDESCLA_DCLGE_DESTINAT_CLASSE DCLGE_DESTINAT_CLASSE { get; set; } = new GEDESCLA_DCLGE_DESTINAT_CLASSE();

    }
}