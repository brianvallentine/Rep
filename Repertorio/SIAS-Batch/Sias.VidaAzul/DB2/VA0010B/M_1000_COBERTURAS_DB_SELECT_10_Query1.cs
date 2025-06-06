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
    public class M_1000_COBERTURAS_DB_SELECT_10_Query1 : QueryBasis<M_1000_COBERTURAS_DB_SELECT_10_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCUSTCAP
            INTO :CUSTCAP-VLCUSTCAP
            FROM SEGUROS.V0CUSTOCAPVG
            WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE
            AND CODSUBES = :V1SEGV-COD-SUBGRUPO
            AND DTINIVIG <= :V1HSEG-DTMOVTO
            AND DTTERVIG >= :V1HSEG-DTMOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCUSTCAP
											FROM SEGUROS.V0CUSTOCAPVG
											WHERE NUM_APOLICE = '{this.V1SEGV_NUM_APOLICE}'
											AND CODSUBES = '{this.V1SEGV_COD_SUBGRUPO}'
											AND DTINIVIG <= '{this.V1HSEG_DTMOVTO}'
											AND DTTERVIG >= '{this.V1HSEG_DTMOVTO}'";

            return query;
        }
        public string CUSTCAP_VLCUSTCAP { get; set; }
        public string V1SEGV_COD_SUBGRUPO { get; set; }
        public string V1SEGV_NUM_APOLICE { get; set; }
        public string V1HSEG_DTMOVTO { get; set; }

        public static M_1000_COBERTURAS_DB_SELECT_10_Query1 Execute(M_1000_COBERTURAS_DB_SELECT_10_Query1 m_1000_COBERTURAS_DB_SELECT_10_Query1)
        {
            var ths = m_1000_COBERTURAS_DB_SELECT_10_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_COBERTURAS_DB_SELECT_10_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_COBERTURAS_DB_SELECT_10_Query1();
            var i = 0;
            dta.CUSTCAP_VLCUSTCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}