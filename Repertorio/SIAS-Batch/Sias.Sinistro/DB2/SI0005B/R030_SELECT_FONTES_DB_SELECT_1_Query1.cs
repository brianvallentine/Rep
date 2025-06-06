using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R030_SELECT_FONTES_DB_SELECT_1_Query1 : QueryBasis<R030_SELECT_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROTOCOLO_SINI
            INTO :FONTES-NUM-PROTOCOLO-SINI
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = 10
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROTOCOLO_SINI
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = 10";

            return query;
        }
        public string FONTES_NUM_PROTOCOLO_SINI { get; set; }

        public static R030_SELECT_FONTES_DB_SELECT_1_Query1 Execute(R030_SELECT_FONTES_DB_SELECT_1_Query1 r030_SELECT_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r030_SELECT_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R030_SELECT_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R030_SELECT_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            return dta;
        }

    }
}