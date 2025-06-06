using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0078B
{
    public class M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1 : QueryBasis<M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCAU
            INTO :V0CAUSA-DESCAU
            FROM SEGUROS.V0SINICAUSA
            WHERE RAMO = :SINI-RAMO
            AND CODCAU = :SINI-CODCAU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCAU
											FROM SEGUROS.V0SINICAUSA
											WHERE RAMO = '{this.SINI_RAMO}'
											AND CODCAU = '{this.SINI_CODCAU}'";

            return query;
        }
        public string V0CAUSA_DESCAU { get; set; }
        public string SINI_CODCAU { get; set; }
        public string SINI_RAMO { get; set; }

        public static M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1 Execute(M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1 m_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1)
        {
            var ths = m_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_500_IMPRIME_DADOS_GERAIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CAUSA_DESCAU = result[i++].Value?.ToString();
            return dta;
        }

    }
}