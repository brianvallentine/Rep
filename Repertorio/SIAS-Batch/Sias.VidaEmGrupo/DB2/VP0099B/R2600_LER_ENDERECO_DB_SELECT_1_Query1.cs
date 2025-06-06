using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class R2600_LER_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R2600_LER_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO,
            VALUE(COMPL_ENDER, ' ' ),
            RTRIM(CIDADE) || '/' || SIGLA_UF,
            VALUE(BAIRRO, ' ' ),
            CEP
            INTO :PESSOEND-ENDERECO,
            :PESSOEND-COMPL-ENDER,
            :PESSOEND-CIDADE,
            :PESSOEND-BAIRRO,
            :PESSOEND-CEP
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :PESSOEND-COD-PESSOA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT ENDERECO
							,
											VALUE(COMPL_ENDER
							, ' ' )
							,
											RTRIM(CIDADE) || '/' || SIGLA_UF
							,
											VALUE(BAIRRO
							, ' ' )
							,
											CEP
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA = '{this.PESSOEND_COD_PESSOA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PESSOEND_ENDERECO { get; set; }
        public string PESSOEND_COMPL_ENDER { get; set; }
        public string PESSOEND_CIDADE { get; set; }
        public string PESSOEND_BAIRRO { get; set; }
        public string PESSOEND_CEP { get; set; }
        public string PESSOEND_COD_PESSOA { get; set; }

        public static R2600_LER_ENDERECO_DB_SELECT_1_Query1 Execute(R2600_LER_ENDERECO_DB_SELECT_1_Query1 r2600_LER_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r2600_LER_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2600_LER_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2600_LER_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOEND_ENDERECO = result[i++].Value?.ToString();
            dta.PESSOEND_COMPL_ENDER = result[i++].Value?.ToString();
            dta.PESSOEND_CIDADE = result[i++].Value?.ToString();
            dta.PESSOEND_BAIRRO = result[i++].Value?.ToString();
            dta.PESSOEND_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}