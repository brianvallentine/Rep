using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1 : QueryBasis<R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_CAPALOTE1
				SET QTD_LANCAMENTO =  '{this.SINISCAP_QTD_LANCAMENTO}',
				VAL_TOT_LANCA =  '{this.SINISCAP_VAL_TOT_LANCA}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_FONTE =  '{this.SINNUMLO_COD_FONTE}'
				AND NUM_LOTE =  '{this.SINNUMLO_NUM_LOTE}'";

            return query;
        }
        public string SINISCAP_QTD_LANCAMENTO { get; set; }
        public string SINISCAP_VAL_TOT_LANCA { get; set; }
        public string SINNUMLO_COD_FONTE { get; set; }
        public string SINNUMLO_NUM_LOTE { get; set; }

        public static void Execute(R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1 r1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1)
        {
            var ths = r1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}