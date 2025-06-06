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
    public class R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1 : QueryBasis<R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA,
            NOME_PESSOA,
            TIPO_PESSOA,
            TIMESTAMP,
            COD_USUARIO
            INTO :DCLPESSOA.PESSOA-COD-PESSOA,
            :DCLPESSOA.PESSOA-NOME-PESSOA,
            :DCLPESSOA.PESSOA-TIPO-PESSOA,
            :DCLPESSOA.PESSOA-TIMESTAMP,
            :DCLPESSOA.PESSOA-COD-USUARIO
            FROM SEGUROS.PESSOA
            WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
							,
											NOME_PESSOA
							,
											TIPO_PESSOA
							,
											TIMESTAMP
							,
											COD_USUARIO
											FROM SEGUROS.PESSOA
											WHERE COD_PESSOA = '{this.PESSOA_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string PESSOA_NOME_PESSOA { get; set; }
        public string PESSOA_TIPO_PESSOA { get; set; }
        public string PESSOA_TIMESTAMP { get; set; }
        public string PESSOA_COD_USUARIO { get; set; }

        public static R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1 Execute(R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1 r0555_LER_TAB_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = r0555_LER_TAB_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOA_COD_PESSOA = result[i++].Value?.ToString();
            dta.PESSOA_NOME_PESSOA = result[i++].Value?.ToString();
            dta.PESSOA_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.PESSOA_TIMESTAMP = result[i++].Value?.ToString();
            dta.PESSOA_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}