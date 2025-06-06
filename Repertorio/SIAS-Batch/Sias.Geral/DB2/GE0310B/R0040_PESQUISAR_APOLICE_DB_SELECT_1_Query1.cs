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
    public class R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROD.COD_EMPRESA
            ,PRMG.COD_CGCCPF
            INTO :PRODUTO-COD-EMPRESA
            ,:PARAMGER-COD-CGCCPF
            FROM SEGUROS.APOLICES APOL
            ,SEGUROS.PRODUTO PROD
            ,SEGUROS.PARAMETROS_GERAIS PRMG
            WHERE APOL.NUM_APOLICE = :APOLICES-NUM-APOLICE
            AND APOL.COD_PRODUTO = PROD.COD_PRODUTO
            AND PROD.COD_EMPRESA = PRMG.COD_EMPRESA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROD.COD_EMPRESA
											,PRMG.COD_CGCCPF
											FROM SEGUROS.APOLICES APOL
											,SEGUROS.PRODUTO PROD
											,SEGUROS.PARAMETROS_GERAIS PRMG
											WHERE APOL.NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'
											AND APOL.COD_PRODUTO = PROD.COD_PRODUTO
											AND PROD.COD_EMPRESA = PRMG.COD_EMPRESA";

            return query;
        }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string PARAMGER_COD_CGCCPF { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1 Execute(R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1 r0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PARAMGER_COD_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}