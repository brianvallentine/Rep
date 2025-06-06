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
    public class R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1 : QueryBasis<R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT EMAIL
            , SITUACAO_EMAIL
            INTO :DCLPESSOA-EMAIL.EMAIL
            , :DCLPESSOA-EMAIL.SITUACAO-EMAIL
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA
            AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT EMAIL
											, SITUACAO_EMAIL
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA = '{this.COD_PESSOA}'
											AND SEQ_EMAIL = '{this.SEQ_EMAIL}'
											WITH UR";

            return query;
        }
        public string EMAIL { get; set; }
        public string SITUACAO_EMAIL { get; set; }
        public string COD_PESSOA { get; set; }
        public string SEQ_EMAIL { get; set; }

        public static R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1 Execute(R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1 r2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1)
        {
            var ths = r2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1();
            var i = 0;
            dta.EMAIL = result[i++].Value?.ToString();
            dta.SITUACAO_EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}