using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1471B
{
    public class M_0000_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            DATA_MOV_ABERTO - 10 DAYS,
            DATA_MOV_ABERTO - 1 MONTH,
            DATA_MOV_ABERTO - 60 MONTHS,
            CURRENT DATE
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DTMOVABE-10D,
            :SISTEMAS-DTMOVABE-1M,
            :SISTEMAS-DTMOVABE-60M,
            :SISTEMAS-DTCURREN
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VA'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											DATA_MOV_ABERTO - 10 DAYS
							,
											DATA_MOV_ABERTO - 1 MONTH
							,
											DATA_MOV_ABERTO - 60 MONTHS
							,
											CURRENT DATE
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VA'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SISTEMAS_DTMOVABE_10D { get; set; }
        public string SISTEMAS_DTMOVABE_1M { get; set; }
        public string SISTEMAS_DTMOVABE_60M { get; set; }
        public string SISTEMAS_DTCURREN { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_1_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_1_Query1 m_0000_PRINCIPAL_DB_SELECT_1_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.SISTEMAS_DTMOVABE_10D = result[i++].Value?.ToString();
            dta.SISTEMAS_DTMOVABE_1M = result[i++].Value?.ToString();
            dta.SISTEMAS_DTMOVABE_60M = result[i++].Value?.ToString();
            dta.SISTEMAS_DTCURREN = result[i++].Value?.ToString();
            return dta;
        }

    }
}