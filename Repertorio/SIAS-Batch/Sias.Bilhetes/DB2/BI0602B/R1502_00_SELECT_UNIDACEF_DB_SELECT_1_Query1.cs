using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0602B
{
    public class R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1 : QueryBasis<R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NOME_UNIDADE
            INTO
            :UNIDACEF-NOME-UNIDADE
            FROM SEGUROS.UNIDADE_CEF
            WHERE COD_UNIDADE = :UNIDACEF-COD-UNIDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOME_UNIDADE
											FROM SEGUROS.UNIDADE_CEF
											WHERE COD_UNIDADE = '{this.UNIDACEF_COD_UNIDADE}'";

            return query;
        }
        public string UNIDACEF_NOME_UNIDADE { get; set; }
        public string UNIDACEF_COD_UNIDADE { get; set; }

        public static R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1 Execute(R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1 r1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1)
        {
            var ths = r1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.UNIDACEF_NOME_UNIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}