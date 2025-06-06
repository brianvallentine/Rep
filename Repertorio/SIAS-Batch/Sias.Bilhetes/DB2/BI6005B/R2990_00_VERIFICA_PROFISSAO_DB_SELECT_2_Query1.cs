using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1 : QueryBasis<R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CBO
            INTO :PESSOA-FISICA-COD-CBO
            FROM SEGUROS.PESSOA_FISICA
            WHERE COD_PESSOA = :PRPFIDEL-COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CBO
											FROM SEGUROS.PESSOA_FISICA
											WHERE COD_PESSOA = '{this.PRPFIDEL_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string PESSOA_FISICA_COD_CBO { get; set; }
        public string PRPFIDEL_COD_PESSOA { get; set; }

        public static R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1 Execute(R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1 r2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1)
        {
            var ths = r2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2_Query1();
            var i = 0;
            dta.PESSOA_FISICA_COD_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}