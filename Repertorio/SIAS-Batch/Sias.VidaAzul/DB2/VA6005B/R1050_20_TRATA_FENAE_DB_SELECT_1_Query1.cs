using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R1050_20_TRATA_FENAE_DB_SELECT_1_Query1 : QueryBasis<R1050_20_TRATA_FENAE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALOR_COMISSAO_PRD
            INTO :PARAMPRO-VALOR-COMISSAO-PRD
            FROM SEGUROS.PARAM_PRODUTO
            WHERE COD_PRODUTO = :V0ENDO-CODPRODU
            AND TIPO_FUNCIONARIO = '8'
            AND :V1SIST-DTMOVABE BETWEEN DATA_INIVIGENCIA
            AND DATA_TERVIGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALOR_COMISSAO_PRD
											FROM SEGUROS.PARAM_PRODUTO
											WHERE COD_PRODUTO = '{this.V0ENDO_CODPRODU}'
											AND TIPO_FUNCIONARIO = '8'
											AND '{this.V1SIST_DTMOVABE}' BETWEEN DATA_INIVIGENCIA
											AND DATA_TERVIGENCIA";

            return query;
        }
        public string PARAMPRO_VALOR_COMISSAO_PRD { get; set; }
        public string V0ENDO_CODPRODU { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R1050_20_TRATA_FENAE_DB_SELECT_1_Query1 Execute(R1050_20_TRATA_FENAE_DB_SELECT_1_Query1 r1050_20_TRATA_FENAE_DB_SELECT_1_Query1)
        {
            var ths = r1050_20_TRATA_FENAE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_20_TRATA_FENAE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_20_TRATA_FENAE_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMPRO_VALOR_COMISSAO_PRD = result[i++].Value?.ToString();
            return dta;
        }

    }
}