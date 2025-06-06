using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.ENDERECO,
            A.BAIRRO,
            A.CIDADE,
            A.SIGLA_UF,
            A.CEP
            INTO :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP
            FROM SEGUROS.ENDERECOS A
            WHERE A.COD_CLIENTE = :BILHETE-COD-CLIENTE
            AND A.OCORR_ENDERECO = :BILHETE-OCORR-ENDERECO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.ENDERECO
							,
											A.BAIRRO
							,
											A.CIDADE
							,
											A.SIGLA_UF
							,
											A.CEP
											FROM SEGUROS.ENDERECOS A
											WHERE A.COD_CLIENTE = '{this.BILHETE_COD_CLIENTE}'
											AND A.OCORR_ENDERECO = '{this.BILHETE_OCORR_ENDERECO}'
											WITH UR";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string BILHETE_OCORR_ENDERECO { get; set; }
        public string BILHETE_COD_CLIENTE { get; set; }

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
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}