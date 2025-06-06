using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0890B
{
    public class R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1 : QueryBasis<R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_CAUSA
            INTO :SINISCAU-DESCR-CAUSA
            FROM SEGUROS.SINISTRO_CAUSA
            WHERE RAMO_EMISSOR = 18
            AND COD_CAUSA = :SINISCAU-COD-CAUSA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_CAUSA
											FROM SEGUROS.SINISTRO_CAUSA
											WHERE RAMO_EMISSOR = 18
											AND COD_CAUSA = '{this.SINISCAU_COD_CAUSA}'";

            return query;
        }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SINISCAU_COD_CAUSA { get; set; }

        public static R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1 Execute(R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1 r0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1)
        {
            var ths = r0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            return dta;
        }

    }
}