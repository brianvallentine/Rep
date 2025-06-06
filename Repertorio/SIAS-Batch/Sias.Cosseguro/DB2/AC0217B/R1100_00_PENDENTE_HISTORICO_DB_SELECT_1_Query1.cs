using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0217B
{
    public class R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR),+0)
            INTO :PENDENTE-SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO A,
            SEGUROS.GE_SIS_FUNCAO_OPER B
            WHERE A.NUM_APOL_SINISTRO = :COSHISSI-NUM-SINISTRO
            AND A.DATA_MOVIMENTO BETWEEN '1993-01-01'
            AND :SISTEMAS-DATA-MOV-ABERTO
            AND B.COD_OPERACAO = A.COD_OPERACAO
            AND B.COD_FUNCAO = :GESISFUO-COD-FUNCAO
            AND B.IDE_SISTEMA = 'SI'
            AND B.IDE_SISTEMA_OPER = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR)
							,+0)
											FROM SEGUROS.SINISTRO_HISTORICO A
							,
											SEGUROS.GE_SIS_FUNCAO_OPER B
											WHERE A.NUM_APOL_SINISTRO = '{this.COSHISSI_NUM_SINISTRO}'
											AND A.DATA_MOVIMENTO BETWEEN '1993-01-01'
											AND '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND B.COD_OPERACAO = A.COD_OPERACAO
											AND B.COD_FUNCAO = '{this.GESISFUO_COD_FUNCAO}'
											AND B.IDE_SISTEMA = 'SI'
											AND B.IDE_SISTEMA_OPER = 'SI'";

            return query;
        }
        public string PENDENTE_SINISTRO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string COSHISSI_NUM_SINISTRO { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }

        public static R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1 Execute(R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1 r1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PENDENTE_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}