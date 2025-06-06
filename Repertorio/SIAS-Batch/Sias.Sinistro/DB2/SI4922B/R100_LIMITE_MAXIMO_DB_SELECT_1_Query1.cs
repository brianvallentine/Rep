using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI4922B
{
    public class R100_LIMITE_MAXIMO_DB_SELECT_1_Query1 : QueryBasis<R100_LIMITE_MAXIMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT DATE,
            CURRENT DATE + 20 DAYS
            INTO :W-DATA-CORRENTE,
            :W-DATA-LIMITE-MAXIMO
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT DATE
							,
											CURRENT DATE + 20 DAYS
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'SI'";

            return query;
        }
        public string W_DATA_CORRENTE { get; set; }
        public string W_DATA_LIMITE_MAXIMO { get; set; }

        public static R100_LIMITE_MAXIMO_DB_SELECT_1_Query1 Execute(R100_LIMITE_MAXIMO_DB_SELECT_1_Query1 r100_LIMITE_MAXIMO_DB_SELECT_1_Query1)
        {
            var ths = r100_LIMITE_MAXIMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_LIMITE_MAXIMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_LIMITE_MAXIMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_DATA_CORRENTE = result[i++].Value?.ToString();
            dta.W_DATA_LIMITE_MAXIMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}