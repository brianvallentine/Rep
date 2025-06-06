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
    public class R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1 : QueryBasis<R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.ENDERECO,
            C.BAIRRO,
            C.CIDADE,
            C.SIGLA_UF,
            C.CEP,
            VALUE(C.DES_COMPLEMENTO, ' ' )
            INTO :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP,
            :ENDERECO-DES-COMPLEMENTO
            FROM SEGUROS.SEGURADOS_VGAP A,
            SEGUROS.SINISTRO_MESTRE B,
            SEGUROS.ENDERECOS C
            WHERE B.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND A.COD_CLIENTE = C.COD_CLIENTE
            AND C.OCORR_ENDERECO =
            (SELECT MAX(D.OCORR_ENDERECO)
            FROM SEGUROS.ENDERECOS D
            WHERE D.COD_CLIENTE = C.COD_CLIENTE)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT C.ENDERECO
							,
											C.BAIRRO
							,
											C.CIDADE
							,
											C.SIGLA_UF
							,
											C.CEP
							,
											VALUE(C.DES_COMPLEMENTO
							, ' ' )
											FROM SEGUROS.SEGURADOS_VGAP A
							,
											SEGUROS.SINISTRO_MESTRE B
							,
											SEGUROS.ENDERECOS C
											WHERE B.NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND A.COD_CLIENTE = C.COD_CLIENTE
											AND C.OCORR_ENDERECO =
											(SELECT MAX(D.OCORR_ENDERECO)
											FROM SEGUROS.ENDERECOS D
											WHERE D.COD_CLIENTE = C.COD_CLIENTE)
											WITH UR";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DES_COMPLEMENTO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1 Execute(R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1 r2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1)
        {
            var ths = r2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DES_COMPLEMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}