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
    public class R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 : QueryBasis<R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA,
            CGC,
            NOME_FANTASIA,
            COD_USUARIO,
            TIMESTAMP
            INTO :DCLPESSOA-JURIDICA.COD-PESSOA,
            :DCLPESSOA-JURIDICA.CGC,
            :DCLPESSOA-JURIDICA.NOME-FANTASIA,
            :DCLPESSOA-JURIDICA.COD-USUARIO,
            :DCLPESSOA-JURIDICA.TIMESTAMP
            FROM SEGUROS.PESSOA_JURIDICA
            WHERE CGC = :DCLPESSOA-JURIDICA.CGC
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
							,
											CGC
							,
											NOME_FANTASIA
							,
											COD_USUARIO
							,
											TIMESTAMP
											FROM SEGUROS.PESSOA_JURIDICA
											WHERE CGC = '{this.CGC}'
											WITH UR";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string CGC { get; set; }
        public string NOME_FANTASIA { get; set; }
        public string COD_USUARIO { get; set; }
        public string TIMESTAMP { get; set; }

        public static R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 Execute(R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1)
        {
            var ths = r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_PESSOA = result[i++].Value?.ToString();
            dta.CGC = result[i++].Value?.ToString();
            dta.NOME_FANTASIA = result[i++].Value?.ToString();
            dta.COD_USUARIO = result[i++].Value?.ToString();
            dta.TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}