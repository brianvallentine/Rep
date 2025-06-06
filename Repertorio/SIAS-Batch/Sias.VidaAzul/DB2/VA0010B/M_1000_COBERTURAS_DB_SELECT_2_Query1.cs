using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_COBERTURAS_DB_SELECT_2_Query1 : QueryBasis<M_1000_COBERTURAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALCPR
            INTO :MOEDA-VALCPR
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = :V1HSEG-CODMOEDA
            AND DTINIVIG <= :V1HSEG-DTMOVTO
            AND DTTERVIG >= :V1HSEG-DTMOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALCPR
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = '{this.V1HSEG_CODMOEDA}'
											AND DTINIVIG <= '{this.V1HSEG_DTMOVTO}'
											AND DTTERVIG >= '{this.V1HSEG_DTMOVTO}'";

            return query;
        }
        public string MOEDA_VALCPR { get; set; }
        public string V1HSEG_CODMOEDA { get; set; }
        public string V1HSEG_DTMOVTO { get; set; }

        public static M_1000_COBERTURAS_DB_SELECT_2_Query1 Execute(M_1000_COBERTURAS_DB_SELECT_2_Query1 m_1000_COBERTURAS_DB_SELECT_2_Query1)
        {
            var ths = m_1000_COBERTURAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_COBERTURAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_COBERTURAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOEDA_VALCPR = result[i++].Value?.ToString();
            return dta;
        }

    }
}