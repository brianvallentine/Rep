using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0851B
{
    public class M_007_SELECT_V0RELAT_DB_SELECT_1_Query1 : QueryBasis<M_007_SELECT_V0RELAT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-COUNT
            FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'SI'
            AND CODRELAT = 'SI0851B'
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0RELATORIOS
											WHERE IDSISTEM = 'SI'
											AND CODRELAT = 'SI0851B'
											AND SITUACAO = '0'";

            return query;
        }
        public string HOST_COUNT { get; set; }

        public static M_007_SELECT_V0RELAT_DB_SELECT_1_Query1 Execute(M_007_SELECT_V0RELAT_DB_SELECT_1_Query1 m_007_SELECT_V0RELAT_DB_SELECT_1_Query1)
        {
            var ths = m_007_SELECT_V0RELAT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_007_SELECT_V0RELAT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_007_SELECT_V0RELAT_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}