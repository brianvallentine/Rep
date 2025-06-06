using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0847B
{
    public class R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1 : QueryBasis<R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCVEIC
            INTO :V1DVEI-DESCVEIC
            FROM SEGUROS.V1DESCRVEI
            WHERE VERSAO = :V1DVEI-VERSAO
            AND CDVEICL = :V1DVEI-CDVEICL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCVEIC
											FROM SEGUROS.V1DESCRVEI
											WHERE VERSAO = '{this.V1DVEI_VERSAO}'
											AND CDVEICL = '{this.V1DVEI_CDVEICL}'";

            return query;
        }
        public string V1DVEI_DESCVEIC { get; set; }
        public string V1DVEI_CDVEICL { get; set; }
        public string V1DVEI_VERSAO { get; set; }

        public static R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1 Execute(R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1 r2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1)
        {
            var ths = r2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2330_00_SELECT_V1DESCRVEI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1DVEI_DESCVEIC = result[i++].Value?.ToString();
            return dta;
        }

    }
}