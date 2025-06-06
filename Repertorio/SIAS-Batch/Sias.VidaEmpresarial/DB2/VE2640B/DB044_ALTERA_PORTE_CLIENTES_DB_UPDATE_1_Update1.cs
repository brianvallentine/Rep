using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1_Update1 : QueryBasis<DB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CLIENTES
				SET COD_PORTE_EMP =  '{this.CLIENTES_COD_PORTE_EMP}'
				WHERE  COD_CLIENTE =  '{this.CLIENTES_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_COD_PORTE_EMP { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static void Execute(DB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1_Update1 dB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1_Update1)
        {
            var ths = dB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}