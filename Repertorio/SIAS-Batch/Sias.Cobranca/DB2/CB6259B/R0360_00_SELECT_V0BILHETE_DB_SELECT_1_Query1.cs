using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6259B
{
    public class R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_PRODUTO
            INTO :BILHECOB-COD-PRODUTO
            FROM SEGUROS.BILHETE A
            ,SEGUROS.BILHETE_PLANCOBER B
            WHERE A.NUM_BILHETE = :CONVERSI-NUM-SICOB
            AND B.COD_EMPRESA = 0
            AND B.RAMO_COBERTURA = A.RAMO
            AND B.COD_OPCAO_PLANO = A.OPC_COBERTURA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.COD_PRODUTO
											FROM SEGUROS.BILHETE A
											,SEGUROS.BILHETE_PLANCOBER B
											WHERE A.NUM_BILHETE = '{this.CONVERSI_NUM_SICOB}'
											AND B.COD_EMPRESA = 0
											AND B.RAMO_COBERTURA = A.RAMO
											AND B.COD_OPCAO_PLANO = A.OPC_COBERTURA
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string BILHECOB_COD_PRODUTO { get; set; }
        public string CONVERSI_NUM_SICOB { get; set; }

        public static R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 Execute(R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 r0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHECOB_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}