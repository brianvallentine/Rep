using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG5705B
{
    public class M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1 : QueryBasis<M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_CLIENTE,
            DATA_NASCIMENTO
            INTO :V1SEGV-CODCLI,
            :V1SEGV-DTNASCIM
            :V1SEGV-DTNASCIM-I
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :SQL-NUM-CERT
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_CLIENTE
							,
											DATA_NASCIMENTO
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.SQL_NUM_CERT}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string V1SEGV_CODCLI { get; set; }
        public string V1SEGV_DTNASCIM { get; set; }
        public string V1SEGV_DTNASCIM_I { get; set; }
        public string SQL_NUM_CERT { get; set; }

        public static M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1 Execute(M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1 m_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1)
        {
            var ths = m_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SEGV_CODCLI = result[i++].Value?.ToString();
            dta.V1SEGV_DTNASCIM = result[i++].Value?.ToString();
            dta.V1SEGV_DTNASCIM_I = string.IsNullOrWhiteSpace(dta.V1SEGV_DTNASCIM) ? "-1" : "0";
            return dta;
        }

    }
}