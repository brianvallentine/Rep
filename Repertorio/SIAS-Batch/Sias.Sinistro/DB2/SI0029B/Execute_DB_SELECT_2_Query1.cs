using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0029B
{
    public class Execute_DB_SELECT_2_Query1 : QueryBasis<Execute_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :W-COUNT
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'SI0029B'
            AND DATA_SOLICITACAO = :SIST-DTMOVABE
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0RELATORIOS
											WHERE CODRELAT = 'SI0029B'
											AND DATA_SOLICITACAO = '{this.SIST_DTMOVABE}'
											AND SITUACAO = '0'";

            return query;
        }
        public string W_COUNT { get; set; }
        public string SIST_DTMOVABE { get; set; }

        public static Execute_DB_SELECT_2_Query1 Execute(Execute_DB_SELECT_2_Query1 execute_DB_SELECT_2_Query1)
        {
            var ths = execute_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_2_Query1();
            var i = 0;
            dta.W_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}