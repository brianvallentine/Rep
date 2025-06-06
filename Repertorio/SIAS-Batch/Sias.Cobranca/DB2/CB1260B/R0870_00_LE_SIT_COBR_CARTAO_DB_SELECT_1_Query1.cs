using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1 : QueryBasis<R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :MOVIMCOB-SIT-REGISTRO
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCELAS-NUM-PARCELA
            AND SIT_REGISTRO = '*'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCELAS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCELAS_NUM_PARCELA}'
											AND SIT_REGISTRO = '*'
											WITH UR";

            return query;
        }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }

        public static R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1 Execute(R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1 r0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1)
        {
            var ths = r0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMCOB_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}