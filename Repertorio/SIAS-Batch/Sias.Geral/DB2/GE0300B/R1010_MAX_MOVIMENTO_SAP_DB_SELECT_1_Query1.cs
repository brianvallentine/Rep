using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0300B
{
    public class R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1 : QueryBasis<R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_MOVTO),0) + 1
            INTO :GE099-NUM-OCORR-MOVTO
            FROM SEGUROS.GE_MOVIMENTO_SAP
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_MOVTO)
							,0) + 1
											FROM SEGUROS.GE_MOVIMENTO_SAP
											WITH UR";

            return query;
        }
        public string GE099_NUM_OCORR_MOVTO { get; set; }

        public static R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1 Execute(R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1 r1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1)
        {
            var ths = r1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE099_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}