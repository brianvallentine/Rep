using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0820B
{
    public class M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MONTH(DTMOVABE) ,
            YEAR(DTMOVABE) ,
            DTMOVABE ,
            CURRENT DATE
            INTO :V1SIST-MES-REFERENCIA ,
            :V1SIST-ANO-REFERENCIA ,
            :V1SIST-DATA-REFERENCIA ,
            :V1SIST-DTCURRENT
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MONTH(DTMOVABE) 
							,
											YEAR(DTMOVABE) 
							,
											DTMOVABE 
							,
											CURRENT DATE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'SI'";

            return query;
        }
        public string V1SIST_MES_REFERENCIA { get; set; }
        public string V1SIST_ANO_REFERENCIA { get; set; }
        public string V1SIST_DATA_REFERENCIA { get; set; }
        public string V1SIST_DTCURRENT { get; set; }

        public static M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1 Execute(M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1 m_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_MES_REFERENCIA = result[i++].Value?.ToString();
            dta.V1SIST_ANO_REFERENCIA = result[i++].Value?.ToString();
            dta.V1SIST_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.V1SIST_DTCURRENT = result[i++].Value?.ToString();
            return dta;
        }

    }
}