using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1 : QueryBasis<M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BANCO
				SET NRTIT =  '{this.BANCOS_NRTIT}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  BANCO = 104";

            return query;
        }
        public string BANCOS_NRTIT { get; set; }

        public static void Execute(M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1 m_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1)
        {
            var ths = m_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}