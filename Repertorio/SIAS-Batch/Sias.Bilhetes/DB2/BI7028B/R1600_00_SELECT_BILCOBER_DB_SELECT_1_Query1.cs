using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_MAX_COBER_BAS
            INTO :BILCOBER-VAL-MAX-COBER-BAS
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE COD_EMPRESA = 9999
            AND COD_PRODUTO = :BILCOBER-COD-PRODUTO
            AND RAMO_COBERTURA = :BILCOBER-RAMO-COBERTURA
            AND MODALI_COBERTURA = 0
            AND COD_OPCAO_PLANO = :BILCOBER-COD-OPCAO-PLANO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VAL_MAX_COBER_BAS
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE COD_EMPRESA = 9999
											AND COD_PRODUTO = '{this.BILCOBER_COD_PRODUTO}'
											AND RAMO_COBERTURA = '{this.BILCOBER_RAMO_COBERTURA}'
											AND MODALI_COBERTURA = 0
											AND COD_OPCAO_PLANO = '{this.BILCOBER_COD_OPCAO_PLANO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string BILCOBER_VAL_MAX_COBER_BAS { get; set; }
        public string BILCOBER_COD_OPCAO_PLANO { get; set; }
        public string BILCOBER_RAMO_COBERTURA { get; set; }
        public string BILCOBER_COD_PRODUTO { get; set; }

        public static R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1 r1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_BILCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILCOBER_VAL_MAX_COBER_BAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}