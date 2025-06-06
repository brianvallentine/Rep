using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0077B
{
    public class M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1 : QueryBasis<M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            CODCAU,
            RAMO,
            NUMIRB,
            DATORR
            INTO :V0MEST-NUM-APOLICE,
            :V0MEST-CODCAU,
            :V0MEST-RAMO,
            :V0MEST-NUMIRB,
            :V0MEST-DATORR
            FROM SEGUROS.V0MESTSINI
            WHERE NUM_APOL_SINISTRO = :V0HABIT4-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											CODCAU
							,
											RAMO
							,
											NUMIRB
							,
											DATORR
											FROM SEGUROS.V0MESTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V0HABIT4_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string V0MEST_NUM_APOLICE { get; set; }
        public string V0MEST_CODCAU { get; set; }
        public string V0MEST_RAMO { get; set; }
        public string V0MEST_NUMIRB { get; set; }
        public string V0MEST_DATORR { get; set; }
        public string V0HABIT4_NUM_APOL_SINISTRO { get; set; }

        public static M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1 Execute(M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1 m_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1)
        {
            var ths = m_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0MEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0MEST_CODCAU = result[i++].Value?.ToString();
            dta.V0MEST_RAMO = result[i++].Value?.ToString();
            dta.V0MEST_NUMIRB = result[i++].Value?.ToString();
            dta.V0MEST_DATORR = result[i++].Value?.ToString();
            return dta;
        }

    }
}