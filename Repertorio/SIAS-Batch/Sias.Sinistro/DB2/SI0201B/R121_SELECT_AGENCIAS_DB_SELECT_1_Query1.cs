using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0201B
{
    public class R121_SELECT_AGENCIAS_DB_SELECT_1_Query1 : QueryBasis<R121_SELECT_AGENCIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CIDADE,
            UF
            INTO :UNIDACEF-CIDADE,
            :UNIDACEF-UF
            FROM SEGUROS.UNIDADE_CEF
            WHERE COD_UNIDADE = :SINCREIN-COD-AGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CIDADE
							,
											UF
											FROM SEGUROS.UNIDADE_CEF
											WHERE COD_UNIDADE = '{this.SINCREIN_COD_AGENCIA}'
											WITH UR";

            return query;
        }
        public string UNIDACEF_CIDADE { get; set; }
        public string UNIDACEF_UF { get; set; }
        public string SINCREIN_COD_AGENCIA { get; set; }

        public static R121_SELECT_AGENCIAS_DB_SELECT_1_Query1 Execute(R121_SELECT_AGENCIAS_DB_SELECT_1_Query1 r121_SELECT_AGENCIAS_DB_SELECT_1_Query1)
        {
            var ths = r121_SELECT_AGENCIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R121_SELECT_AGENCIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R121_SELECT_AGENCIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.UNIDACEF_CIDADE = result[i++].Value?.ToString();
            dta.UNIDACEF_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}