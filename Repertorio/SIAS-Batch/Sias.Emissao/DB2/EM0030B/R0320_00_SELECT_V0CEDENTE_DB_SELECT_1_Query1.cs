using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 : QueryBasis<R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CEDENTE
            ,OPERACAO_CONTA
            ,NUM_TITULO
            INTO :CEDENTE-COD-CEDENTE
            ,:CEDENTE-OPERACAO-CONTA
            ,:CEDENTE-NUM-TITULO
            FROM SEGUROS.CEDENTE
            WHERE COD_CEDENTE = :CEDENTE-COD-CEDENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CEDENTE
											,OPERACAO_CONTA
											,NUM_TITULO
											FROM SEGUROS.CEDENTE
											WHERE COD_CEDENTE = '{this.CEDENTE_COD_CEDENTE}'
											WITH UR";

            return query;
        }
        public string CEDENTE_COD_CEDENTE { get; set; }
        public string CEDENTE_OPERACAO_CONTA { get; set; }
        public string CEDENTE_NUM_TITULO { get; set; }

        public static R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 Execute(R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 r0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1)
        {
            var ths = r0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CEDENTE_COD_CEDENTE = result[i++].Value?.ToString();
            dta.CEDENTE_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.CEDENTE_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}