using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1 : QueryBasis<M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE YEAR(DATA_CALENDARIO) = :WS-ANO-MOVABERTO
            AND MONTH(DATA_CALENDARIO) = :WS-MES-MOVABERTO
            AND FERIADO <> 'N'
            AND DIA_SEMANA NOT IN ( 'D' , 'S' )
            ORDER BY DATA_CALENDARIO DESC
            FETCH FIRST 1 ROWS ONLY
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
											FROM SEGUROS.CALENDARIO
											WHERE YEAR(DATA_CALENDARIO) = '{this.WS_ANO_MOVABERTO}'
											AND MONTH(DATA_CALENDARIO) = '{this.WS_MES_MOVABERTO}'
											AND FERIADO <> 'N'
											AND DIA_SEMANA NOT IN ( 'D' 
							, 'S' )
											ORDER BY DATA_CALENDARIO DESC
											FETCH FIRST 1 ROWS ONLY";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string WS_ANO_MOVABERTO { get; set; }
        public string WS_MES_MOVABERTO { get; set; }

        public static M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1 Execute(M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1 m_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1)
        {
            var ths = m_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0050_DATA_ENCERRAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}