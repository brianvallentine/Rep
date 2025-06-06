using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_0020_PROCESSA_DB_SELECT_2_Query1 : QueryBasis<M_0020_PROCESSA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST,
            NRPARCEL,
            DTVENCTO,
            SITUACAO,
            DTVENCTO - 1 DAY
            INTO :V0HCOB-OCORHIST,
            :V0HCOB-NRPARCEL,
            :V0HCOB-DTVENCTO,
            :V0HCOB-SITUACAO,
            :V0HCOB-DTALTOPC
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRTIT = :V0HCOB-NRTIT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
							,
											NRPARCEL
							,
											DTVENCTO
							,
											SITUACAO
							,
											DTVENCTO - 1 DAY
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRTIT = '{this.V0HCOB_NRTIT}'";

            return query;
        }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0HCOB_SITUACAO { get; set; }
        public string V0HCOB_DTALTOPC { get; set; }
        public string V0HCOB_NRTIT { get; set; }

        public static M_0020_PROCESSA_DB_SELECT_2_Query1 Execute(M_0020_PROCESSA_DB_SELECT_2_Query1 m_0020_PROCESSA_DB_SELECT_2_Query1)
        {
            var ths = m_0020_PROCESSA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0020_PROCESSA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0020_PROCESSA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0HCOB_OCORHIST = result[i++].Value?.ToString();
            dta.V0HCOB_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCOB_DTVENCTO = result[i++].Value?.ToString();
            dta.V0HCOB_SITUACAO = result[i++].Value?.ToString();
            dta.V0HCOB_DTALTOPC = result[i++].Value?.ToString();
            return dta;
        }

    }
}