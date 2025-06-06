using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0820B
{
    public class M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CURRENT TIMESTAMP
            INTO :W-TIMESTAMP
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CURRENT TIMESTAMP
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'SI'";

            return query;
        }
        public string W_TIMESTAMP { get; set; }

        public static M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1 Execute(M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1 m_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}