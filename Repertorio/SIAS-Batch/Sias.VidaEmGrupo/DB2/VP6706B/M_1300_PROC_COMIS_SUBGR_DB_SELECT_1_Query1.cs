using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP6706B
{
    public class M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1 : QueryBasis<M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(DATA_ADMISSAO, DATE( '1900-01-01' ))
            INTO :SQL-DTADMIS
            FROM SEGUROS.V0PROPOSTAVA
            WHERE NRCERTIF = :SQL-NUM-CERT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(DATA_ADMISSAO
							, DATE( '1900-01-01' ))
											FROM SEGUROS.V0PROPOSTAVA
											WHERE NRCERTIF = '{this.SQL_NUM_CERT}'";

            return query;
        }
        public string SQL_DTADMIS { get; set; }
        public string SQL_NUM_CERT { get; set; }

        public static M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1 Execute(M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1 m_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1)
        {
            var ths = m_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1();
            var i = 0;
            dta.SQL_DTADMIS = result[i++].Value?.ToString();
            return dta;
        }

    }
}