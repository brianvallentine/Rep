using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0623B
{
    public class R0350_00_LER_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R0350_00_LER_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_CLIENTE ,
            COD_ENDERECO ,
            OCORR_ENDERECO ,
            ENDERECO ,
            BAIRRO ,
            CIDADE ,
            SIGLA_UF ,
            CEP ,
            DDD ,
            TELEFONE ,
            FAX ,
            TELEX ,
            SIT_REGISTRO
            INTO
            :DCLENDERECOS.ENDERECO-COD-CLIENTE ,
            :DCLENDERECOS.ENDERECO-COD-ENDERECO ,
            :DCLENDERECOS.ENDERECO-OCORR-ENDERECO ,
            :DCLENDERECOS.ENDERECO-ENDERECO ,
            :DCLENDERECOS.ENDERECO-BAIRRO ,
            :DCLENDERECOS.ENDERECO-CIDADE ,
            :DCLENDERECOS.ENDERECO-SIGLA-UF ,
            :DCLENDERECOS.ENDERECO-CEP ,
            :DCLENDERECOS.ENDERECO-DDD ,
            :DCLENDERECOS.ENDERECO-TELEFONE ,
            :DCLENDERECOS.ENDERECO-FAX ,
            :DCLENDERECOS.ENDERECO-TELEX ,
            :DCLENDERECOS.ENDERECO-SIT-REGISTRO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE =
            :DCLENDERECOS.ENDERECO-COD-CLIENTE
            AND OCORR_ENDERECO =
            :DCLENDERECOS.ENDERECO-OCORR-ENDERECO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_CLIENTE 
							,
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
							,
											FAX 
							,
											TELEX 
							,
											SIT_REGISTRO
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE =
											'{this.ENDERECO_COD_CLIENTE}'
											AND OCORR_ENDERECO =
											'{this.ENDERECO_OCORR_ENDERECO}'
											WITH UR";

            return query;
        }
        public string ENDERECO_COD_CLIENTE { get; set; }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_FAX { get; set; }
        public string ENDERECO_TELEX { get; set; }
        public string ENDERECO_SIT_REGISTRO { get; set; }

        public static R0350_00_LER_ENDERECO_DB_SELECT_1_Query1 Execute(R0350_00_LER_ENDERECO_DB_SELECT_1_Query1 r0350_00_LER_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r0350_00_LER_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0350_00_LER_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0350_00_LER_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_COD_CLIENTE = result[i++].Value?.ToString();
            dta.ENDERECO_COD_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            dta.ENDERECO_FAX = result[i++].Value?.ToString();
            dta.ENDERECO_TELEX = result[i++].Value?.ToString();
            dta.ENDERECO_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}