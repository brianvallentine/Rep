using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0853B
{
    public class R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1 : QueryBasis<R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :CEDENTE-NUM-TITULO
            FROM SEGUROS.CEDENTE
            WHERE COD_CEDENTE = 36
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.CEDENTE
											WHERE COD_CEDENTE = 36";

            return query;
        }
        public string CEDENTE_NUM_TITULO { get; set; }

        public static R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1 Execute(R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1 r1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1)
        {
            var ths = r1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1220_00_GERA_NUM_TITULO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CEDENTE_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}