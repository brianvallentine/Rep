using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1 : QueryBasis<M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO
            INTO :V0COSSEG-HISTSIN-VAL-OPERACAO
            FROM SEGUROS.V0COSSEG_HISTSIN
            WHERE CONGENER = :V1APCO-CODCOSS
            AND NUM_SINISTRO = :V1MEST-APOL-SINI
            AND OPERACAO = :V1HIST-OPERACAO
            AND OCORHIST = :V1HIST-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
											FROM SEGUROS.V0COSSEG_HISTSIN
											WHERE CONGENER = '{this.V1APCO_CODCOSS}'
											AND NUM_SINISTRO = '{this.V1MEST_APOL_SINI}'
											AND OPERACAO = '{this.V1HIST_OPERACAO}'
											AND OCORHIST = '{this.V1HIST_OCORHIST}'";

            return query;
        }
        public string V0COSSEG_HISTSIN_VAL_OPERACAO { get; set; }
        public string V1MEST_APOL_SINI { get; set; }
        public string V1HIST_OPERACAO { get; set; }
        public string V1HIST_OCORHIST { get; set; }
        public string V1APCO_CODCOSS { get; set; }

        public static M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1 Execute(M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1 m_380_000_LER_V1MOEDA_DB_SELECT_2_Query1)
        {
            var ths = m_380_000_LER_V1MOEDA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0COSSEG_HISTSIN_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}