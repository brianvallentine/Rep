using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1 : QueryBasis<R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_MOVTO),0) + 1
            INTO :WS-HOST-PROX-OCORR
            FROM SEGUROS.GE_MOVIMENTO_SAP
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_MOVTO)
							,0) + 1
											FROM SEGUROS.GE_MOVIMENTO_SAP
											WITH UR";

            return query;
        }
        public string WS_HOST_PROX_OCORR { get; set; }

        public static R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1 Execute(R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1 r0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1)
        {
            var ths = r0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_PROX_OCORR = result[i++].Value?.ToString();
            return dta;
        }

    }
}