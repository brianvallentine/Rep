using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0817B
{
    public class M_0100_PROCESSA_DB_SELECT_3_Query1 : QueryBasis<M_0100_PROCESSA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DTINIVIG,
            DTINIVIG + :V0SUBG-PERI-FATURAMENTO MONTHS - 1 DAY,
            DTTERVIG
            INTO
            :V0RELA-DTINIVIG,
            :V0RELA-DTTERVIG-CALC,
            :V0RELA-DTTERVIG
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0HCOB-NRCERTIF
            AND OCORHIST = :V0HCOB-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DTINIVIG
							,
											DTINIVIG + {this.V0SUBG_PERI_FATURAMENTO} MONTHS - 1 DAY
							,
											DTTERVIG
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND OCORHIST = '{this.V0HCOB_NRPARCEL}'";

            return query;
        }
        public string V0RELA_DTINIVIG { get; set; }
        public string V0RELA_DTTERVIG_CALC { get; set; }
        public string V0RELA_DTTERVIG { get; set; }
        public string V0SUBG_PERI_FATURAMENTO { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }

        public static M_0100_PROCESSA_DB_SELECT_3_Query1 Execute(M_0100_PROCESSA_DB_SELECT_3_Query1 m_0100_PROCESSA_DB_SELECT_3_Query1)
        {
            var ths = m_0100_PROCESSA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0RELA_DTINIVIG = result[i++].Value?.ToString();
            dta.V0RELA_DTTERVIG_CALC = result[i++].Value?.ToString();
            dta.V0RELA_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}