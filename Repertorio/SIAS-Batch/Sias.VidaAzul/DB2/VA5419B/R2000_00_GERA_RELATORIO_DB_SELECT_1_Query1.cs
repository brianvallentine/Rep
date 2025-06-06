using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R2000_00_GERA_RELATORIO_DB_SELECT_1_Query1 : QueryBasis<R2000_00_GERA_RELATORIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCUSTAUX,
            NLMSAF
            INTO :V0RSAF1-VLCUSTAUXF,
            :V0RSAF1-NLMSAF
            FROM SEGUROS.V0HISTREPSAF
            WHERE CODCLIEN = :V0RSAF-CODCLIEN-ANT
            AND DTREF = :WHOST-DTREFANT
            AND CODOPER = 1800
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCUSTAUX
							,
											NLMSAF
											FROM SEGUROS.V0HISTREPSAF
											WHERE CODCLIEN = '{this.V0RSAF_CODCLIEN_ANT}'
											AND DTREF = '{this.WHOST_DTREFANT}'
											AND CODOPER = 1800";

            return query;
        }
        public string V0RSAF1_VLCUSTAUXF { get; set; }
        public string V0RSAF1_NLMSAF { get; set; }
        public string V0RSAF_CODCLIEN_ANT { get; set; }
        public string WHOST_DTREFANT { get; set; }

        public static R2000_00_GERA_RELATORIO_DB_SELECT_1_Query1 Execute(R2000_00_GERA_RELATORIO_DB_SELECT_1_Query1 r2000_00_GERA_RELATORIO_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_GERA_RELATORIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_GERA_RELATORIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_GERA_RELATORIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RSAF1_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.V0RSAF1_NLMSAF = result[i++].Value?.ToString();
            return dta;
        }

    }
}