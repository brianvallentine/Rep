using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 : QueryBasis<R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELA
				SET QTDDOC =  '{this.WHOST_QTDDOC}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRTIT =  '{this.V1MCOB_NRTIT}'
				AND NRPARCEL =  '{this.V1PARC_NRPARCEL}'";

            return query;
        }
        public string WHOST_QTDDOC { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1MCOB_NRTIT { get; set; }

        public static void Execute(R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 r6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1)
        {
            var ths = r6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}