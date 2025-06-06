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
    public class M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1 : QueryBasis<M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTA_INIVIG_ENDOSSO, DTA_FIMVIG_ENDOSSO
            INTO :V1ENDO-DTINIVIG,
            :V1ENDO-DTTERVIG
            FROM SEGUROS.SX_EM_ENDOSSO SX051,
            SEGUROS.SX_APOLICE SX010
            WHERE SX010.NUM_APOLICE = :V1MEST-NUM-APOL
            AND SX010.SEQ_PROP_APOL = SX051.SEQ_APOLICE
            AND (SX051.NUM_ENDOSSO = :V1MEST-NRENDOS
            OR SX051.NUM_ENDOSSO = 0)
            ORDER BY SX051.NUM_ENDOSSO DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTA_INIVIG_ENDOSSO
							, DTA_FIMVIG_ENDOSSO
											FROM SEGUROS.SX_EM_ENDOSSO SX051
							,
											SEGUROS.SX_APOLICE SX010
											WHERE SX010.NUM_APOLICE = '{this.V1MEST_NUM_APOL}'
											AND SX010.SEQ_PROP_APOL = SX051.SEQ_APOLICE
											AND (SX051.NUM_ENDOSSO = '{this.V1MEST_NRENDOS}'
											OR SX051.NUM_ENDOSSO = 0)
											ORDER BY SX051.NUM_ENDOSSO DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V1ENDO_DTINIVIG { get; set; }
        public string V1ENDO_DTTERVIG { get; set; }
        public string V1MEST_NUM_APOL { get; set; }
        public string V1MEST_NRENDOS { get; set; }

        public static M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1 Execute(M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1 m_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1)
        {
            var ths = m_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V1ENDO_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}