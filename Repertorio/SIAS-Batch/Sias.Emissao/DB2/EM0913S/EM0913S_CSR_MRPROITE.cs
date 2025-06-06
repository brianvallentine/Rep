using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0913S
{
    public class EM0913S_CSR_MRPROITE : QueryBasis<EM0913S_CSR_MRPROITE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0913S_CSR_MRPROITE() { IsCursor = true; }

        public EM0913S_CSR_MRPROITE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MRPROITE_NUM_ITEM { get; set; }
        public string MRPROITE_COD_PRODUTO { get; set; }
        public string MRPROITE_NUM_VERSAO { get; set; }
        public string MRPROITE_NUM_TP_MORA_IMOVEL { get; set; }
        public string MRPROITE_NUM_TP_OCUP_IMOVEL { get; set; }
        public string MRPROITE_DTH_INI_VIGENCIA { get; set; }
        public string MRPROITE_DTH_FIM_VIGENCIA { get; set; }
        public string MRPROITE_IND_TIPO_SEGURO { get; set; }
        public string MRPROITE_QTD_RENOVACAO { get; set; }
        public string MRPROITE_STA_PROPOSTA_ITEM { get; set; }
        public string MRPROITE_NUM_PROPOSTA_SIMU { get; set; }
        public string MRPROITE_OCORR_ENDERECO { get; set; }
        public string MRPROITE_PCT_DESC_FIDEL { get; set; }
        public string MRPROITE_PCT_DESC_AGRUP { get; set; }
        public string MRPROITE_PCT_DESC_EXPER { get; set; }
        public string MRPROITE_COD_CLIENTE { get; set; }
        public string MRPROITE_COD_BENEFICIARIO { get; set; }
        public string WNULL_COD_BENEF { get; set; }
        public string MRPROITE_IND_RENOVACAO_AUT { get; set; }

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


        public override EM0913S_CSR_MRPROITE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0913S_CSR_MRPROITE();
            var i = 0;

            dta.MRPROITE_NUM_ITEM = result[i++].Value?.ToString();
            dta.MRPROITE_COD_PRODUTO = result[i++].Value?.ToString();
            dta.MRPROITE_NUM_VERSAO = result[i++].Value?.ToString();
            dta.MRPROITE_NUM_TP_MORA_IMOVEL = result[i++].Value?.ToString();
            dta.MRPROITE_NUM_TP_OCUP_IMOVEL = result[i++].Value?.ToString();
            dta.MRPROITE_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.MRPROITE_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.MRPROITE_IND_TIPO_SEGURO = result[i++].Value?.ToString();
            dta.MRPROITE_QTD_RENOVACAO = result[i++].Value?.ToString();
            dta.MRPROITE_STA_PROPOSTA_ITEM = result[i++].Value?.ToString();
            dta.MRPROITE_NUM_PROPOSTA_SIMU = result[i++].Value?.ToString();
            dta.MRPROITE_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.MRPROITE_PCT_DESC_FIDEL = result[i++].Value?.ToString();
            dta.MRPROITE_PCT_DESC_AGRUP = result[i++].Value?.ToString();
            dta.MRPROITE_PCT_DESC_EXPER = result[i++].Value?.ToString();
            dta.MRPROITE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.MRPROITE_COD_BENEFICIARIO = result[i++].Value?.ToString();
            dta.WNULL_COD_BENEF = string.IsNullOrWhiteSpace(dta.MRPROITE_COD_BENEFICIARIO) ? "-1" : "0";
            dta.MRPROITE_IND_RENOVACAO_AUT = result[i++].Value?.ToString();

            return dta;
        }

    }
}