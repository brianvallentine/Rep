using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5001B
{
    public class R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1 : QueryBasis<R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARAM_CONTACEF
				SET NSAS =  '{this.PARAMCON_NSAS}',
				DATA_MOVIMENTO = CURRENT DATE,
				DATA_PROXIMO_DEB = CURRENT DATE,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_CONVENIO =  '{this.PARAMCON_COD_CONVENIO}'";

            return query;
        }
        public string PARAMCON_NSAS { get; set; }
        public string PARAMCON_COD_CONVENIO { get; set; }

        public static void Execute(R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1 r600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1)
        {
            var ths = r600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}