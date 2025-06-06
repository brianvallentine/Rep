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
    public class R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1 : QueryBasis<R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR),+0)
            INTO :PENDENTE-COSSEG
            FROM SEGUROS.COSSEGURO_HIST_SIN A,
            SEGUROS.GE_SIS_FUNCAO_OPER B
            WHERE A.NUM_SINISTRO = :COSHISSI-NUM-SINISTRO
            AND A.COD_CONGENERE = :COSHISSI-COD-CONGENERE
            AND A.DATA_MOVIMENTO BETWEEN :DATA-TAPA-TEC
            AND :SISTEMAS-DATA-MOV-ABERTO
            AND B.COD_OPERACAO = A.COD_OPERACAO
            AND B.COD_FUNCAO = :GESISFUO-COD-FUNCAO
            AND B.IDE_SISTEMA = 'SI'
            AND B.IDE_SISTEMA_OPER = 'SI'
            AND A.TIPO_SEGURO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR)
							,+0)
											FROM SEGUROS.COSSEGURO_HIST_SIN A
							,
											SEGUROS.GE_SIS_FUNCAO_OPER B
											WHERE A.NUM_SINISTRO = '{this.COSHISSI_NUM_SINISTRO}'
											AND A.COD_CONGENERE = '{this.COSHISSI_COD_CONGENERE}'
											AND A.DATA_MOVIMENTO BETWEEN '{this.DATA_TAPA_TEC}'
											AND '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND B.COD_OPERACAO = A.COD_OPERACAO
											AND B.COD_FUNCAO = '{this.GESISFUO_COD_FUNCAO}'
											AND B.IDE_SISTEMA = 'SI'
											AND B.IDE_SISTEMA_OPER = 'SI'
											AND A.TIPO_SEGURO = '1'";

            return query;
        }
        public string PENDENTE_COSSEG { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string COSHISSI_COD_CONGENERE { get; set; }
        public string COSHISSI_NUM_SINISTRO { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string DATA_TAPA_TEC { get; set; }

        public static R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1 Execute(R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1 r1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1();
            var i = 0;
            dta.PENDENTE_COSSEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}