using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1 : QueryBasis<P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IFNULL(SUM(PRM_TOTAL),0)
            INTO :WS-VL-PAGAMENTO
            FROM SEGUROS.PARCELA_HISTORICO
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND
            (
            ( COD_OPERACAO BETWEEN 200 AND 299 ) AND
            (
            (NUM_ENDOSSO = 0) OR
            (NUM_ENDOSSO BETWEEN 800000 AND 899999)
            )
            )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IFNULL(SUM(PRM_TOTAL)
							,0)
											FROM SEGUROS.PARCELA_HISTORICO
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND
											(
											( COD_OPERACAO BETWEEN 200 AND 299 ) AND
											(
											(NUM_ENDOSSO = 0) OR
											(NUM_ENDOSSO BETWEEN 800000 AND 899999)
											)
											)
											WITH UR";

            return query;
        }
        public string WS_VL_PAGAMENTO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }

        public static P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1 Execute(P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1 p2113_00_CALCULA_VALORES_DB_SELECT_2_Query1)
        {
            var ths = p2113_00_CALCULA_VALORES_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_VL_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}