using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_PESSOA
            INTO :DCLPESSOA.PESSOA-NOME-PESSOA
            FROM SEGUROS.PESSOA
            WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_PESSOA
											FROM SEGUROS.PESSOA
											WHERE COD_PESSOA = '{this.COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string PESSOA_NOME_PESSOA { get; set; }
        public string COD_PESSOA { get; set; }

        public static R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1 r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOA_NOME_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}