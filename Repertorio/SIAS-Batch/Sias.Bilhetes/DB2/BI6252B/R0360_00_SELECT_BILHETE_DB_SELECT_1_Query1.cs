using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_PROPOSTA_SIVPF ,
            A.COD_PRODUTO_SIVPF ,
            B.NUM_BILHETE ,
            B.NUM_APOLICE ,
            B.FONTE ,
            B.AGE_COBRANCA ,
            B.NUM_MATRICULA ,
            B.COD_AGENCIA ,
            B.OPERACAO_CONTA ,
            B.NUM_CONTA ,
            B.DIG_CONTA ,
            B.COD_CLIENTE ,
            B.OCORR_ENDERECO ,
            B.COD_AGENCIA_DEB ,
            B.OPERACAO_CONTA_DEB ,
            B.NUM_CONTA_DEB ,
            B.DIG_CONTA_DEB ,
            B.OPC_COBERTURA ,
            B.DATA_QUITACAO ,
            B.VAL_RCAP ,
            B.RAMO ,
            B.DATA_VENDA ,
            B.SITUACAO ,
            C.NOME_RAZAO ,
            UCASE(C.NOME_RAZAO) ,
            C.TIPO_PESSOA ,
            C.CGCCPF ,
            C.DATA_NASCIMENTO ,
            C.IDE_SEXO ,
            C.ESTADO_CIVIL ,
            D.CIDADE ,
            UCASE(D.CIDADE) ,
            D.SIGLA_UF ,
            UCASE(D.SIGLA_UF)
            INTO :CONVERSI-NUM-PROPOSTA-SIVPF ,
            :CONVERSI-COD-PRODUTO-SIVPF ,
            :BILHETE-NUM-BILHETE ,
            :BILHETE-NUM-APOLICE ,
            :BILHETE-FONTE ,
            :BILHETE-AGE-COBRANCA ,
            :BILHETE-NUM-MATRICULA ,
            :BILHETE-COD-AGENCIA ,
            :BILHETE-OPERACAO-CONTA ,
            :BILHETE-NUM-CONTA ,
            :BILHETE-DIG-CONTA ,
            :BILHETE-COD-CLIENTE ,
            :BILHETE-OCORR-ENDERECO ,
            :BILHETE-COD-AGENCIA-DEB ,
            :BILHETE-OPERACAO-CONTA-DEB ,
            :BILHETE-NUM-CONTA-DEB ,
            :BILHETE-DIG-CONTA-DEB ,
            :BILHETE-OPC-COBERTURA ,
            :BILHETE-DATA-QUITACAO ,
            :BILHETE-VAL-RCAP ,
            :BILHETE-RAMO ,
            :BILHETE-DATA-VENDA ,
            :BILHETE-SITUACAO ,
            :CLIENTES-NOME-RAZAO ,
            :WSHOST-NOME-RAZAO ,
            :CLIENTES-TIPO-PESSOA ,
            :CLIENTES-CGCCPF ,
            :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC ,
            :CLIENTES-IDE-SEXO:VIND-SEXO ,
            :CLIENTES-ESTADO-CIVIL:VIND-ESTCIVIL ,
            :ENDERECO-CIDADE ,
            :WSHOST-CIDADE ,
            :ENDERECO-SIGLA-UF ,
            :WSHOST-SIGLA-UF
            FROM SEGUROS.CONVERSAO_SICOB A ,
            SEGUROS.BILHETE B ,
            SEGUROS.CLIENTES C ,
            SEGUROS.ENDERECOS D
            WHERE A.NUM_PROPOSTA_SIVPF =
            :CONVERSI-NUM-PROPOSTA-SIVPF
            AND A.NUM_SICOB =
            B.NUM_BILHETE
            AND B.COD_CLIENTE =
            C.COD_CLIENTE
            AND B.COD_CLIENTE =
            D.COD_CLIENTE
            AND B.OCORR_ENDERECO =
            D.OCORR_ENDERECO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_PROPOSTA_SIVPF 
							,
											A.COD_PRODUTO_SIVPF 
							,
											B.NUM_BILHETE 
							,
											B.NUM_APOLICE 
							,
											B.FONTE 
							,
											B.AGE_COBRANCA 
							,
											B.NUM_MATRICULA 
							,
											B.COD_AGENCIA 
							,
											B.OPERACAO_CONTA 
							,
											B.NUM_CONTA 
							,
											B.DIG_CONTA 
							,
											B.COD_CLIENTE 
							,
											B.OCORR_ENDERECO 
							,
											B.COD_AGENCIA_DEB 
							,
											B.OPERACAO_CONTA_DEB 
							,
											B.NUM_CONTA_DEB 
							,
											B.DIG_CONTA_DEB 
							,
											B.OPC_COBERTURA 
							,
											B.DATA_QUITACAO 
							,
											B.VAL_RCAP 
							,
											B.RAMO 
							,
											B.DATA_VENDA 
							,
											B.SITUACAO 
							,
											C.NOME_RAZAO 
							,
											UCASE(C.NOME_RAZAO) 
							,
											C.TIPO_PESSOA 
							,
											C.CGCCPF 
							,
											C.DATA_NASCIMENTO 
							,
											C.IDE_SEXO 
							,
											C.ESTADO_CIVIL 
							,
											D.CIDADE 
							,
											UCASE(D.CIDADE) 
							,
											D.SIGLA_UF 
							,
											UCASE(D.SIGLA_UF)
											FROM SEGUROS.CONVERSAO_SICOB A 
							,
											SEGUROS.BILHETE B 
							,
											SEGUROS.CLIENTES C 
							,
											SEGUROS.ENDERECOS D
											WHERE A.NUM_PROPOSTA_SIVPF =
											'{this.CONVERSI_NUM_PROPOSTA_SIVPF}'
											AND A.NUM_SICOB =
											B.NUM_BILHETE
											AND B.COD_CLIENTE =
											C.COD_CLIENTE
											AND B.COD_CLIENTE =
											D.COD_CLIENTE
											AND B.OCORR_ENDERECO =
											D.OCORR_ENDERECO
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }
        public string CONVERSI_COD_PRODUTO_SIVPF { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_FONTE { get; set; }
        public string BILHETE_AGE_COBRANCA { get; set; }
        public string BILHETE_NUM_MATRICULA { get; set; }
        public string BILHETE_COD_AGENCIA { get; set; }
        public string BILHETE_OPERACAO_CONTA { get; set; }
        public string BILHETE_NUM_CONTA { get; set; }
        public string BILHETE_DIG_CONTA { get; set; }
        public string BILHETE_COD_CLIENTE { get; set; }
        public string BILHETE_OCORR_ENDERECO { get; set; }
        public string BILHETE_COD_AGENCIA_DEB { get; set; }
        public string BILHETE_OPERACAO_CONTA_DEB { get; set; }
        public string BILHETE_NUM_CONTA_DEB { get; set; }
        public string BILHETE_DIG_CONTA_DEB { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_VAL_RCAP { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_DATA_VENDA { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string WSHOST_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASC { get; set; }
        public string CLIENTES_IDE_SEXO { get; set; }
        public string VIND_SEXO { get; set; }
        public string CLIENTES_ESTADO_CIVIL { get; set; }
        public string VIND_ESTCIVIL { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string WSHOST_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string WSHOST_SIGLA_UF { get; set; }

        public static R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1 r0360_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0360_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVERSI_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.CONVERSI_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_FONTE = result[i++].Value?.ToString();
            dta.BILHETE_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.BILHETE_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.BILHETE_COD_AGENCIA = result[i++].Value?.ToString();
            dta.BILHETE_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.BILHETE_NUM_CONTA = result[i++].Value?.ToString();
            dta.BILHETE_DIG_CONTA = result[i++].Value?.ToString();
            dta.BILHETE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.BILHETE_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.BILHETE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_OPERACAO_CONTA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();
            dta.BILHETE_DATA_VENDA = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.WSHOST_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DTNASC = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            dta.CLIENTES_IDE_SEXO = result[i++].Value?.ToString();
            dta.VIND_SEXO = string.IsNullOrWhiteSpace(dta.CLIENTES_IDE_SEXO) ? "-1" : "0";
            dta.CLIENTES_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.VIND_ESTCIVIL = string.IsNullOrWhiteSpace(dta.CLIENTES_ESTADO_CIVIL) ? "-1" : "0";
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.WSHOST_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.WSHOST_SIGLA_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}