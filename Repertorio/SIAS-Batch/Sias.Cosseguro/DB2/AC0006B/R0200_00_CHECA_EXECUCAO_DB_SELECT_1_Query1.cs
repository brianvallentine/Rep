using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0006B
{
    public class R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 : QueryBasis<R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(COUNT(*),+0)
            INTO :WHOST-QTDE-REG
            FROM SEGUROS.COSSEGURO_HIST_PRE A,
            SEGUROS.APOLICES B
            WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO
            AND A.TIPO_SEGURO = '1'
            AND A.COD_OPERACAO < 0600
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.TIPO_SEGURO = A.TIPO_SEGURO
            AND B.ORGAO_EMISSOR IN (0010,0300)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.COSSEGURO_HIST_PRE A
							,
											SEGUROS.APOLICES B
											WHERE A.DATA_MOVIMENTO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND A.TIPO_SEGURO = '1'
											AND A.COD_OPERACAO < 0600
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.TIPO_SEGURO = A.TIPO_SEGURO
											AND B.ORGAO_EMISSOR IN (0010
							,0300)";

            return query;
        }
        public string WHOST_QTDE_REG { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 Execute(R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDE_REG = result[i++].Value?.ToString();
            return dta;
        }

    }
}