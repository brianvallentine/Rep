using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1 : QueryBasis<R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_EMPRESA
            ,A.RAMO_EMISSOR
            ,B.COD_EMPRESA_CAP
            INTO :PRODUTO-COD-EMPRESA
            ,:PRODUTO-RAMO-EMISSOR
            ,:PARAMGER-COD-EMPRESA-CAP
            FROM SEGUROS.PRODUTO A
            ,SEGUROS.PARAMETROS_GERAIS B
            WHERE A.COD_PRODUTO = :PRODUTO-COD-PRODUTO
            AND B.COD_EMPRESA = A.COD_EMPRESA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_EMPRESA
											,A.RAMO_EMISSOR
											,B.COD_EMPRESA_CAP
											FROM SEGUROS.PRODUTO A
											,SEGUROS.PARAMETROS_GERAIS B
											WHERE A.COD_PRODUTO = '{this.PRODUTO_COD_PRODUTO}'
											AND B.COD_EMPRESA = A.COD_EMPRESA
											WITH UR";

            return query;
        }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string PRODUTO_RAMO_EMISSOR { get; set; }
        public string PARAMGER_COD_EMPRESA_CAP { get; set; }
        public string PRODUTO_COD_PRODUTO { get; set; }

        public static R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1 Execute(R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1 r7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1)
        {
            var ths = r7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7000_JV1_BUSCA_EMPRESA_RAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PRODUTO_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.PARAMGER_COD_EMPRESA_CAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}