using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ENDERECO ,
            ENDERECO ,
            BAIRRO ,
            CIDADE ,
            SIGLA_UF ,
            CEP ,
            DDD ,
            TELEFONE ,
            FAX ,
            SIT_REGISTRO
            INTO :ENDERECO-COD-ENDERECO,
            :ENDERECO-ENDERECO ,
            :ENDERECO-BAIRRO ,
            :ENDERECO-CIDADE ,
            :ENDERECO-SIGLA-UF ,
            :ENDERECO-CEP ,
            :ENDERECO-DDD ,
            :ENDERECO-TELEFONE ,
            :ENDERECO-FAX ,
            :ENDERECO-SIT-REGISTRO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE
            AND OCORR_ENDERECO = :PROPOVA-OCOREND
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ENDERECO 
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
											SIT_REGISTRO
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.PROPOVA_OCOREND}'";

            return query;
        }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_FAX { get; set; }
        public string ENDERECO_SIT_REGISTRO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }

        public static R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 r1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_COD_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            dta.ENDERECO_FAX = result[i++].Value?.ToString();
            dta.ENDERECO_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}