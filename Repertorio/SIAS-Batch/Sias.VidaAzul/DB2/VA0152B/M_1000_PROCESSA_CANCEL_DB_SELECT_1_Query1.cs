using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0152B
{
    public class M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1 : QueryBasis<M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA + 3 MONTH
            INTO :DTMAXCAN
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA + 3 MONTH
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string DTMAXCAN { get; set; }
        public string NRCERTIF { get; set; }

        public static M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1 Execute(M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1 m_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1)
        {
            var ths = m_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1();
            var i = 0;
            dta.DTMAXCAN = result[i++].Value?.ToString();
            return dta;
        }

    }
}