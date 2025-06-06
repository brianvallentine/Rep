using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1040_GERA_EVENTO_DB_SELECT_1_Query1 : QueryBasis<M_1040_GERA_EVENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :V0PDTV-OCORHIST
            FROM SEGUROS.V0PRODUTORVF
            WHERE CODPDT = :V0PLCO-CODPDT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V0PRODUTORVF
											WHERE CODPDT = '{this.V0PLCO_CODPDT}'";

            return query;
        }
        public string V0PDTV_OCORHIST { get; set; }
        public string V0PLCO_CODPDT { get; set; }

        public static M_1040_GERA_EVENTO_DB_SELECT_1_Query1 Execute(M_1040_GERA_EVENTO_DB_SELECT_1_Query1 m_1040_GERA_EVENTO_DB_SELECT_1_Query1)
        {
            var ths = m_1040_GERA_EVENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1040_GERA_EVENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1040_GERA_EVENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PDTV_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}