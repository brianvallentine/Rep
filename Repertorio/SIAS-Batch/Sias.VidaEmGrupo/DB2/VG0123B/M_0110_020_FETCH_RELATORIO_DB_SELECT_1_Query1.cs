using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0123B
{
    public class M_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1 : QueryBasis<M_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:DATA-REF1) + 1 MONTHS - 1 DAY
            INTO :DATA-REF2
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VG'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.DATA_REF1}') + 1 MONTHS - 1 DAY
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VG'";

            return query;
        }
        public string DATA_REF2 { get; set; }
        public string DATA_REF1 { get; set; }

        public static M_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1 Execute(M_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1 m_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1)
        {
            var ths = m_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.DATA_REF2 = result[i++].Value?.ToString();
            return dta;
        }

    }
}