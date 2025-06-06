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
    public class M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1 : QueryBasis<M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOL_SINISTRO,
            VAL_OPERACAO,
            DTMOVTO, NOMFAV,
            SITUACAO, TIPFAV,
            FONPAG, CODPSVI
            INTO :THIST-APOL-SINI,
            :THIST-VALPRI,
            :THIST-DTMOVTO, :THIST-NOMFAV,
            :THIST-SITUACAO, :THIST-TIPFAV,
            :THIST-FONPAG, :THIST-CODPSVI
            FROM SEGUROS.V1HISTSINI
            WHERE
            NUM_APOL_SINISTRO = :RELSIN-APOL-SINI
            AND OPERACAO = :RELSIN-OPERACAO
            AND DTMOVTO = :RELSIN-DTMOVTO
            AND OCORHIST = :RELSIN-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOL_SINISTRO
							,
											VAL_OPERACAO
							,
											DTMOVTO
							, NOMFAV
							,
											SITUACAO
							, TIPFAV
							,
											FONPAG
							, CODPSVI
											FROM SEGUROS.V1HISTSINI
											WHERE
											NUM_APOL_SINISTRO = '{this.RELSIN_APOL_SINI}'
											AND OPERACAO = '{this.RELSIN_OPERACAO}'
											AND DTMOVTO = '{this.RELSIN_DTMOVTO}'
											AND OCORHIST = '{this.RELSIN_OCORHIST}'";

            return query;
        }
        public string THIST_APOL_SINI { get; set; }
        public string THIST_VALPRI { get; set; }
        public string THIST_DTMOVTO { get; set; }
        public string THIST_NOMFAV { get; set; }
        public string THIST_SITUACAO { get; set; }
        public string THIST_TIPFAV { get; set; }
        public string THIST_FONPAG { get; set; }
        public string THIST_CODPSVI { get; set; }
        public string RELSIN_APOL_SINI { get; set; }
        public string RELSIN_OPERACAO { get; set; }
        public string RELSIN_OCORHIST { get; set; }
        public string RELSIN_DTMOVTO { get; set; }

        public static M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1 Execute(M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1 m_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1)
        {
            var ths = m_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1();
            var i = 0;
            dta.THIST_APOL_SINI = result[i++].Value?.ToString();
            dta.THIST_VALPRI = result[i++].Value?.ToString();
            dta.THIST_DTMOVTO = result[i++].Value?.ToString();
            dta.THIST_NOMFAV = result[i++].Value?.ToString();
            dta.THIST_SITUACAO = result[i++].Value?.ToString();
            dta.THIST_TIPFAV = result[i++].Value?.ToString();
            dta.THIST_FONPAG = result[i++].Value?.ToString();
            dta.THIST_CODPSVI = result[i++].Value?.ToString();
            return dta;
        }

    }
}