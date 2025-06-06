using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class VP0099B_CR_CERTIF_CANCEL : QueryBasis<VP0099B_CR_CERTIF_CANCEL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0099B_CR_CERTIF_CANCEL() { IsCursor = true; }

        public VP0099B_CR_CERTIF_CANCEL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string VG096_DTA_PROXIMA_COBRANCA { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }

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


        public override VP0099B_CR_CERTIF_CANCEL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0099B_CR_CERTIF_CANCEL();
            var i = 0;

            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG096_DTA_PROXIMA_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}