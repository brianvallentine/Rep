using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_0000_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(DATA_CALENDARIO), CURRENT DATE)
            INTO :MIN-PROXVEN-DATE
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO >=
            (SELECT CURRENT DATE + 30 DAYS
            FROM SYSIBM.SYSDUMMY1)
            AND FERIADO <> 'N'
            AND DIA_SEMANA NOT IN( 'S' , 'D' )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(DATA_CALENDARIO)
							, CURRENT DATE)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO >=
											(SELECT CURRENT DATE + 30 DAYS
											FROM SYSIBM.SYSDUMMY1)
											AND FERIADO <> 'N'
											AND DIA_SEMANA NOT IN( 'S' 
							, 'D' )
											WITH UR";

            return query;
        }
        public string MIN_PROXVEN_DATE { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_2_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_2_Query1 m_0000_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.MIN_PROXVEN_DATE = result[i++].Value?.ToString();
            return dta;
        }

    }
}