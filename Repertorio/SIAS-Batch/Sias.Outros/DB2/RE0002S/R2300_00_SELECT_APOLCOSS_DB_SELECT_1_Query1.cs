using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0002S
{
    public class R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1 : QueryBasis<R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PCT_PART_COSSEGURO),+0)
            INTO :APOLCOSS-PCT-PART-COSSEGURO
            FROM SEGUROS.APOL_COSSEGURADORA
            WHERE NUM_APOLICE = :APOLCOSS-NUM-APOLICE
            AND DATA_INIVIGENCIA <= :APOLCOSS-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :APOLCOSS-DATA-INIVIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PCT_PART_COSSEGURO)
							,+0)
											FROM SEGUROS.APOL_COSSEGURADORA
											WHERE NUM_APOLICE = '{this.APOLCOSS_NUM_APOLICE}'
											AND DATA_INIVIGENCIA <= '{this.APOLCOSS_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.APOLCOSS_DATA_INIVIGENCIA}'
											WITH UR";

            return query;
        }
        public string APOLCOSS_PCT_PART_COSSEGURO { get; set; }
        public string APOLCOSS_DATA_INIVIGENCIA { get; set; }
        public string APOLCOSS_NUM_APOLICE { get; set; }

        public static R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1 Execute(R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1 r2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOSS_PCT_PART_COSSEGURO = result[i++].Value?.ToString();
            return dta;
        }

    }
}