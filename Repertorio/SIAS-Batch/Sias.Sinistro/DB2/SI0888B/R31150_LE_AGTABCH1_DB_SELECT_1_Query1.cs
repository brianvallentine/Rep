using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class R31150_LE_AGTABCH1_DB_SELECT_1_Query1 : QueryBasis<R31150_LE_AGTABCH1_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DESCRICAO
            INTO
            :AGTABCH1-DESCRICAO
            FROM SEGUROS.AGRUPA_TABELAS_CH1
            WHERE IDTAB = :AGTABCH1-IDTAB
            AND CODIGO_CH1 = :AGTABCH1-CODIGO-CH1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DESCRICAO
											FROM SEGUROS.AGRUPA_TABELAS_CH1
											WHERE IDTAB = '{this.AGTABCH1_IDTAB}'
											AND CODIGO_CH1 = '{this.AGTABCH1_CODIGO_CH1}'";

            return query;
        }
        public string AGTABCH1_DESCRICAO { get; set; }
        public string AGTABCH1_CODIGO_CH1 { get; set; }
        public string AGTABCH1_IDTAB { get; set; }

        public static R31150_LE_AGTABCH1_DB_SELECT_1_Query1 Execute(R31150_LE_AGTABCH1_DB_SELECT_1_Query1 r31150_LE_AGTABCH1_DB_SELECT_1_Query1)
        {
            var ths = r31150_LE_AGTABCH1_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R31150_LE_AGTABCH1_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R31150_LE_AGTABCH1_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGTABCH1_DESCRICAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}