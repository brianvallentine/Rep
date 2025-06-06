using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0506B
{
    public class R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO ,
            VALOR_COMISSAO_PRD ,
            PERCEN_COMIS_FUNC
            INTO :PARAMPRO-COD-PRODUTO ,
            :PARAMPRO-VALOR-COMISSAO-PRD ,
            :PARAMPRO-PERCEN-COMIS-FUNC
            FROM SEGUROS.PARAM_PRODUTO
            WHERE COD_PRODUTO = :PARAMPRO-COD-PRODUTO
            AND TIPO_FUNCIONARIO = :PARAMPRO-TIPO-FUNCIONARIO
            AND DATA_INIVIGENCIA <= :PARAMPRO-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :PARAMPRO-DATA-INIVIGENCIA
            AND MARGEM = :PARAMPRO-MARGEM
            AND STA_RENOVACAO = :PARAMPRO-STA-RENOVACAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO 
							,
											VALOR_COMISSAO_PRD 
							,
											PERCEN_COMIS_FUNC
											FROM SEGUROS.PARAM_PRODUTO
											WHERE COD_PRODUTO = '{this.PARAMPRO_COD_PRODUTO}'
											AND TIPO_FUNCIONARIO = '{this.PARAMPRO_TIPO_FUNCIONARIO}'
											AND DATA_INIVIGENCIA <= '{this.PARAMPRO_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.PARAMPRO_DATA_INIVIGENCIA}'
											AND MARGEM = '{this.PARAMPRO_MARGEM}'
											AND STA_RENOVACAO = '{this.PARAMPRO_STA_RENOVACAO}'
											WITH UR";

            return query;
        }
        public string PARAMPRO_COD_PRODUTO { get; set; }
        public string PARAMPRO_VALOR_COMISSAO_PRD { get; set; }
        public string PARAMPRO_PERCEN_COMIS_FUNC { get; set; }
        public string PARAMPRO_TIPO_FUNCIONARIO { get; set; }
        public string PARAMPRO_DATA_INIVIGENCIA { get; set; }
        public string PARAMPRO_STA_RENOVACAO { get; set; }
        public string PARAMPRO_MARGEM { get; set; }

        public static R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1 Execute(R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1 r0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMPRO_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PARAMPRO_VALOR_COMISSAO_PRD = result[i++].Value?.ToString();
            dta.PARAMPRO_PERCEN_COMIS_FUNC = result[i++].Value?.ToString();
            return dta;
        }

    }
}