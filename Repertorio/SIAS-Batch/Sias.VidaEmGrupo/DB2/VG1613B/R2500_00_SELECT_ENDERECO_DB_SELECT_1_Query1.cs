using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_ENDERECO,
            OCORR_ENDERECO,
            ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP,
            DDD,
            TELEFONE
            INTO :WHOST-COD-ENDERECO,
            :WHOST-OCORR-ENDERECO,
            :WHOST-ENDERECO,
            :WHOST-BAIRRO,
            :WHOST-CIDADE,
            :WHOST-SIGLA-UF,
            :WHOST-CEP,
            :WHOST-DDD,
            :WHOST-TELEFONE
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :SUBGVGAP-COD-CLIENTE
            AND OCORR_ENDERECO = :SUBGVGAP-OCORR-ENDERECO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											COD_ENDERECO
							,
											OCORR_ENDERECO
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
											DDD
							,
											TELEFONE
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.SUBGVGAP_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.SUBGVGAP_OCORR_ENDERECO}'";

            return query;
        }
        public string WHOST_COD_ENDERECO { get; set; }
        public string WHOST_OCORR_ENDERECO { get; set; }
        public string WHOST_ENDERECO { get; set; }
        public string WHOST_BAIRRO { get; set; }
        public string WHOST_CIDADE { get; set; }
        public string WHOST_SIGLA_UF { get; set; }
        public string WHOST_CEP { get; set; }
        public string WHOST_DDD { get; set; }
        public string WHOST_TELEFONE { get; set; }
        public string SUBGVGAP_OCORR_ENDERECO { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }

        public static R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1 Execute(R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1 r2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COD_ENDERECO = result[i++].Value?.ToString();
            dta.WHOST_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.WHOST_ENDERECO = result[i++].Value?.ToString();
            dta.WHOST_BAIRRO = result[i++].Value?.ToString();
            dta.WHOST_CIDADE = result[i++].Value?.ToString();
            dta.WHOST_SIGLA_UF = result[i++].Value?.ToString();
            dta.WHOST_CEP = result[i++].Value?.ToString();
            dta.WHOST_DDD = result[i++].Value?.ToString();
            dta.WHOST_TELEFONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}