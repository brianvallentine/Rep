using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0502S
{
    public class R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1 : QueryBasis<R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR), 0)
            INTO :HOST-VAL-PENDENTE
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_SIS_FUNCAO_OPER O
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO
            AND O.IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA
            AND O.COD_FUNCAO = :GESISFUO-COD-FUNCAO
            AND O.IDE_SISTEMA = O.IDE_SISTEMA_OPER
            AND O.COD_OPERACAO = H.COD_OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_SIS_FUNCAO_OPER O
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.DATA_MOVIMENTO <= '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND O.IDE_SISTEMA = '{this.SISTEMAS_IDE_SISTEMA}'
											AND O.COD_FUNCAO = '{this.GESISFUO_COD_FUNCAO}'
											AND O.IDE_SISTEMA = O.IDE_SISTEMA_OPER
											AND O.COD_OPERACAO = H.COD_OPERACAO";

            return query;
        }
        public string HOST_VAL_PENDENTE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SISTEMAS_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }

        public static R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1 Execute(R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1 r1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1)
        {
            var ths = r1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VAL_PENDENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}