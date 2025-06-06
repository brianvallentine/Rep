using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0030B
{
    public class R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET DATA_REFERENCIA =  '{this.WDATA_BASE_10}'
				WHERE  CODRELAT = 'BI0030B1'
				AND SITUACAO = '0'";

            return query;
        }
        public string WDATA_BASE_10 { get; set; }

        public static void Execute(R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}