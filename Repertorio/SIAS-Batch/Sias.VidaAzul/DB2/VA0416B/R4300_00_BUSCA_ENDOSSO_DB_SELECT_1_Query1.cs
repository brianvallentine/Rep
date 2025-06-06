using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0416B
{
    public class R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRENDOS
            INTO :V0HCTB-NRENDOS
            FROM SEGUROS.V0HISTCONTABILVA
            WHERE NRCERTIF = :V0HCOB-NRCERTIF
            AND NRPARCEL = :V0HCOB-NRPARCEL
            AND NRTIT = :V0HCOB-NRTIT
            AND OCOORHIST = :V0HCOB-OCORHIST
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NRENDOS
											FROM SEGUROS.V0HISTCONTABILVA
											WHERE NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCOB_NRPARCEL}'
											AND NRTIT = '{this.V0HCOB_NRTIT}'
											AND OCOORHIST = '{this.V0HCOB_OCORHIST}'";

            return query;
        }
        public string V0HCTB_NRENDOS { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0HCOB_NRTIT { get; set; }

        public static R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 Execute(R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 r4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCTB_NRENDOS = result[i++].Value?.ToString();
            return dta;
        }

    }
}