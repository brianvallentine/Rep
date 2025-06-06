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
    public class M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1 : QueryBasis<M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG, DTTERVIG,
            QTPARCEL, SITUACAO,
            FONTE
            INTO :ENDOS-DTINIVIG, :ENDOS-DTTERVIG,
            :ENDOS-QTPARCEL, :ENDOS-SITUACAO,
            :ENDOS-FONTE
            FROM SEGUROS.V1ENDOSSO
            WHERE NUM_APOLICE = :MEST-NUM-APOL
            AND NRENDOS = :MEST-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
							, DTTERVIG
							,
											QTPARCEL
							, SITUACAO
							,
											FONTE
											FROM SEGUROS.V1ENDOSSO
											WHERE NUM_APOLICE = '{this.MEST_NUM_APOL}'
											AND NRENDOS = '{this.MEST_NRENDOS}'";

            return query;
        }
        public string ENDOS_DTINIVIG { get; set; }
        public string ENDOS_DTTERVIG { get; set; }
        public string ENDOS_QTPARCEL { get; set; }
        public string ENDOS_SITUACAO { get; set; }
        public string ENDOS_FONTE { get; set; }
        public string MEST_NUM_APOL { get; set; }
        public string MEST_NRENDOS { get; set; }

        public static M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1 Execute(M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1 m_270_000_LER_TENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = m_270_000_LER_TENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOS_DTINIVIG = result[i++].Value?.ToString();
            dta.ENDOS_DTTERVIG = result[i++].Value?.ToString();
            dta.ENDOS_QTPARCEL = result[i++].Value?.ToString();
            dta.ENDOS_SITUACAO = result[i++].Value?.ToString();
            dta.ENDOS_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}