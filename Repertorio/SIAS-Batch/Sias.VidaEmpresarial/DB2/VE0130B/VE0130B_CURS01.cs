using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0130B
{
    public class VE0130B_CURS01 : QueryBasis<VE0130B_CURS01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0130B_CURS01() { IsCursor = true; }

        public VE0130B_CURS01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_DATA_VENCIMENTO { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_NUM_PROPOSTA { get; set; }
        public string PROPOVA_STA_MUDANCA_PLANO { get; set; }
        public string WS_DTPROXVEN_1D { get; set; }
        public string WS_DTQUITACAO_1D { get; set; }
        public string WS_DTPROXVEN_YEAR { get; set; }
        public string WS_DTPROXVEN_MONTH { get; set; }

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


        public override VE0130B_CURS01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0130B_CURS01();
            var i = 0;

            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPOVA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PROPOVA_DTPROXVEN = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOVA_STA_MUDANCA_PLANO = result[i++].Value?.ToString();
            dta.WS_DTPROXVEN_1D = result[i++].Value?.ToString();
            dta.WS_DTQUITACAO_1D = result[i++].Value?.ToString();
            dta.WS_DTPROXVEN_YEAR = result[i++].Value?.ToString();
            dta.WS_DTPROXVEN_MONTH = result[i++].Value?.ToString();

            return dta;
        }

    }
}