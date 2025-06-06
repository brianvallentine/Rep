using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP15B
{
    public class SISAP15B_IMPOSTOS : QueryBasis<SISAP15B_IMPOSTOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SISAP15B_IMPOSTOS() { IsCursor = true; }

        public SISAP15B_IMPOSTOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SIPADOFI_NUM_DOCF_INTERNO { get; set; }
        public string FIPADOLA_COD_TP_LANCDOCF { get; set; }
        public string GETPLADO_ABREV_LANCDOCF { get; set; }
        public string FIPADOLA_VALOR_LANCAMENTO { get; set; }
        public string GETIPIMP_COD_IMP_INTERNO { get; set; }
        public string GETIPIMP_SIGLA_IMP { get; set; }
        public string FIPADOIM_ALIQ_TRIBUTACAO { get; set; }
        public string FIPADOIM_VALOR_IMPOSTO { get; set; }
        public string FIPADOFI_NUM_DOC_FISCAL { get; set; }
        public string NULL_NUM_DOC_FISCAL { get; set; }
        public string FIPADOFI_SERIE_DOC_FISCAL { get; set; }
        public string NULL_SERIE_DOC_FISCAL { get; set; }
        public string FIPADOFI_DATA_EMISSAO_DOC { get; set; }
        public string NULL_DATA_EMISSAO_DOC { get; set; }

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


        public override SISAP15B_IMPOSTOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SISAP15B_IMPOSTOS();
            var i = 0;

            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SIPADOFI_NUM_DOCF_INTERNO = result[i++].Value?.ToString();
            dta.FIPADOLA_COD_TP_LANCDOCF = result[i++].Value?.ToString();
            dta.GETPLADO_ABREV_LANCDOCF = result[i++].Value?.ToString();
            dta.FIPADOLA_VALOR_LANCAMENTO = result[i++].Value?.ToString();
            dta.GETIPIMP_COD_IMP_INTERNO = result[i++].Value?.ToString();
            dta.GETIPIMP_SIGLA_IMP = result[i++].Value?.ToString();
            dta.FIPADOIM_ALIQ_TRIBUTACAO = result[i++].Value?.ToString();
            dta.FIPADOIM_VALOR_IMPOSTO = result[i++].Value?.ToString();
            dta.FIPADOFI_NUM_DOC_FISCAL = result[i++].Value?.ToString();
            dta.NULL_NUM_DOC_FISCAL = string.IsNullOrWhiteSpace(dta.FIPADOFI_NUM_DOC_FISCAL) ? "-1" : "0";
            dta.FIPADOFI_SERIE_DOC_FISCAL = result[i++].Value?.ToString();
            dta.NULL_SERIE_DOC_FISCAL = string.IsNullOrWhiteSpace(dta.FIPADOFI_SERIE_DOC_FISCAL) ? "-1" : "0";
            dta.FIPADOFI_DATA_EMISSAO_DOC = result[i++].Value?.ToString();
            dta.NULL_DATA_EMISSAO_DOC = string.IsNullOrWhiteSpace(dta.FIPADOFI_DATA_EMISSAO_DOC) ? "-1" : "0";

            return dta;
        }

    }
}