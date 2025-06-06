using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 : QueryBasis<R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_EMAIL),0)
            INTO :DCLPESSOA-EMAIL.SEQ-EMAIL
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_EMAIL)
							,0)
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA = '{this.COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string SEQ_EMAIL { get; set; }
        public string COD_PESSOA { get; set; }

        public static R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 Execute(R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1)
        {
            var ths = r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEQ_EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}