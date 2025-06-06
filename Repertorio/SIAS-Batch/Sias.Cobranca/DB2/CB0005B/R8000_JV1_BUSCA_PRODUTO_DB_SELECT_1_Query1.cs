using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PD.COD_EMPRESA
            ,PD.RAMO_EMISSOR
            ,PG.COD_EMPRESA_CAP
            INTO :PRODUTO-COD-EMPRESA
            ,:PRODUTO-RAMO-EMISSOR
            ,:PARAMGER-COD-EMPRESA-CAP
            FROM SEGUROS.PRODUTO PD,
            SEGUROS.PARAMETROS_GERAIS PG
            WHERE PD.COD_PRODUTO = :PRODUTO-COD-PRODUTO
            AND PD.COD_EMPRESA = PG.COD_EMPRESA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PD.COD_EMPRESA
											,PD.RAMO_EMISSOR
											,PG.COD_EMPRESA_CAP
											FROM SEGUROS.PRODUTO PD
							,
											SEGUROS.PARAMETROS_GERAIS PG
											WHERE PD.COD_PRODUTO = '{this.PRODUTO_COD_PRODUTO}'
											AND PD.COD_EMPRESA = PG.COD_EMPRESA
											WITH UR";

            return query;
        }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string PRODUTO_RAMO_EMISSOR { get; set; }
        public string PARAMGER_COD_EMPRESA_CAP { get; set; }
        public string PRODUTO_COD_PRODUTO { get; set; }

        public static R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1 Execute(R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1 r8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8000_JV1_BUSCA_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PRODUTO_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.PARAMGER_COD_EMPRESA_CAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}