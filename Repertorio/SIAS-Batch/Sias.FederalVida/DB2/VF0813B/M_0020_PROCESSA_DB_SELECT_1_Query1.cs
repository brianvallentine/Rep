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
    public class M_0020_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<M_0020_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERIPGTO,
            DIA_DEBITO,
            OPCAOPAG
            INTO :V0OPCP-PERIPGTO,
            :V0OPCP-DIADEB,
            :V0OPCP-OPCAOPAG
            FROM SEGUROS.V0OPCAOPAGVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERIPGTO
							,
											DIA_DEBITO
							,
											OPCAOPAG
											FROM SEGUROS.V0OPCAOPAGVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_DIADEB { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static M_0020_PROCESSA_DB_SELECT_1_Query1 Execute(M_0020_PROCESSA_DB_SELECT_1_Query1 m_0020_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = m_0020_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0020_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0020_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0OPCP_PERIPGTO = result[i++].Value?.ToString();
            dta.V0OPCP_DIADEB = result[i++].Value?.ToString();
            dta.V0OPCP_OPCAOPAG = result[i++].Value?.ToString();
            return dta;
        }

    }
}