using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI5166B
{
    public class R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1 : QueryBasis<R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :BILHECOB-COD-PRODUTO
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE RAMO_COBERTURA = :BILHETE-RAMO
            AND COD_OPCAO_PLANO = :BILHETE-OPC-COBERTURA
            AND DATA_INIVIGENCIA <= :BILHETE-DATA-QUITACAO
            AND DATA_TERVIGENCIA >= :BILHETE-DATA-QUITACAO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE RAMO_COBERTURA = '{this.BILHETE_RAMO}'
											AND COD_OPCAO_PLANO = '{this.BILHETE_OPC_COBERTURA}'
											AND DATA_INIVIGENCIA <= '{this.BILHETE_DATA_QUITACAO}'
											AND DATA_TERVIGENCIA >= '{this.BILHETE_DATA_QUITACAO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string BILHECOB_COD_PRODUTO { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_RAMO { get; set; }

        public static R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1 Execute(R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1 r0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_SELECT_BILHECOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHECOB_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}