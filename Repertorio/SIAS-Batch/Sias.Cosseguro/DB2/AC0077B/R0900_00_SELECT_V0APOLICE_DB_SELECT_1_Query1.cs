using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0077B
{
    public class R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1 : QueryBasis<R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            TIPSGU,
            ORGAO,
            RAMO
            INTO :V0APOL-NUM-APOL,
            :V0APOL-TIPSGU,
            :V0APOL-ORGAO,
            :V0APOL-RAMO
            FROM SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :V1MSIN-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											TIPSGU
							,
											ORGAO
							,
											RAMO
											FROM SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.V1MSIN_NUM_APOL}'";

            return query;
        }
        public string V0APOL_NUM_APOL { get; set; }
        public string V0APOL_TIPSGU { get; set; }
        public string V0APOL_ORGAO { get; set; }
        public string V0APOL_RAMO { get; set; }
        public string V1MSIN_NUM_APOL { get; set; }

        public static R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1 Execute(R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1 r0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0APOL_NUM_APOL = result[i++].Value?.ToString();
            dta.V0APOL_TIPSGU = result[i++].Value?.ToString();
            dta.V0APOL_ORGAO = result[i++].Value?.ToString();
            dta.V0APOL_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}