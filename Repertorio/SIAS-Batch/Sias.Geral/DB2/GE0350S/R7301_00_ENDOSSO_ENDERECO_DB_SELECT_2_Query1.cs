using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1 : QueryBasis<R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO ,
            BAIRRO ,
            CIDADE ,
            SIGLA_UF ,
            CEP ,
            DDD ,
            TELEFONE ,
            FAX ,
            VALUE(DES_COMPLEMENTO, ' ' )
            INTO :ENDERECO-ENDERECO ,
            :ENDERECO-BAIRRO ,
            :ENDERECO-CIDADE ,
            :ENDERECO-SIGLA-UF ,
            :ENDERECO-CEP ,
            :ENDERECO-DDD ,
            :ENDERECO-TELEFONE ,
            :ENDERECO-FAX ,
            :ENDERECO-DES-COMPLEMENTO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
            AND OCORR_ENDERECO = :ENDOSSOS-OCORR-ENDERECO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDERECO 
							,
											BAIRRO 
							,
											CIDADE 
							,
											SIGLA_UF 
							,
											CEP 
							,
											DDD 
							,
											TELEFONE 
							,
											FAX 
							,
											VALUE(DES_COMPLEMENTO
							, ' ' )
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.ENDOSSOS_OCORR_ENDERECO}'
											WITH UR";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_FAX { get; set; }
        public string ENDERECO_DES_COMPLEMENTO { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1 Execute(R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1 r7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1)
        {
            var ths = r7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7301_00_ENDOSSO_ENDERECO_DB_SELECT_2_Query1();
            var i = 0;
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            dta.ENDERECO_FAX = result[i++].Value?.ToString();
            dta.ENDERECO_DES_COMPLEMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}