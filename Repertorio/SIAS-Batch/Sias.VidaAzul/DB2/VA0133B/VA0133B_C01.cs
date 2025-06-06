using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0133B
{
    public class VA0133B_C01 : QueryBasis<VA0133B_C01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0133B_C01() { IsCursor = true; }

        public VA0133B_C01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_CODRET { get; set; }
        public string WSS_NULL { get; set; }
        public string HISLANCT_TIPLANC { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string HISLANCT_PRM_TOTAL { get; set; }
        public string HISLANCT_DATA_VENCIMENTO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string CLIENEMA_EMAIL { get; set; }
        public string DB2_COD_SUSEP { get; set; }

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


        public override VA0133B_C01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0133B_C01();
            var i = 0;

            dta.HISLANCT_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISLANCT_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.HISLANCT_CODRET = result[i++].Value?.ToString();
            dta.WSS_NULL = string.IsNullOrWhiteSpace(dta.HISLANCT_CODRET) ? "-1" : "0";
            dta.HISLANCT_TIPLANC = result[i++].Value?.ToString();
            dta.HISLANCT_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISLANCT_PRM_TOTAL = result[i++].Value?.ToString();
            dta.HISLANCT_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            dta.CLIENEMA_EMAIL = result[i++].Value?.ToString();
            dta.DB2_COD_SUSEP = result[i++].Value?.ToString();

            return dta;
        }

    }
}