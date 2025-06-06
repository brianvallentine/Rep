using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class M_015_000_CABECALHOS_DB_SELECT_1_Query1 : QueryBasis<M_015_000_CABECALHOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NOME_EMPRESA, CURRENT DATE
            INTO :V1EMPRESA-MNUEMP, :V1EMPRESA-DTCURRENT
            FROM SEGUROS.V1EMPRESA
            WHERE COD_EMPRESA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_EMPRESA
							, CURRENT DATE
											FROM SEGUROS.V1EMPRESA
											WHERE COD_EMPRESA = 0";

            return query;
        }
        public string V1EMPRESA_MNUEMP { get; set; }
        public string V1EMPRESA_DTCURRENT { get; set; }

        public static M_015_000_CABECALHOS_DB_SELECT_1_Query1 Execute(M_015_000_CABECALHOS_DB_SELECT_1_Query1 m_015_000_CABECALHOS_DB_SELECT_1_Query1)
        {
            var ths = m_015_000_CABECALHOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_015_000_CABECALHOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_015_000_CABECALHOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1EMPRESA_MNUEMP = result[i++].Value?.ToString();
            dta.V1EMPRESA_DTCURRENT = result[i++].Value?.ToString();
            return dta;
        }

    }
}