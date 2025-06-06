using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_135_000_CANCELAMENTO_DB_SELECT_1_Query1 : QueryBasis<M_135_000_CANCELAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VAL_OPERACAO)
            INTO :THIST-VALPRI:WVARIAV-IND
            FROM SEGUROS.V1HISTSINI
            WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI
            AND (OPERACAO = 107
            OR OPERACAO = 108
            OR OPERACAO = 117
            OR OPERACAO = 118)
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VAL_OPERACAO)
											FROM SEGUROS.V1HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.RELSIN_APOL_SINI}'
											AND (OPERACAO = 107
											OR OPERACAO = 108
											OR OPERACAO = 117
											OR OPERACAO = 118)
											AND SITUACAO = '0'";

            return query;
        }
        public string THIST_VALPRI { get; set; }
        public string WVARIAV_IND { get; set; }
        public string RELSIN_APOL_SINI { get; set; }

        public static M_135_000_CANCELAMENTO_DB_SELECT_1_Query1 Execute(M_135_000_CANCELAMENTO_DB_SELECT_1_Query1 m_135_000_CANCELAMENTO_DB_SELECT_1_Query1)
        {
            var ths = m_135_000_CANCELAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_135_000_CANCELAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_135_000_CANCELAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.THIST_VALPRI = result[i++].Value?.ToString();
            dta.WVARIAV_IND = string.IsNullOrWhiteSpace(dta.THIST_VALPRI) ? "-1" : "0";
            return dta;
        }

    }
}