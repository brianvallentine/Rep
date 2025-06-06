using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0805B
{
    public class M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1 : QueryBasis<M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE, CURRENT DATE,
            CURRENT DATE - 18 MONTHS
            INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT,
            :V1SIST-DTCURRENT-18
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VA'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							, CURRENT DATE
							,
											CURRENT DATE - 18 MONTHS
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VA'
											WITH UR";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DTCURRENT { get; set; }
        public string V1SIST_DTCURRENT_18 { get; set; }

        public static M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1 Execute(M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1 m_0001_INICIO_PROCESSO_DB_SELECT_1_Query1)
        {
            var ths = m_0001_INICIO_PROCESSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0001_INICIO_PROCESSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DTCURRENT = result[i++].Value?.ToString();
            dta.V1SIST_DTCURRENT_18 = result[i++].Value?.ToString();
            return dta;
        }

    }
}