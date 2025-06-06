using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1 : QueryBasis<M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUMCERVG
            INTO
            :NUMCERVG
            FROM
            SEGUROS.V1NUMERO_OUTROS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUMCERVG
											FROM
											SEGUROS.V1NUMERO_OUTROS";

            return query;
        }
        public string NUMCERVG { get; set; }

        public static M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1 Execute(M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1 m_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1)
        {
            var ths = m_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMCERVG = result[i++].Value?.ToString();
            return dta;
        }

    }
}