using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1 : QueryBasis<R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO),0)
            INTO :HOST-VALOR-PAGTO-HON-REPASSE
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO O
            WHERE H.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SI111-OCORR-HISTORICO
            AND O.COD_OPERACAO = H.COD_OPERACAO
            AND O.IND_TIPO_FUNCAO = 'RESSA-RECE'
            AND O.COD_OPERACAO IN ( 4101 , 4102 )
            AND O.IDE_SISTEMA = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO O
											WHERE H.NUM_APOL_SINISTRO = '{this.SI111_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SI111_OCORR_HISTORICO}'
											AND O.COD_OPERACAO = H.COD_OPERACAO
											AND O.IND_TIPO_FUNCAO = 'RESSA-RECE'
											AND O.COD_OPERACAO IN ( 4101 
							, 4102 )
											AND O.IDE_SISTEMA = 'SI'";

            return query;
        }
        public string HOST_VALOR_PAGTO_HON_REPASSE { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_OCORR_HISTORICO { get; set; }

        public static R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1 Execute(R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1 r6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1)
        {
            var ths = r6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR_PAGTO_HON_REPASSE = result[i++].Value?.ToString();
            return dta;
        }

    }
}