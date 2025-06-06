using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1 : QueryBasis<M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPERACAO, OCORHIST,
            NOMFAV , DTMOVTO ,
            VAL_OPERACAO
            INTO :THIST-OPERACAO, :THIST-OCORHIST,
            :THIST-NOMFAV , :THIST-DTMOVTO ,
            :THIST-VAL-OPERACAO
            FROM SEGUROS.V1HISTSINI
            WHERE
            NUM_APOL_SINISTRO = :V1RELA-NUMSINI
            AND OPERACAO = :V1RELA-OPERACAO
            AND OCORHIST = :V1RELA-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPERACAO
							, OCORHIST
							,
											NOMFAV 
							, DTMOVTO 
							,
											VAL_OPERACAO
											FROM SEGUROS.V1HISTSINI
											WHERE
											NUM_APOL_SINISTRO = '{this.V1RELA_NUMSINI}'
											AND OPERACAO = '{this.V1RELA_OPERACAO}'
											AND OCORHIST = '{this.V1RELA_OCORHIST}'";

            return query;
        }
        public string THIST_OPERACAO { get; set; }
        public string THIST_OCORHIST { get; set; }
        public string THIST_NOMFAV { get; set; }
        public string THIST_DTMOVTO { get; set; }
        public string THIST_VAL_OPERACAO { get; set; }
        public string V1RELA_OPERACAO { get; set; }
        public string V1RELA_OCORHIST { get; set; }
        public string V1RELA_NUMSINI { get; set; }

        public static M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1 Execute(M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1 m_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = m_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.THIST_OPERACAO = result[i++].Value?.ToString();
            dta.THIST_OCORHIST = result[i++].Value?.ToString();
            dta.THIST_NOMFAV = result[i++].Value?.ToString();
            dta.THIST_DTMOVTO = result[i++].Value?.ToString();
            dta.THIST_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}