using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1 : QueryBasis<M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_TP_MSG_CRITICA
            INTO :WS-COD-TP-MSG-CRITICA
            FROM SEGUROS.VG_DM_MSG_CRITICA
            WHERE COD_MSG_CRITICA = :WS-COD-MSG-CRITICA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_TP_MSG_CRITICA
											FROM SEGUROS.VG_DM_MSG_CRITICA
											WHERE COD_MSG_CRITICA = '{this.WS_COD_MSG_CRITICA}'
											WITH UR";

            return query;
        }
        public string WS_COD_TP_MSG_CRITICA { get; set; }
        public string WS_COD_MSG_CRITICA { get; set; }

        public static M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1 Execute(M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1 m_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1)
        {
            var ths = m_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_TP_MSG_CRITICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}