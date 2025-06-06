using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG017
{
    public class P0112_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0112_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT STA_DPS_PROPOSTA
            INTO :WH-STA-DPS-PROPOSTA
            FROM SEGUROS.VG_STA_DPS_PROPOSTA
            WHERE STA_DPS_PROPOSTA = :WH-STA-DPS-PROPOSTA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT STA_DPS_PROPOSTA
											FROM SEGUROS.VG_STA_DPS_PROPOSTA
											WHERE STA_DPS_PROPOSTA = '{this.WH_STA_DPS_PROPOSTA}'
											WITH UR";

            return query;
        }
        public string WH_STA_DPS_PROPOSTA { get; set; }

        public static P0112_05_INICIO_DB_SELECT_1_Query1 Execute(P0112_05_INICIO_DB_SELECT_1_Query1 p0112_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0112_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0112_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0112_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WH_STA_DPS_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}