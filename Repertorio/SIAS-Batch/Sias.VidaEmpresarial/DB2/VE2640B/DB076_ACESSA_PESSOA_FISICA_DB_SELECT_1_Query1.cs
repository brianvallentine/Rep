using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1 : QueryBasis<DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA
            INTO :PESSOFIS-COD-PESSOA
            FROM SEGUROS.PESSOA_FISICA
            WHERE CPF = :PESSOFIS-CPF
            ORDER BY TIMESTAMP DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
											FROM SEGUROS.PESSOA_FISICA
											WHERE CPF = '{this.PESSOFIS_CPF}'
											ORDER BY TIMESTAMP DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string PESSOFIS_COD_PESSOA { get; set; }
        public string PESSOFIS_CPF { get; set; }

        public static DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1 Execute(DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1 dB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1)
        {
            var ths = dB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOFIS_COD_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}