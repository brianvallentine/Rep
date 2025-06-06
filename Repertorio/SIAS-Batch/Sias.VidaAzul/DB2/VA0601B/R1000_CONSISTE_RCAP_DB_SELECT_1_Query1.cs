using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R1000_CONSISTE_RCAP_DB_SELECT_1_Query1 : QueryBasis<R1000_CONSISTE_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_AZUL
            INTO :WS-NUM-PROPOSTA-AZUL
            FROM SEGUROS.BENEF_PROP_AZUL
            WHERE NUM_PROPOSTA_AZUL = :WS-NUM-PROPOSTA-AZUL
            AND GRAU_PARENTESCO = 'ERROPF'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_AZUL
											FROM SEGUROS.BENEF_PROP_AZUL
											WHERE NUM_PROPOSTA_AZUL = '{this.WS_NUM_PROPOSTA_AZUL}'
											AND GRAU_PARENTESCO = 'ERROPF'";

            return query;
        }
        public string WS_NUM_PROPOSTA_AZUL { get; set; }

        public static R1000_CONSISTE_RCAP_DB_SELECT_1_Query1 Execute(R1000_CONSISTE_RCAP_DB_SELECT_1_Query1 r1000_CONSISTE_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r1000_CONSISTE_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_CONSISTE_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_CONSISTE_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_NUM_PROPOSTA_AZUL = result[i++].Value?.ToString();
            return dta;
        }

    }
}