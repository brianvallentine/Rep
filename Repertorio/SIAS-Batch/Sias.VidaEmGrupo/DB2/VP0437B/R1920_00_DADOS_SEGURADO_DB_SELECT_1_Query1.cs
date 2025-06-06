using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T2.NOME_RAZAO,
            T2.CGCCPF,
            T3.ENDERECO,
            T3.BAIRRO,
            T3.CIDADE,
            T3.CEP,
            T3.SIGLA_UF
            INTO :WS-NOME-SEG,
            :WS-CGCCPF-SEG,
            :WS-ENDERECO-SEG,
            :WS-BAIRRO-SEG,
            :WS-CIDADE-SEG,
            :WS-CEP-SEG,
            :WS-UF-SEG
            FROM SEGUROS.PROPOSTAS_VA T1,
            SEGUROS.CLIENTES T2,
            SEGUROS.ENDERECOS T3
            WHERE T1.NUM_CERTIFICADO = :WS-CERTIFICADO
            AND T1.COD_CLIENTE = T2.COD_CLIENTE
            AND T1.COD_CLIENTE = T3.COD_CLIENTE
            AND T1.OCOREND = T3.OCORR_ENDERECO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T2.NOME_RAZAO
							,
											T2.CGCCPF
							,
											T3.ENDERECO
							,
											T3.BAIRRO
							,
											T3.CIDADE
							,
											T3.CEP
							,
											T3.SIGLA_UF
											FROM SEGUROS.PROPOSTAS_VA T1
							,
											SEGUROS.CLIENTES T2
							,
											SEGUROS.ENDERECOS T3
											WHERE T1.NUM_CERTIFICADO = '{this.WS_CERTIFICADO}'
											AND T1.COD_CLIENTE = T2.COD_CLIENTE
											AND T1.COD_CLIENTE = T3.COD_CLIENTE
											AND T1.OCOREND = T3.OCORR_ENDERECO
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WS_NOME_SEG { get; set; }
        public string WS_CGCCPF_SEG { get; set; }
        public string WS_ENDERECO_SEG { get; set; }
        public string WS_BAIRRO_SEG { get; set; }
        public string WS_CIDADE_SEG { get; set; }
        public string WS_CEP_SEG { get; set; }
        public string WS_UF_SEG { get; set; }
        public string WS_CERTIFICADO { get; set; }

        public static R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1 Execute(R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1 r1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = r1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1920_00_DADOS_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_NOME_SEG = result[i++].Value?.ToString();
            dta.WS_CGCCPF_SEG = result[i++].Value?.ToString();
            dta.WS_ENDERECO_SEG = result[i++].Value?.ToString();
            dta.WS_BAIRRO_SEG = result[i++].Value?.ToString();
            dta.WS_CIDADE_SEG = result[i++].Value?.ToString();
            dta.WS_CEP_SEG = result[i++].Value?.ToString();
            dta.WS_UF_SEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}