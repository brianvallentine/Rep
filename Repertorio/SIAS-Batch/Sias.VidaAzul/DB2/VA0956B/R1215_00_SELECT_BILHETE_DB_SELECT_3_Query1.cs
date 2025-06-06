using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0956B
{
    public class R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1 : QueryBasis<R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP
            INTO :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE
            AND OCORR_ENDERECO = :SEGURVGA-OCORR-ENDERECO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											BAIRRO
							,
											CIDADE
							,
											SIGLA_UF
							,
											CEP
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.SEGURVGA_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.SEGURVGA_OCORR_ENDERECO}'
											WITH UR";

            return query;
        }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }

        public static R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1 Execute(R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1 r1215_00_SELECT_BILHETE_DB_SELECT_3_Query1)
        {
            var ths = r1215_00_SELECT_BILHETE_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1();
            var i = 0;
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}