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
    public class R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1 : QueryBasis<R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_NUM_LOTE
				SET NUM_LOTE =  '{this.SINNUMLO_NUM_LOTE}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_FONTE =  '{this.SINNUMLO_COD_FONTE}'
				AND TIMESTAMP =  '{this.SINNUMLO_TIMESTAMP}'";

            return query;
        }
        public string SINNUMLO_NUM_LOTE { get; set; }
        public string SINNUMLO_COD_FONTE { get; set; }
        public string SINNUMLO_TIMESTAMP { get; set; }

        public static void Execute(R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1 r1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1)
        {
            var ths = r1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}