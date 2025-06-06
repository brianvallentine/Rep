using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0108B
{
    public class M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1 : QueryBasis<M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MOEDA_SINI
            INTO :MEST-COD-MD-SINI
            FROM SEGUROS.V1MESTSINI
            WHERE NUM_APOL_SINISTRO = :THIST-APOL-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MOEDA_SINI
											FROM SEGUROS.V1MESTSINI
											WHERE NUM_APOL_SINISTRO = '{this.THIST_APOL_SINI}'";

            return query;
        }
        public string MEST_COD_MD_SINI { get; set; }
        public string THIST_APOL_SINI { get; set; }

        public static M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1 Execute(M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1 m_620_000_LER_TMESTSINI_DB_SELECT_1_Query1)
        {
            var ths = m_620_000_LER_TMESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.MEST_COD_MD_SINI = result[i++].Value?.ToString();
            return dta;
        }

    }
}