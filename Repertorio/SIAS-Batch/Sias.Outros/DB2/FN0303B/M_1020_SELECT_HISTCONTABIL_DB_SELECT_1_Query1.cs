using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0303B
{
    public class M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1 : QueryBasis<M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(DTMOVTO),DATE( '1900-01-01' ))
            INTO
            :DATA-QUITACAO
            FROM
            SEGUROS.V0HISTCONTABILVA
            WHERE NRCERTIF = :NRCERTIF
            AND NRPARCEL = :NRPARCEL
            AND CODOPER BETWEEN 200 AND 299
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(DTMOVTO)
							,DATE( '1900-01-01' ))
											FROM
											SEGUROS.V0HISTCONTABILVA
											WHERE NRCERTIF = '{this.NRCERTIF}'
											AND NRPARCEL = '{this.NRPARCEL}'
											AND CODOPER BETWEEN 200 AND 299
											WITH UR";

            return query;
        }
        public string DATA_QUITACAO { get; set; }
        public string NRCERTIF { get; set; }
        public string NRPARCEL { get; set; }

        public static M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1 Execute(M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1 m_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1)
        {
            var ths = m_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1020_SELECT_HISTCONTABIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.DATA_QUITACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}