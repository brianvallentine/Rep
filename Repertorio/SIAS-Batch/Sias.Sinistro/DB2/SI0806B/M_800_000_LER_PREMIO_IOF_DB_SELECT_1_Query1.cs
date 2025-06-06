using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1 : QueryBasis<M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO
            INTO :THIST-VALPRI2
            FROM SEGUROS.V1HISTSINI
            WHERE
            NUM_APOL_SINISTRO = :RELSIN-APOL-SINI
            AND OPERACAO = 1
            AND SITUACAO = '0'
            AND OCORHIST = :RELSIN-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
											FROM SEGUROS.V1HISTSINI
											WHERE
											NUM_APOL_SINISTRO = '{this.RELSIN_APOL_SINI}'
											AND OPERACAO = 1
											AND SITUACAO = '0'
											AND OCORHIST = '{this.RELSIN_OCORHIST}'";

            return query;
        }
        public string THIST_VALPRI2 { get; set; }
        public string RELSIN_APOL_SINI { get; set; }
        public string RELSIN_OCORHIST { get; set; }

        public static M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1 Execute(M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1 m_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1)
        {
            var ths = m_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1();
            var i = 0;
            dta.THIST_VALPRI2 = result[i++].Value?.ToString();
            return dta;
        }

    }
}