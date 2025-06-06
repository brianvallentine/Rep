using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R2810_00_SEL_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R2810_00_SEL_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(COD_PRODUTO)
            INTO :WHOST-CODPRODU
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE COD_EMPRESA = 0
            AND MODALI_COBERTURA = 0
            AND RAMO_COBERTURA = 81
            AND DATA_TERVIGENCIA = '9999-12-31'
            AND COD_PRODUTO NOT IN (8105)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(COD_PRODUTO)
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE COD_EMPRESA = 0
											AND MODALI_COBERTURA = 0
											AND RAMO_COBERTURA = 81
											AND DATA_TERVIGENCIA = '9999-12-31'
											AND COD_PRODUTO NOT IN (8105)
											WITH UR";

            return query;
        }
        public string WHOST_CODPRODU { get; set; }

        public static R2810_00_SEL_PRODUTO_DB_SELECT_1_Query1 Execute(R2810_00_SEL_PRODUTO_DB_SELECT_1_Query1 r2810_00_SEL_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r2810_00_SEL_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2810_00_SEL_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2810_00_SEL_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}