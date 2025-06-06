using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1 : QueryBasis<R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_FORNECEDOR ,
            ENDERECO ,
            BAIRRO ,
            CIDADE ,
            SIGLA_UF ,
            CEP ,
            CGCCPF ,
            TIPO_PESSOA
            INTO :FORNECED-NOME-FORNECEDOR ,
            :FORNECED-ENDERECO ,
            :FORNECED-BAIRRO ,
            :FORNECED-CIDADE ,
            :FORNECED-SIGLA-UF ,
            :FORNECED-CEP ,
            :FORNECED-CGCCPF ,
            :FORNECED-TIPO-PESSOA
            FROM SEGUROS.FORNECEDORES
            WHERE COD_FORNECEDOR =
            :FORNECED-COD-FORNECEDOR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FORNECEDOR 
							,
											ENDERECO 
							,
											BAIRRO 
							,
											CIDADE 
							,
											SIGLA_UF 
							,
											CEP 
							,
											CGCCPF 
							,
											TIPO_PESSOA
											FROM SEGUROS.FORNECEDORES
											WHERE COD_FORNECEDOR =
											'{this.FORNECED_COD_FORNECEDOR}'
											WITH UR";

            return query;
        }
        public string FORNECED_NOME_FORNECEDOR { get; set; }
        public string FORNECED_ENDERECO { get; set; }
        public string FORNECED_BAIRRO { get; set; }
        public string FORNECED_CIDADE { get; set; }
        public string FORNECED_SIGLA_UF { get; set; }
        public string FORNECED_CEP { get; set; }
        public string FORNECED_CGCCPF { get; set; }
        public string FORNECED_TIPO_PESSOA { get; set; }
        public string FORNECED_COD_FORNECEDOR { get; set; }

        public static R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1 Execute(R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1 r1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1)
        {
            var ths = r1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.FORNECED_NOME_FORNECEDOR = result[i++].Value?.ToString();
            dta.FORNECED_ENDERECO = result[i++].Value?.ToString();
            dta.FORNECED_BAIRRO = result[i++].Value?.ToString();
            dta.FORNECED_CIDADE = result[i++].Value?.ToString();
            dta.FORNECED_SIGLA_UF = result[i++].Value?.ToString();
            dta.FORNECED_CEP = result[i++].Value?.ToString();
            dta.FORNECED_CGCCPF = result[i++].Value?.ToString();
            dta.FORNECED_TIPO_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}