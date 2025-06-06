using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG011
{
    public class P3022_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P3022_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MOEDA
            , PCT_JUROS
            INTO :GE252-COD-MOEDA
            , :GE252-PCT-JUROS
            FROM SEGUROS.GE_PRODUTO_MOEDA
            WHERE COD_PRODUTO = :GE252-COD-PRODUTO
            AND DTA_FIM_VIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_MOEDA
											, PCT_JUROS
											FROM SEGUROS.GE_PRODUTO_MOEDA
											WHERE COD_PRODUTO = '{this.GE252_COD_PRODUTO}'
											AND DTA_FIM_VIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string GE252_COD_MOEDA { get; set; }
        public string GE252_PCT_JUROS { get; set; }
        public string GE252_COD_PRODUTO { get; set; }

        public static P3022_05_INICIO_DB_SELECT_1_Query1 Execute(P3022_05_INICIO_DB_SELECT_1_Query1 p3022_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p3022_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P3022_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P3022_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE252_COD_MOEDA = result[i++].Value?.ToString();
            dta.GE252_PCT_JUROS = result[i++].Value?.ToString();
            return dta;
        }

    }
}