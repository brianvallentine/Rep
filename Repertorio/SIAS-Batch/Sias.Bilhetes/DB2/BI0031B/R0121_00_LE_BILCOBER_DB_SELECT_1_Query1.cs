using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class R0121_00_LE_BILCOBER_DB_SELECT_1_Query1 : QueryBasis<R0121_00_LE_BILCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :BILCOBER-COD-PRODUTO
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE COD_OPCAO_PLANO = :V1BILH-OPC-COBER
            AND RAMO_COBERTURA = :V1BILH-RAMO
            AND DATA_TERVIGENCIA = '9999-12-31'
            FETCH FIRST 1 ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE COD_OPCAO_PLANO = '{this.V1BILH_OPC_COBER}'
											AND RAMO_COBERTURA = '{this.V1BILH_RAMO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											FETCH FIRST 1 ROWS ONLY";

            return query;
        }
        public string BILCOBER_COD_PRODUTO { get; set; }
        public string V1BILH_OPC_COBER { get; set; }
        public string V1BILH_RAMO { get; set; }

        public static R0121_00_LE_BILCOBER_DB_SELECT_1_Query1 Execute(R0121_00_LE_BILCOBER_DB_SELECT_1_Query1 r0121_00_LE_BILCOBER_DB_SELECT_1_Query1)
        {
            var ths = r0121_00_LE_BILCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0121_00_LE_BILCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0121_00_LE_BILCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILCOBER_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}