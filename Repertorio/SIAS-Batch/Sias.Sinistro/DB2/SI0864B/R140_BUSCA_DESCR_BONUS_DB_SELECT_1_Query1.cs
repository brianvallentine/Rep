using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0864B
{
    public class R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1 : QueryBasis<R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_BONUS
            INTO :LTTIPBON-DESCR-BONUS
            FROM SEGUROS.LT_TIPO_BONUS
            WHERE COD_BONUS = :LOTBONUS-TIPO-BONUS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_BONUS
											FROM SEGUROS.LT_TIPO_BONUS
											WHERE COD_BONUS = '{this.LOTBONUS_TIPO_BONUS}'";

            return query;
        }
        public string LTTIPBON_DESCR_BONUS { get; set; }
        public string LOTBONUS_TIPO_BONUS { get; set; }

        public static R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1 Execute(R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1 r140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1)
        {
            var ths = r140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTTIPBON_DESCR_BONUS = result[i++].Value?.ToString();
            return dta;
        }

    }
}