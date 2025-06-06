using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0641B
{
    public class R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 : QueryBasis<R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA,
            SEQ_EMAIL,
            EMAIL,
            SITUACAO_EMAIL,
            COD_USUARIO,
            TIMESTAMP
            INTO :DCLPESSOA-EMAIL.COD-PESSOA,
            :DCLPESSOA-EMAIL.SEQ-EMAIL,
            :DCLPESSOA-EMAIL.EMAIL,
            :DCLPESSOA-EMAIL.SITUACAO-EMAIL,
            :DCLPESSOA-EMAIL.COD-USUARIO,
            :DCLPESSOA-EMAIL.TIMESTAMP
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA
            AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
							,
											SEQ_EMAIL
							,
											EMAIL
							,
											SITUACAO_EMAIL
							,
											COD_USUARIO
							,
											TIMESTAMP
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA = '{this.COD_PESSOA}'
											AND SEQ_EMAIL = '{this.SEQ_EMAIL}'
											WITH UR";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string SEQ_EMAIL { get; set; }
        public string EMAIL { get; set; }
        public string SITUACAO_EMAIL { get; set; }
        public string COD_USUARIO { get; set; }
        public string TIMESTAMP { get; set; }

        public static R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 Execute(R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 r0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1)
        {
            var ths = r0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_PESSOA = result[i++].Value?.ToString();
            dta.SEQ_EMAIL = result[i++].Value?.ToString();
            dta.EMAIL = result[i++].Value?.ToString();
            dta.SITUACAO_EMAIL = result[i++].Value?.ToString();
            dta.COD_USUARIO = result[i++].Value?.ToString();
            dta.TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}