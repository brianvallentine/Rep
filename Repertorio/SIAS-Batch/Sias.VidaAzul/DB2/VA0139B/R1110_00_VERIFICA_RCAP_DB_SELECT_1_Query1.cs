using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1 : QueryBasis<R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :NUM-SICOB
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF = :V0HCTB-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF = '{this.V0HCTB_NRCERTIF}'";

            return query;
        }
        public string NUM_SICOB { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }

        public static R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1 Execute(R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1 r1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_SICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}