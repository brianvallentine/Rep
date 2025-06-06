using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0035_SELECT_DEVOL_DB_SELECT_1_Query1 : QueryBasis<M_0035_SELECT_DEVOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESC_DEVOLUCAO
            INTO :VGDEVO-DES-DEVOLUCAO
            FROM SEGUROS.DEVOLUCAO_VIDAZUL
            WHERE COD_DEVOLUCAO = 116
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESC_DEVOLUCAO
											FROM SEGUROS.DEVOLUCAO_VIDAZUL
											WHERE COD_DEVOLUCAO = 116";

            return query;
        }
        public string VGDEVO_DES_DEVOLUCAO { get; set; }

        public static M_0035_SELECT_DEVOL_DB_SELECT_1_Query1 Execute(M_0035_SELECT_DEVOL_DB_SELECT_1_Query1 m_0035_SELECT_DEVOL_DB_SELECT_1_Query1)
        {
            var ths = m_0035_SELECT_DEVOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0035_SELECT_DEVOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0035_SELECT_DEVOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGDEVO_DES_DEVOLUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}