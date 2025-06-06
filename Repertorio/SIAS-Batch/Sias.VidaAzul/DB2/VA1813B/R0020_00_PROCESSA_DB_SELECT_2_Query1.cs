using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1813B
{
    public class R0020_00_PROCESSA_DB_SELECT_2_Query1 : QueryBasis<R0020_00_PROCESSA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT,
            OCORHIST,
            DTVENCTO,
            SITUACAO,
            VLPRMTOT,
            OPCAOPAG,
            DTVENCTO - 1 DAY
            INTO :V0HCOB-NRTIT,
            :V0HCOB-OCORHIST,
            :V0HCOB-DTVENCTO,
            :V0HCOB-SITUACAO,
            :V0HCOB-VLPRMTOT,
            :V0HCOB-OPCAOPAG,
            :V0HCOB-DTALTOPC
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND NRPARCEL = :V0HCTA-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
							,
											OCORHIST
							,
											DTVENCTO
							,
											SITUACAO
							,
											VLPRMTOT
							,
											OPCAOPAG
							,
											DTVENCTO - 1 DAY
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCTA_NRPARCEL}'";

            return query;
        }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0HCOB_SITUACAO { get; set; }
        public string V0HCOB_VLPRMTOT { get; set; }
        public string V0HCOB_OPCAOPAG { get; set; }
        public string V0HCOB_DTALTOPC { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }

        public static R0020_00_PROCESSA_DB_SELECT_2_Query1 Execute(R0020_00_PROCESSA_DB_SELECT_2_Query1 r0020_00_PROCESSA_DB_SELECT_2_Query1)
        {
            var ths = r0020_00_PROCESSA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0020_00_PROCESSA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0020_00_PROCESSA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            dta.V0HCOB_OCORHIST = result[i++].Value?.ToString();
            dta.V0HCOB_DTVENCTO = result[i++].Value?.ToString();
            dta.V0HCOB_SITUACAO = result[i++].Value?.ToString();
            dta.V0HCOB_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HCOB_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0HCOB_DTALTOPC = result[i++].Value?.ToString();
            return dta;
        }

    }
}