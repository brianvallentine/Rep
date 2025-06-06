using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1466B
{
    public class R3250_00_VERIFICA_PEP_DB_SELECT_1_Query1 : QueryBasis<R3250_00_VERIFICA_PEP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT 'S'
            INTO :WS-CLIENTE-PEP
            FROM SEGUROS.GE_PESSOA_PEPS GE637
            WHERE GE637.NUM_CPF_CNPJ = :GE637-NUM-CPF-CNPJ
            AND GE637.DTA_FIM_VIG IS NULL
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT 'S'
											FROM SEGUROS.GE_PESSOA_PEPS GE637
											WHERE GE637.NUM_CPF_CNPJ = '{this.GE637_NUM_CPF_CNPJ}'
											AND GE637.DTA_FIM_VIG IS NULL
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WS_CLIENTE_PEP { get; set; }
        public string GE637_NUM_CPF_CNPJ { get; set; }

        public static R3250_00_VERIFICA_PEP_DB_SELECT_1_Query1 Execute(R3250_00_VERIFICA_PEP_DB_SELECT_1_Query1 r3250_00_VERIFICA_PEP_DB_SELECT_1_Query1)
        {
            var ths = r3250_00_VERIFICA_PEP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3250_00_VERIFICA_PEP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3250_00_VERIFICA_PEP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CLIENTE_PEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}