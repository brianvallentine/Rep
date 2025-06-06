using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0807B
{
    public class M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :W-COUNT-V0HISTSINI
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINI
            AND OPERACAO IN (1001, 1002, 1003, 1009)
            AND SITUACAO <> '2'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V0MEST_NUM_APOL_SINI}'
											AND OPERACAO IN (1001
							, 1002
							, 1003
							, 1009)
											AND SITUACAO <> '2'";

            return query;
        }
        public string W_COUNT_V0HISTSINI { get; set; }
        public string V0MEST_NUM_APOL_SINI { get; set; }

        public static M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 Execute(M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 m_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_COUNT_V0HISTSINI = result[i++].Value?.ToString();
            return dta;
        }

    }
}