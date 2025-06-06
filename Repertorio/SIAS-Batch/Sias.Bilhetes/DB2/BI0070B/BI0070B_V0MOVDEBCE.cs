using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0070B
{
    public class BI0070B_V0MOVDEBCE : QueryBasis<BI0070B_V0MOVDEBCE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0070B_V0MOVDEBCE() { IsCursor = true; }

        public BI0070B_V0MOVDEBCE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVDEBCE_COD_EMPRESA { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_DATA_PROXVEN { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string MOVDEBCE_DIA_DEBITO { get; set; }
        public string VIND_DIADEBITO { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string VIND_OPERACAO { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string VIND_NUMCONTA { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string VIND_DIGCONTA { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_DATA_ENVIO { get; set; }
        public string VIND_DTENVIO { get; set; }
        public string MOVDEBCE_DATA_RETORNO { get; set; }
        public string VIND_DTRETORNO { get; set; }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string VIND_CODRETORNO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_COD_USUARIO { get; set; }
        public string VIND_USUARIO { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string VIND_REQUISICAO { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string VIND_NUMCARTAO { get; set; }
        public string MOVDEBCE_SEQUENCIA { get; set; }
        public string VIND_SEQUENCIA { get; set; }
        public string MOVDEBCE_NUM_LOTE { get; set; }
        public string VIND_NUM_LOTE { get; set; }
        public string MOVDEBCE_DTCREDITO { get; set; }
        public string VIND_DTCREDITO { get; set; }
        public string MOVDEBCE_STATUS_CARTAO { get; set; }
        public string VIND_STATUS { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string VIND_VLCREDITO { get; set; }

        public new void Open()
        {
            if (!IsProcedure)
                SetQuery(GetQueryEvent());
            base.Open();
        }


        public new bool Fetch()
        {
            if (!JustACursor)
            {
                var idx = CurrentIndex;
                Open();
                CurrentIndex = idx > -1 ? idx : 0;
            }

            return base.Fetch();
        }


        public override BI0070B_V0MOVDEBCE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0070B_V0MOVDEBCE();
            var i = 0;

            dta.MOVDEBCE_COD_EMPRESA = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_PROXVEN = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIADEBITO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DIA_DEBITO) ? "-1" : "0";
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.VIND_AGENCIA = string.IsNullOrWhiteSpace(dta.MOVDEBCE_COD_AGENCIA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_OPERACAO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_OPER_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NUMCONTA = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_DIGCONTA = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DIG_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_COD_CONVENIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_ENVIO = result[i++].Value?.ToString();
            dta.VIND_DTENVIO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DATA_ENVIO) ? "-1" : "0";
            dta.MOVDEBCE_DATA_RETORNO = result[i++].Value?.ToString();
            dta.VIND_DTRETORNO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DATA_RETORNO) ? "-1" : "0";
            dta.MOVDEBCE_COD_RETORNO_CEF = result[i++].Value?.ToString();
            dta.VIND_CODRETORNO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_COD_RETORNO_CEF) ? "-1" : "0";
            dta.MOVDEBCE_NSAS = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_USUARIO = result[i++].Value?.ToString();
            dta.VIND_USUARIO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_COD_USUARIO) ? "-1" : "0";
            dta.MOVDEBCE_NUM_REQUISICAO = result[i++].Value?.ToString();
            dta.VIND_REQUISICAO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_REQUISICAO) ? "-1" : "0";
            dta.MOVDEBCE_NUM_CARTAO = result[i++].Value?.ToString();
            dta.VIND_NUMCARTAO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CARTAO) ? "-1" : "0";
            dta.MOVDEBCE_SEQUENCIA = result[i++].Value?.ToString();
            dta.VIND_SEQUENCIA = string.IsNullOrWhiteSpace(dta.MOVDEBCE_SEQUENCIA) ? "-1" : "0";
            dta.MOVDEBCE_NUM_LOTE = result[i++].Value?.ToString();
            dta.VIND_NUM_LOTE = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_LOTE) ? "-1" : "0";
            dta.MOVDEBCE_DTCREDITO = result[i++].Value?.ToString();
            dta.VIND_DTCREDITO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DTCREDITO) ? "-1" : "0";
            dta.MOVDEBCE_STATUS_CARTAO = result[i++].Value?.ToString();
            dta.VIND_STATUS = string.IsNullOrWhiteSpace(dta.MOVDEBCE_STATUS_CARTAO) ? "-1" : "0";
            dta.MOVDEBCE_VLR_CREDITO = result[i++].Value?.ToString();
            dta.VIND_VLCREDITO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_VLR_CREDITO) ? "-1" : "0";

            return dta;
        }

    }
}