using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0132B
{
    public class R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1 : QueryBasis<R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT
            STA_CARENCIA
            INTO :WS-STA-CARENCIA
            FROM SEGUROS.VA_CAMPANHA_CARENCIA
            WHERE NUM_CPF_CNPJ = :VA111-NUM-CPF-CNPJ
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DISTINCT
											STA_CARENCIA
											FROM SEGUROS.VA_CAMPANHA_CARENCIA
											WHERE NUM_CPF_CNPJ = '{this.VA111_NUM_CPF_CNPJ}'";

            return query;
        }
        public string WS_STA_CARENCIA { get; set; }
        public string VA111_NUM_CPF_CNPJ { get; set; }

        public static R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1 Execute(R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1 r2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1)
        {
            var ths = r2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2211_00_VERIFICA_SITUACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_STA_CARENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}