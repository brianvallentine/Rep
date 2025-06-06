using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0125B
{
    public class R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1 : QueryBasis<R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT EMAIL
            INTO :PESSOEMA-EMAIL
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA = :DCLPESSOA-JURIDICA.COD-PESSOA
            AND SITUACAO_EMAIL = 'A'
            AND SEQ_EMAIL = :PESSOEMA-SEQ-EMAIL
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT EMAIL
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA = '{this.COD_PESSOA}'
											AND SITUACAO_EMAIL = 'A'
											AND SEQ_EMAIL = '{this.PESSOEMA_SEQ_EMAIL}'";

            return query;
        }
        public string PESSOEMA_EMAIL { get; set; }
        public string COD_PESSOA { get; set; }
        public string PESSOEMA_SEQ_EMAIL { get; set; }

        public static R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1 Execute(R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1 r0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1)
        {
            var ths = r0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1();
            var i = 0;
            dta.PESSOEMA_EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}