using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1 : QueryBasis<B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NRORDEM
            INTO :NUME-NRORDEM
            FROM SEGUROS.V1NUMERO_COSSEGURO
            WHERE ORGAO = :ENDO-ORGAO
            AND CONGENER = :COSS-CODCOSS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NRORDEM
											FROM SEGUROS.V1NUMERO_COSSEGURO
											WHERE ORGAO = '{this.ENDO_ORGAO}'
											AND CONGENER = '{this.COSS_CODCOSS}'
											WITH UR";

            return query;
        }
        public string NUME_NRORDEM { get; set; }
        public string COSS_CODCOSS { get; set; }
        public string ENDO_ORGAO { get; set; }

        public static B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1 Execute(B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1 b1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1)
        {
            var ths = b1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUME_NRORDEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}