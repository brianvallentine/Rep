using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1 : QueryBasis<R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(COD_PESSOA)
            INTO
            :PESSOA-COD-PESSOA
            FROM SEGUROS.PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(COD_PESSOA)
											FROM SEGUROS.PESSOA";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }

        public static R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1 Execute(R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1 r1820_00_INSERT_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = r1820_00_INSERT_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOA_COD_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}