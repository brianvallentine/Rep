using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP5705B
{
    public class M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1 : QueryBasis<M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_NASCIMENTO
            INTO :V1CLIE-DTNASCIM:V1CLIE-DTNASCIM-I
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V1SEGV-CODCLI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_NASCIMENTO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V1SEGV_CODCLI}'";

            return query;
        }
        public string V1CLIE_DTNASCIM { get; set; }
        public string V1CLIE_DTNASCIM_I { get; set; }
        public string V1SEGV_CODCLI { get; set; }

        public static M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1 Execute(M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1 m_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1)
        {
            var ths = m_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1();
            var i = 0;
            dta.V1CLIE_DTNASCIM = result[i++].Value?.ToString();
            dta.V1CLIE_DTNASCIM_I = string.IsNullOrWhiteSpace(dta.V1CLIE_DTNASCIM) ? "-1" : "0";
            return dta;
        }

    }
}