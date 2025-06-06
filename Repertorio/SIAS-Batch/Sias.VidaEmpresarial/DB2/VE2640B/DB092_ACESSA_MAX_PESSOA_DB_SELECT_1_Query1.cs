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
    public class DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1 : QueryBasis<DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(COD_PESSOA),0)
            INTO :PESSOA-COD-PESSOA
            FROM SEGUROS.PESSOA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(COD_PESSOA)
							,0)
											FROM SEGUROS.PESSOA";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }

        public static DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1 Execute(DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1 dB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = dB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB092_ACESSA_MAX_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOA_COD_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}