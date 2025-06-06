using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class VA0460B_V0HISTCOBVA : QueryBasis<VA0460B_V0HISTCOBVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0460B_V0HISTCOBVA() { IsCursor = true; }

        public VA0460B_V0HISTCOBVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string COBHISVI_NUM_CERTIFICADO { get; set; }
        public string COBHISVI_NUM_PARCELA { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string COBHISVI_PRM_TOTAL { get; set; }
        public string COBHISVI_OCORR_HISTORICO { get; set; }
        public string COBHISVI_COD_DEVOLUCAO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_COD_USUARIO { get; set; }
        public string PRODUVG_NUM_APOLICE { get; set; }
        public string PRODUVG_COD_SUBGRUPO { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_RAMO { get; set; }
        public string VIND_RAMO { get; set; }
        public string HISCONPA_PREMIO_VG { get; set; }
        public string HISCONPA_PREMIO_AP { get; set; }

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


        public override VA0460B_V0HISTCOBVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0460B_V0HISTCOBVA();
            var i = 0;

            dta.COBHISVI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.COBHISVI_NUM_PARCELA = result[i++].Value?.ToString();
            dta.COBHISVI_NUM_TITULO = result[i++].Value?.ToString();
            dta.COBHISVI_PRM_TOTAL = result[i++].Value?.ToString();
            dta.COBHISVI_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.COBHISVI_COD_DEVOLUCAO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_USUARIO = result[i++].Value?.ToString();
            dta.PRODUVG_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PRODUVG_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_RAMO = result[i++].Value?.ToString();
            dta.VIND_RAMO = string.IsNullOrWhiteSpace(dta.PRODUVG_RAMO) ? "-1" : "0";
            dta.HISCONPA_PREMIO_VG = result[i++].Value?.ToString();
            dta.HISCONPA_PREMIO_AP = result[i++].Value?.ToString();

            return dta;
        }

    }
}