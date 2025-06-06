using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1 : QueryBasis<R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-STA-INCONCLUSIVO
            FROM SEGUROS.VG_DPS_PROPOSTA A
            WHERE A.NUM_PROPOSTA = :V0PROP-NRCERTIF
            AND A.STA_DPS_PROPOSTA = 7
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.VG_DPS_PROPOSTA A
											WHERE A.NUM_PROPOSTA = '{this.V0PROP_NRCERTIF}'
											AND A.STA_DPS_PROPOSTA = 7
											WITH UR";

            return query;
        }
        public string WS_STA_INCONCLUSIVO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1 Execute(R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1 r3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1)
        {
            var ths = r3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_STA_INCONCLUSIVO = result[i++].Value?.ToString();
            return dta;
        }

    }
}