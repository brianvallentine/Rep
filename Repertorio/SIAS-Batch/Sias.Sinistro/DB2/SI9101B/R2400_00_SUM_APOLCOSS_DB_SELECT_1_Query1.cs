using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1 : QueryBasis<R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(PCT_PART_COSSEGURO),0)
            INTO :APOLCOSS-PCT-PART-COSSEGURO
            FROM SEGUROS.APOL_COSSEGURADORA
            WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE
            AND DATA_INIVIGENCIA <= :APOLIAUT-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :APOLIAUT-DATA-INIVIGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(PCT_PART_COSSEGURO)
							,0)
											FROM SEGUROS.APOL_COSSEGURADORA
											WHERE NUM_APOLICE = '{this.SIARDEVC_NUM_APOLICE}'
											AND DATA_INIVIGENCIA <= '{this.APOLIAUT_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.APOLIAUT_DATA_INIVIGENCIA}'";

            return query;
        }
        public string APOLCOSS_PCT_PART_COSSEGURO { get; set; }
        public string APOLIAUT_DATA_INIVIGENCIA { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }

        public static R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1 Execute(R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1 r2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_SUM_APOLCOSS_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOSS_PCT_PART_COSSEGURO = result[i++].Value?.ToString();
            return dta;
        }

    }
}