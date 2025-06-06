using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0801_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0801_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BI001.NUM_BILHETE
            ,CL001.CGCCPF
            ,BI001.DATA_MOVIMENTO
            ,VALUE(MB001.DATA_QUITACAO, '0001-01-01' )
            ,VALUE(PF001.DATA_CREDITO, '0001-01-01' )
            ,CASE
            WHEN VALUE(PF001.NUM_PROPOSTA_SIVPF,0) > 0
            THEN PF001.NUM_PROPOSTA_SIVPF
            ELSE VALUE(CS001.NUM_PROPOSTA_SIVPF,0)
            END
            ,VALUE(BI001.COD_PRODUTO,0)
            ,BI001.RAMO
            ,BI001.OPC_COBERTURA
            ,BI001.DATA_QUITACAO
            ,BI001.DATA_VENDA
            ,CL001.DATA_NASCIMENTO
            ,YEAR(BI001.DATA_QUITACAO - CL001.DATA_NASCIMENTO)
            INTO :VG103-NUM-CERTIFICADO
            ,:VG103-NUM-CPF-CNPJ
            ,:VG103-DTA-OCORRENCIA
            ,:VG103-DTA-RCAP
            ,:DATA-CREDITO
            ,:NUM-PROPOSTA-SIVPF
            ,:BILHETE-COD-PRODUTO
            ,:BILHETE-RAMO
            ,:BILHETE-OPC-COBERTURA
            ,:BILHETE-DATA-QUITACAO
            ,:BILHETE-DATA-VENDA
            ,:CLIENTES-DATA-NASCIMENTO
            ,:WH-IDADE
            FROM SEGUROS.CLIENTES CL001
            ,SEGUROS.BILHETE BI001
            LEFT JOIN SEGUROS.MOVIMENTO_COBRANCA MB001
            ON MB001.NUM_TITULO = BI001.NUM_BILHETE
            LEFT JOIN SEGUROS.PROPOSTA_FIDELIZ PF001
            ON PF001.NUM_SICOB = BI001.NUM_BILHETE
            LEFT JOIN SEGUROS.CONVERSAO_SICOB CS001
            ON CS001.NUM_SICOB = BI001.NUM_BILHETE
            WHERE BI001.NUM_BILHETE = :BILHETE-NUM-BILHETE
            AND CL001.COD_CLIENTE = BI001.COD_CLIENTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT BI001.NUM_BILHETE
											,CL001.CGCCPF
											,BI001.DATA_MOVIMENTO
											,VALUE(MB001.DATA_QUITACAO
							, '0001-01-01' )
											,VALUE(PF001.DATA_CREDITO
							, '0001-01-01' )
											,CASE
											WHEN VALUE(PF001.NUM_PROPOSTA_SIVPF
							,0) > 0
											THEN PF001.NUM_PROPOSTA_SIVPF
											ELSE VALUE(CS001.NUM_PROPOSTA_SIVPF
							,0)
											END
											,VALUE(BI001.COD_PRODUTO
							,0)
											,BI001.RAMO
											,BI001.OPC_COBERTURA
											,BI001.DATA_QUITACAO
											,BI001.DATA_VENDA
											,CL001.DATA_NASCIMENTO
											,YEAR(BI001.DATA_QUITACAO - CL001.DATA_NASCIMENTO)
											FROM SEGUROS.CLIENTES CL001
											,SEGUROS.BILHETE BI001
											LEFT
							JOIN SEGUROS.MOVIMENTO_COBRANCA MB001
											ON MB001.NUM_TITULO = BI001.NUM_BILHETE
											LEFT
							JOIN SEGUROS.PROPOSTA_FIDELIZ PF001
											ON PF001.NUM_SICOB = BI001.NUM_BILHETE
											LEFT
							JOIN SEGUROS.CONVERSAO_SICOB CS001
											ON CS001.NUM_SICOB = BI001.NUM_BILHETE
											WHERE BI001.NUM_BILHETE = '{this.BILHETE_NUM_BILHETE}'
											AND CL001.COD_CLIENTE = BI001.COD_CLIENTE
											WITH UR";

            return query;
        }
        public string VG103_NUM_CERTIFICADO { get; set; }
        public string VG103_NUM_CPF_CNPJ { get; set; }
        public string VG103_DTA_OCORRENCIA { get; set; }
        public string VG103_DTA_RCAP { get; set; }
        public string DATA_CREDITO { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }
        public string BILHETE_COD_PRODUTO { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_DATA_VENDA { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string WH_IDADE { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static P0801_05_INICIO_DB_SELECT_1_Query1 Execute(P0801_05_INICIO_DB_SELECT_1_Query1 p0801_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0801_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0801_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0801_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG103_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG103_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.VG103_DTA_OCORRENCIA = result[i++].Value?.ToString();
            dta.VG103_DTA_RCAP = result[i++].Value?.ToString();
            dta.DATA_CREDITO = result[i++].Value?.ToString();
            dta.NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.BILHETE_COD_PRODUTO = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();
            dta.BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_DATA_VENDA = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.WH_IDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}