using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1 : QueryBasis<R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_MAX_COBER_BAS
            INTO :BILCOBER-VAL-MAX-COBER-BAS
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE COD_EMPRESA = 999
            AND COD_PRODUTO = :V0CONV-CODPRODU
            AND RAMO_COBERTURA = :V0BILH-RAMO
            AND MODALI_COBERTURA = 0
            AND COD_OPCAO_PLANO = :V0BILH-OPCAO-COB
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_MAX_COBER_BAS
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE COD_EMPRESA = 999
											AND COD_PRODUTO = '{this.V0CONV_CODPRODU}'
											AND RAMO_COBERTURA = '{this.V0BILH_RAMO}'
											AND MODALI_COBERTURA = 0
											AND COD_OPCAO_PLANO = '{this.V0BILH_OPCAO_COB}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string BILCOBER_VAL_MAX_COBER_BAS { get; set; }
        public string V0BILH_OPCAO_COB { get; set; }
        public string V0CONV_CODPRODU { get; set; }
        public string V0BILH_RAMO { get; set; }

        public static R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1 Execute(R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1 r4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1)
        {
            var ths = r4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILCOBER_VAL_MAX_COBER_BAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}