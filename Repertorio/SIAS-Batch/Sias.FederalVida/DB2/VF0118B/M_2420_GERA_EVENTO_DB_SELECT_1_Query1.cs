using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_2420_GERA_EVENTO_DB_SELECT_1_Query1 : QueryBasis<M_2420_GERA_EVENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :PDTVF-OCORHIST
            FROM SEGUROS.V0PRODUTORVF
            WHERE CODPDT = :PLCOM-CODPDT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V0PRODUTORVF
											WHERE CODPDT = '{this.PLCOM_CODPDT}'";

            return query;
        }
        public string PDTVF_OCORHIST { get; set; }
        public string PLCOM_CODPDT { get; set; }

        public static M_2420_GERA_EVENTO_DB_SELECT_1_Query1 Execute(M_2420_GERA_EVENTO_DB_SELECT_1_Query1 m_2420_GERA_EVENTO_DB_SELECT_1_Query1)
        {
            var ths = m_2420_GERA_EVENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2420_GERA_EVENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2420_GERA_EVENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PDTVF_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}