using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2036B
{
    public class R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1 : QueryBasis<R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT L.COD_LOT_FENAL,
            L.COD_LOT_CEF,
            L.NUM_APOLICE,
            L.AGENCIA,
            L.OPERACAO_CONTA,
            L.NUMERO_CONTA,
            L.DV_CONTA,
            L.COD_CLIENTE,
            L.ENDERECO,
            L.COMPL_ENDERECO,
            L.BAIRRO,
            L.CEP,
            L.CIDADE,
            L.SIGLA_UF,
            L.DDD,
            L.NUM_FONE,
            L.DES_EMAIL,
            L.NUM_FAX,
            L.DTINIVIG,
            L.DTTERVIG,
            C.NOME_RAZAO,
            C.CGCCPF,
            C.TIPO_PESSOA
            INTO :V0LOT-COD-LOT-FENAL,
            :V0LOT-COD-LOT-CEF,
            :V0LOT-NUM-APOLICE,
            :LOTERI01-AGENCIA,
            :LOTERI01-OPERACAO-CONTA,
            :LOTERI01-NUMERO-CONTA,
            :LOTERI01-DV-CONTA,
            :V0LOT-COD-CLIENTE,
            :LOTERI01-ENDERECO,
            :LOTERI01-COMPL-ENDERECO,
            :LOTERI01-BAIRRO,
            :LOTERI01-CEP,
            :LOTERI01-CIDADE,
            :LOTERI01-SIGLA-UF,
            :LOTERI01-DDD,
            :LOTERI01-NUM-FONE,
            :LOTERI01-DES-EMAIL,
            :LOTERI01-NUM-FAX,
            :V0LOT-DTINIVIG,
            :V0LOT-DTTERVIG,
            :CLIENTES-NOME-RAZAO,
            :CLIENTES-CGCCPF,
            :CLIENTES-TIPO-PESSOA
            FROM SEGUROS.V0LOTERICO01 L,
            SEGUROS.CLIENTES C
            WHERE L.NUM_APOLICE = :V0APO-NUM-APOLICE
            AND L.COD_LOT_CEF = :V0LOT-COD-LOT-FENAL
            AND L.DTINIVIG = :WS-MAX-DTINIVIG
            AND L.COD_CLIENTE = C.COD_CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT L.COD_LOT_FENAL
							,
											L.COD_LOT_CEF
							,
											L.NUM_APOLICE
							,
											L.AGENCIA
							,
											L.OPERACAO_CONTA
							,
											L.NUMERO_CONTA
							,
											L.DV_CONTA
							,
											L.COD_CLIENTE
							,
											L.ENDERECO
							,
											L.COMPL_ENDERECO
							,
											L.BAIRRO
							,
											L.CEP
							,
											L.CIDADE
							,
											L.SIGLA_UF
							,
											L.DDD
							,
											L.NUM_FONE
							,
											L.DES_EMAIL
							,
											L.NUM_FAX
							,
											L.DTINIVIG
							,
											L.DTTERVIG
							,
											C.NOME_RAZAO
							,
											C.CGCCPF
							,
											C.TIPO_PESSOA
											FROM SEGUROS.V0LOTERICO01 L
							,
											SEGUROS.CLIENTES C
											WHERE L.NUM_APOLICE = '{this.V0APO_NUM_APOLICE}'
											AND L.COD_LOT_CEF = '{this.V0LOT_COD_LOT_FENAL}'
											AND L.DTINIVIG = '{this.WS_MAX_DTINIVIG}'
											AND L.COD_CLIENTE = C.COD_CLIENTE";

            return query;
        }
        public string V0LOT_COD_LOT_FENAL { get; set; }
        public string V0LOT_COD_LOT_CEF { get; set; }
        public string V0LOT_NUM_APOLICE { get; set; }
        public string LOTERI01_AGENCIA { get; set; }
        public string LOTERI01_OPERACAO_CONTA { get; set; }
        public string LOTERI01_NUMERO_CONTA { get; set; }
        public string LOTERI01_DV_CONTA { get; set; }
        public string V0LOT_COD_CLIENTE { get; set; }
        public string LOTERI01_ENDERECO { get; set; }
        public string LOTERI01_COMPL_ENDERECO { get; set; }
        public string LOTERI01_BAIRRO { get; set; }
        public string LOTERI01_CEP { get; set; }
        public string LOTERI01_CIDADE { get; set; }
        public string LOTERI01_SIGLA_UF { get; set; }
        public string LOTERI01_DDD { get; set; }
        public string LOTERI01_NUM_FONE { get; set; }
        public string LOTERI01_DES_EMAIL { get; set; }
        public string LOTERI01_NUM_FAX { get; set; }
        public string V0LOT_DTINIVIG { get; set; }
        public string V0LOT_DTTERVIG { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string V0APO_NUM_APOLICE { get; set; }
        public string WS_MAX_DTINIVIG { get; set; }

        public static R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1 Execute(R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1 r0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1)
        {
            var ths = r0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0LOT_COD_LOT_FENAL = result[i++].Value?.ToString();
            dta.V0LOT_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.V0LOT_NUM_APOLICE = result[i++].Value?.ToString();
            dta.LOTERI01_AGENCIA = result[i++].Value?.ToString();
            dta.LOTERI01_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.LOTERI01_NUMERO_CONTA = result[i++].Value?.ToString();
            dta.LOTERI01_DV_CONTA = result[i++].Value?.ToString();
            dta.V0LOT_COD_CLIENTE = result[i++].Value?.ToString();
            dta.LOTERI01_ENDERECO = result[i++].Value?.ToString();
            dta.LOTERI01_COMPL_ENDERECO = result[i++].Value?.ToString();
            dta.LOTERI01_BAIRRO = result[i++].Value?.ToString();
            dta.LOTERI01_CEP = result[i++].Value?.ToString();
            dta.LOTERI01_CIDADE = result[i++].Value?.ToString();
            dta.LOTERI01_SIGLA_UF = result[i++].Value?.ToString();
            dta.LOTERI01_DDD = result[i++].Value?.ToString();
            dta.LOTERI01_NUM_FONE = result[i++].Value?.ToString();
            dta.LOTERI01_DES_EMAIL = result[i++].Value?.ToString();
            dta.LOTERI01_NUM_FAX = result[i++].Value?.ToString();
            dta.V0LOT_DTINIVIG = result[i++].Value?.ToString();
            dta.V0LOT_DTTERVIG = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}