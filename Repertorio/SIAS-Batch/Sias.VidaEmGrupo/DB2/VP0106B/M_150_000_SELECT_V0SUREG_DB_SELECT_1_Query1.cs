using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0106B
{
    public class M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1 : QueryBasis<M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NOME_SUREG
            INTO
            :SUREG
            FROM SEGUROS.V0SUREG
            WHERE
            COD_SUREG = :FSUREG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOME_SUREG
											FROM SEGUROS.V0SUREG
											WHERE
											COD_SUREG = '{this.FSUREG}'";

            return query;
        }
        public string SUREG { get; set; }
        public string FSUREG { get; set; }

        public static M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1 Execute(M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1 m_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1)
        {
            var ths = m_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUREG = result[i++].Value?.ToString();
            return dta;
        }

    }
}