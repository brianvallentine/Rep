using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0972B
{
    public class R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1 : QueryBasis<R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            A.NUM_CERTIFICADO
            , A.NUM_PARCELA
            , A.SIT_REGISTRO
            , A.DATA_QUITACAO
            , A.COD_PRODUTO
            , B.DATA_VENCIMENTO
            , C.NOME_RAZAO
            , C.CGCCPF
            , C.COD_CLIENTE
            , D.DDD
            , D.TELEFONE
            , E.NOME_PRODUTO
            , F.PRM_TOTAL
            , VALUE(G.COD_IDLG, ' ' )
            INTO
            :PROPOVA-NUM-CERTIFICADO
            , :PROPOVA-NUM-PARCELA
            , :PROPOVA-SIT-REGISTRO
            , :PROPOVA-DATA-QUITACAO
            , :PROPOVA-COD-PRODUTO
            , :PARCEVID-DATA-VENCIMENTO
            , :CLIENTES-NOME-RAZAO
            , :CLIENTES-CGCCPF
            , :CLIENTES-COD-CLIENTE
            , :ENDERECO-DDD
            , :ENDERECO-TELEFONE
            , :PRODUVG-NOME-PRODUTO
            , :COBHISVI-PRM-TOTAL
            , :GE407-COD-IDLG
            FROM SEGUROS.PROPOSTAS_VA A
            JOIN SEGUROS.PARCELAS_VIDAZUL B
            ON A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND A.NUM_PARCELA = B.NUM_PARCELA
            JOIN SEGUROS.CLIENTES C
            ON A.COD_CLIENTE = C.COD_CLIENTE
            JOIN SEGUROS.ENDERECOS D
            ON C.COD_CLIENTE = D.COD_CLIENTE
            AND A.OCOREND = D.OCORR_ENDERECO
            JOIN SEGUROS.PRODUTOS_VG E
            ON A.NUM_APOLICE = E.NUM_APOLICE
            AND A.COD_SUBGRUPO = E.COD_SUBGRUPO
            JOIN SEGUROS.COBER_HIST_VIDAZUL F
            ON A.NUM_CERTIFICADO = F.NUM_CERTIFICADO
            AND A.NUM_PARCELA = F.NUM_PARCELA
            LEFT JOIN SEGUROS.GE_CONTROLE_CARTAO_CIELO G
            ON A.NUM_CERTIFICADO = G.NUM_CERTIFICADO
            AND A.NUM_PARCELA = G.NUM_PARCELA
            WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :PROPOVA-NUM-PARCELA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											A.NUM_CERTIFICADO
											, A.NUM_PARCELA
											, A.SIT_REGISTRO
											, A.DATA_QUITACAO
											, A.COD_PRODUTO
											, B.DATA_VENCIMENTO
											, C.NOME_RAZAO
											, C.CGCCPF
											, C.COD_CLIENTE
											, D.DDD
											, D.TELEFONE
											, E.NOME_PRODUTO
											, F.PRM_TOTAL
											, VALUE(G.COD_IDLG
							, ' ' )
											FROM SEGUROS.PROPOSTAS_VA A
											JOIN SEGUROS.PARCELAS_VIDAZUL B
											ON A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND A.NUM_PARCELA = B.NUM_PARCELA
											JOIN SEGUROS.CLIENTES C
											ON A.COD_CLIENTE = C.COD_CLIENTE
											JOIN SEGUROS.ENDERECOS D
											ON C.COD_CLIENTE = D.COD_CLIENTE
											AND A.OCOREND = D.OCORR_ENDERECO
											JOIN SEGUROS.PRODUTOS_VG E
											ON A.NUM_APOLICE = E.NUM_APOLICE
											AND A.COD_SUBGRUPO = E.COD_SUBGRUPO
											JOIN SEGUROS.COBER_HIST_VIDAZUL F
											ON A.NUM_CERTIFICADO = F.NUM_CERTIFICADO
											AND A.NUM_PARCELA = F.NUM_PARCELA
											LEFT
							JOIN SEGUROS.GE_CONTROLE_CARTAO_CIELO G
											ON A.NUM_CERTIFICADO = G.NUM_CERTIFICADO
											AND A.NUM_PARCELA = G.NUM_PARCELA
											WHERE A.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.PROPOVA_NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string COBHISVI_PRM_TOTAL { get; set; }
        public string GE407_COD_IDLG { get; set; }

        public static R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1 Execute(R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1 r2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1)
        {
            var ths = r2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PARCEVID_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            dta.COBHISVI_PRM_TOTAL = result[i++].Value?.ToString();
            dta.GE407_COD_IDLG = result[i++].Value?.ToString();
            return dta;
        }

    }
}