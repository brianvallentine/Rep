using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0681B
{
    public class M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1 : QueryBasis<M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESC_DEVOLUCAO
            INTO :DEVOLVID-DESC-DEVOLUCAO
            FROM SEGUROS.DEVOLUCAO_VIDAZUL
            WHERE COD_DEVOLUCAO = :DEVOLVID-COD-DEVOLUCAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESC_DEVOLUCAO
											FROM SEGUROS.DEVOLUCAO_VIDAZUL
											WHERE COD_DEVOLUCAO = '{this.DEVOLVID_COD_DEVOLUCAO}'";

            return query;
        }
        public string DEVOLVID_DESC_DEVOLUCAO { get; set; }
        public string DEVOLVID_COD_DEVOLUCAO { get; set; }

        public static M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1 Execute(M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1 m_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1)
        {
            var ths = m_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.DEVOLVID_DESC_DEVOLUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}