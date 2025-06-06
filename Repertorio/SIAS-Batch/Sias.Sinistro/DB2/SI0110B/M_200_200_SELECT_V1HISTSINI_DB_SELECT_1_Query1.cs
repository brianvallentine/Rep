using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0110B
{
    public class M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1 : QueryBasis<M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO,
            OPERACAO
            INTO :V1HISTMEST-VAL-OPERACAO1,
            :V1HISTMEST-OPERACAO
            FROM SEGUROS.V1HISTSINI
            WHERE NUM_APOL_SINISTRO = :V1HISTMEST-NUM-SINISTRO AND
            OCORHIST = :V1HISTMEST-OCORHIST AND
            OPERACAO >= :V1HISTSINI-OPERACAO1 AND
            OPERACAO <= :V1HISTSINI-OPERACAO2
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
							,
											OPERACAO
											FROM SEGUROS.V1HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V1HISTMEST_NUM_SINISTRO}' AND
											OCORHIST = '{this.V1HISTMEST_OCORHIST}' AND
											OPERACAO >= '{this.V1HISTSINI_OPERACAO1}' AND
											OPERACAO <= '{this.V1HISTSINI_OPERACAO2}'";

            return query;
        }
        public string V1HISTMEST_VAL_OPERACAO1 { get; set; }
        public string V1HISTMEST_OPERACAO { get; set; }
        public string V1HISTMEST_NUM_SINISTRO { get; set; }
        public string V1HISTSINI_OPERACAO1 { get; set; }
        public string V1HISTSINI_OPERACAO2 { get; set; }
        public string V1HISTMEST_OCORHIST { get; set; }

        public static M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1 Execute(M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1 m_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = m_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_200_200_SELECT_V1HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1HISTMEST_VAL_OPERACAO1 = result[i++].Value?.ToString();
            dta.V1HISTMEST_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}