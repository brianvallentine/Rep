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
    public class DB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1_Update1 : QueryBasis<DB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROP_SASSE_VIDA
				SET COD_CORRESP_BANC =  '{this.CLIENTES_COD_CLIENTE}'
				WHERE  NUM_IDENTIFICACAO =  '{this.PROPSSVD_NUM_IDENTIFICACAO}'";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string PROPSSVD_NUM_IDENTIFICACAO { get; set; }

        public static void Execute(DB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1_Update1 dB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1_Update1)
        {
            var ths = dB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}