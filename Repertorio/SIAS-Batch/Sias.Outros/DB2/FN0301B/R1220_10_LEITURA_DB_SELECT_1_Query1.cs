using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1220_10_LEITURA_DB_SELECT_1_Query1 : QueryBasis<R1220_10_LEITURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO ,
            CIDADE ,
            BAIRRO ,
            CEP ,
            SIGLA_UF ,
            DDD ,
            TELEFONE
            INTO :V1ENDE-ENDERECO ,
            :V1ENDE-CIDADE,
            :V1ENDE-BAIRRO,
            :V1ENDE-CEP ,
            :V1ENDE-ESTADO ,
            :V1ENDE-DDD,
            :V1ENDE-TELEFONE
            FROM SEGUROS.V1ENDERECOS
            WHERE COD_CLIENTE = :WHOST-CODCLIEN
            AND OCORR_ENDERECO = :WHOST-CODENDER
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDERECO 
							,
											CIDADE 
							,
											BAIRRO 
							,
											CEP 
							,
											SIGLA_UF 
							,
											DDD 
							,
											TELEFONE
											FROM SEGUROS.V1ENDERECOS
											WHERE COD_CLIENTE = '{this.WHOST_CODCLIEN}'
											AND OCORR_ENDERECO = '{this.WHOST_CODENDER}'
											WITH UR";

            return query;
        }
        public string V1ENDE_ENDERECO { get; set; }
        public string V1ENDE_CIDADE { get; set; }
        public string V1ENDE_BAIRRO { get; set; }
        public string V1ENDE_CEP { get; set; }
        public string V1ENDE_ESTADO { get; set; }
        public string V1ENDE_DDD { get; set; }
        public string V1ENDE_TELEFONE { get; set; }
        public string WHOST_CODCLIEN { get; set; }
        public string WHOST_CODENDER { get; set; }

        public static R1220_10_LEITURA_DB_SELECT_1_Query1 Execute(R1220_10_LEITURA_DB_SELECT_1_Query1 r1220_10_LEITURA_DB_SELECT_1_Query1)
        {
            var ths = r1220_10_LEITURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1220_10_LEITURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1220_10_LEITURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDE_ENDERECO = result[i++].Value?.ToString();
            dta.V1ENDE_CIDADE = result[i++].Value?.ToString();
            dta.V1ENDE_BAIRRO = result[i++].Value?.ToString();
            dta.V1ENDE_CEP = result[i++].Value?.ToString();
            dta.V1ENDE_ESTADO = result[i++].Value?.ToString();
            dta.V1ENDE_DDD = result[i++].Value?.ToString();
            dta.V1ENDE_TELEFONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}