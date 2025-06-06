using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1 : QueryBasis<M_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CLIENTE_EMAIL
				SET EMAIL =  '{this.BI0005L_S_EMAIL}'
				WHERE  COD_CLIENTE =  '{this.WS_COD_CLI_ATU}'
				AND SEQ_EMAIL =  '{this.WS_SEQ_EMA_ATU}'";

            return query;
        }
        public string BI0005L_S_EMAIL { get; set; }
        public string WS_COD_CLI_ATU { get; set; }
        public string WS_SEQ_EMA_ATU { get; set; }

        public static void Execute(M_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1 m_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1)
        {
            var ths = m_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}