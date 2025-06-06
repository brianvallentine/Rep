using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0500B
{
    public class R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 : QueryBasis<R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIGLA_UF
            INTO :UNIDAFED-SIGLA-UF
            FROM SEGUROS.UNIDADE_FEDERACAO
            WHERE SIGLA_UF = :UNIDAFED-SIGLA-UF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIGLA_UF
											FROM SEGUROS.UNIDADE_FEDERACAO
											WHERE SIGLA_UF = '{this.UNIDAFED_SIGLA_UF}'";

            return query;
        }
        public string UNIDAFED_SIGLA_UF { get; set; }

        public static R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 Execute(R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 r010_CRITICA_INCLUSAO_DB_SELECT_1_Query1)
        {
            var ths = r010_CRITICA_INCLUSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.UNIDAFED_SIGLA_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}