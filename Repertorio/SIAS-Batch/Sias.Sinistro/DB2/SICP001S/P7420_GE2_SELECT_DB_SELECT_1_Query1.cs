using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7420_GE2_SELECT_DB_SELECT_1_Query1 : QueryBasis<P7420_GE2_SELECT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(MAX(NUM_ID_ENVIO),0) + 1
            INTO
            :GE420-NUM-ID-ENVIO
            FROM SEGUROS.GE_MOVTO_ENVIO_MCP
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(MAX(NUM_ID_ENVIO)
							,0) + 1
											FROM SEGUROS.GE_MOVTO_ENVIO_MCP
											WITH UR";

            return query;
        }
        public string GE420_NUM_ID_ENVIO { get; set; }

        public static P7420_GE2_SELECT_DB_SELECT_1_Query1 Execute(P7420_GE2_SELECT_DB_SELECT_1_Query1 p7420_GE2_SELECT_DB_SELECT_1_Query1)
        {
            var ths = p7420_GE2_SELECT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P7420_GE2_SELECT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P7420_GE2_SELECT_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE420_NUM_ID_ENVIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}