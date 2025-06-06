using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0130B
{
    public class R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1 : QueryBasis<R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT
            FROM SEGUROS.MOEDAS_COTACAO
            WHERE COD_MOEDA = 23
            AND DATA_INIVIGENCIA = :SISTEMAS-DTTER-COTACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.MOEDAS_COTACAO
											WHERE COD_MOEDA = 23
											AND DATA_INIVIGENCIA = '{this.SISTEMAS_DTTER_COTACAO}'";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string SISTEMAS_DTTER_COTACAO { get; set; }

        public static R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1 Execute(R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1 r0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}