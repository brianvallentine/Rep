using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0310B
{
    public class R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROD.COD_EMPRESA
            ,PRMG.COD_CGCCPF
            INTO :PRODUTO-COD-EMPRESA
            ,:PARAMGER-COD-CGCCPF
            FROM SEGUROS.PRODUTO PROD
            ,SEGUROS.PARAMETROS_GERAIS PRMG
            WHERE PROD.COD_PRODUTO = :PRODUTO-COD-PRODUTO
            AND PROD.COD_EMPRESA = PRMG.COD_EMPRESA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROD.COD_EMPRESA
											,PRMG.COD_CGCCPF
											FROM SEGUROS.PRODUTO PROD
											,SEGUROS.PARAMETROS_GERAIS PRMG
											WHERE PROD.COD_PRODUTO = '{this.PRODUTO_COD_PRODUTO}'
											AND PROD.COD_EMPRESA = PRMG.COD_EMPRESA";

            return query;
        }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string PARAMGER_COD_CGCCPF { get; set; }
        public string PRODUTO_COD_PRODUTO { get; set; }

        public static R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1 Execute(R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1 r0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PARAMGER_COD_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}