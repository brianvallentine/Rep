using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class M_313_000_NOME_FONTE_DB_SELECT_1_Query1 : QueryBasis<M_313_000_NOME_FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CIDADE
            INTO
            :GEFONTE-CIDADE
            FROM
            SEGUROS.V1FONTE
            WHERE
            FONTE = :THIST-FONPAG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CIDADE
											FROM
											SEGUROS.V1FONTE
											WHERE
											FONTE = '{this.THIST_FONPAG}'";

            return query;
        }
        public string GEFONTE_CIDADE { get; set; }
        public string THIST_FONPAG { get; set; }

        public static M_313_000_NOME_FONTE_DB_SELECT_1_Query1 Execute(M_313_000_NOME_FONTE_DB_SELECT_1_Query1 m_313_000_NOME_FONTE_DB_SELECT_1_Query1)
        {
            var ths = m_313_000_NOME_FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_313_000_NOME_FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_313_000_NOME_FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEFONTE_CIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}