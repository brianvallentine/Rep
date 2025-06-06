using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 : QueryBasis<R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_ENDERECO,
            ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP
            INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO,
            :DCLENDERECOS.ENDERECO-ENDERECO,
            :DCLENDERECOS.ENDERECO-BAIRRO,
            :DCLENDERECOS.ENDERECO-CIDADE,
            :DCLENDERECOS.ENDERECO-SIGLA-UF,
            :DCLENDERECOS.ENDERECO-CEP
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :WHOST-COD-CLIENTE
            AND ENDERECO = :WHOST-ENDERECO
            AND BAIRRO = :WHOST-BAIRRO
            AND CIDADE = :WHOST-CIDADE
            AND SIGLA_UF = :WHOST-SIGLA-UF
            AND CEP = :WHOST-CEP
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OCORR_ENDERECO
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
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.WHOST_COD_CLIENTE}'
											AND ENDERECO = '{this.WHOST_ENDERECO}'
											AND BAIRRO = '{this.WHOST_BAIRRO}'
											AND CIDADE = '{this.WHOST_CIDADE}'
											AND SIGLA_UF = '{this.WHOST_SIGLA_UF}'
											AND CEP = '{this.WHOST_CEP}'";

            return query;
        }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string WHOST_COD_CLIENTE { get; set; }
        public string WHOST_ENDERECO { get; set; }
        public string WHOST_SIGLA_UF { get; set; }
        public string WHOST_BAIRRO { get; set; }
        public string WHOST_CIDADE { get; set; }
        public string WHOST_CEP { get; set; }

        public static R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 Execute(R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 r4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1)
        {
            var ths = r4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}