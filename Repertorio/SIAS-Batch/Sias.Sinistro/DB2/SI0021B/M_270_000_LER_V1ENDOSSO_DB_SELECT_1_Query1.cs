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
    public class M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG,
            DTTERVIG,
            CORRECAO
            INTO :V1ENDO-DTINIVIG,
            :V1ENDO-DTTERVIG,
            :V1ENDO-CORRECAO
            FROM SEGUROS.V1ENDOSSO
            WHERE NUM_APOLICE = :V1MEST-NUM-APOL
            AND NRENDOS = :V1MEST-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
							,
											DTTERVIG
							,
											CORRECAO
											FROM SEGUROS.V1ENDOSSO
											WHERE NUM_APOLICE = '{this.V1MEST_NUM_APOL}'
											AND NRENDOS = '{this.V1MEST_NRENDOS}'";

            return query;
        }
        public string V1ENDO_DTINIVIG { get; set; }
        public string V1ENDO_DTTERVIG { get; set; }
        public string V1ENDO_CORRECAO { get; set; }
        public string V1MEST_NUM_APOL { get; set; }
        public string V1MEST_NRENDOS { get; set; }

        public static M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1 Execute(M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1 m_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = m_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V1ENDO_DTTERVIG = result[i++].Value?.ToString();
            dta.V1ENDO_CORRECAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}