using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0042B
{
    public class R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1 : QueryBasis<R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_EVENTO
            INTO :SIEVETIP-DESCR-EVENTO
            FROM SEGUROS.SI_EVENTO_TIPO
            WHERE COD_EVENTO = :SISINACO-COD-EVENTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_EVENTO
											FROM SEGUROS.SI_EVENTO_TIPO
											WHERE COD_EVENTO = '{this.SISINACO_COD_EVENTO}'";

            return query;
        }
        public string SIEVETIP_DESCR_EVENTO { get; set; }
        public string SISINACO_COD_EVENTO { get; set; }

        public static R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1 Execute(R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1 r2200_00_LE_SIEVETIP_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_LE_SIEVETIP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_LE_SIEVETIP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIEVETIP_DESCR_EVENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}