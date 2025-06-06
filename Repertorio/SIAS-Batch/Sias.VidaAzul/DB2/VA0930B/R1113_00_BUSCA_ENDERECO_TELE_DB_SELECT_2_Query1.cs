using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1 : QueryBasis<R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO
            , BAIRRO
            , CIDADE
            , SIGLA_UF
            , CEP
            , DDD
            , TELEFONE
            INTO :ENDERECO-ENDERECO
            , :ENDERECO-BAIRRO
            , :ENDERECO-CIDADE
            , :ENDERECO-SIGLA-UF
            , :ENDERECO-CEP
            , :ENDERECO-DDD
            , :ENDERECO-TELEFONE
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :WS-COD-CLIENTE
            AND OCORR_ENDERECO = :RELATORI-NUM-COPIAS
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT ENDERECO
											, BAIRRO
											, CIDADE
											, SIGLA_UF
											, CEP
											, DDD
											, TELEFONE
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.WS_COD_CLIENTE}'
											AND OCORR_ENDERECO = '{this.RELATORI_NUM_COPIAS}'
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
        public string RELATORI_NUM_COPIAS { get; set; }
        public string WS_COD_CLIENTE { get; set; }

        public static R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1 Execute(R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1 r1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1)
        {
            var ths = r1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1();
            var i = 0;
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}