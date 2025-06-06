using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class EM0030B_V0ENDOS : QueryBasis<EM0030B_V0ENDOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0030B_V0ENDOS() { IsCursor = true; }

        public EM0030B_V0ENDOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }
        public string ENDO_CODSUBES { get; set; }
        public string ENDO_FONTE { get; set; }
        public string ENDO_NRPROPOS { get; set; }
        public string ENDO_ORGAO { get; set; }
        public string ENDO_RAMO { get; set; }
        public string ENDO_DATPRO { get; set; }
        public string ENDO_DT_LIBERACAO { get; set; }
        public string ENDO_DTEMIS { get; set; }
        public string ENDO_DTINIVIG { get; set; }
        public string ENDO_DTTERVIG { get; set; }
        public string ENDO_PCENTRAD { get; set; }
        public string ENDO_PCADICIO { get; set; }
        public string ENDO_PCDESCON { get; set; }
        public string ENDO_PRESTA1 { get; set; }
        public string ENDO_QTPARCEL { get; set; }
        public string ENDO_COD_MOEDA_PRM { get; set; }
        public string ENDO_NRRCAP { get; set; }
        public string ENDO_VLRCAP { get; set; }
        public string ENDO_DATARCAP { get; set; }
        public string ENDO_DATARCAP_I { get; set; }
        public string ENDO_TIPO_ENDOSSO { get; set; }
        public string ENDO_BCORCAP { get; set; }
        public string ENDO_AGERCAP { get; set; }
        public string ENDO_BCOCOBR { get; set; }
        public string ENDO_AGECOBR { get; set; }
        public string ENDO_ISENTA_CUSTO { get; set; }
        public string ENDO_ISECUSTO_I { get; set; }
        public string ENDO_TIPO_APOL { get; set; }
        public string ENDO_QTITENS { get; set; }
        public string ENDO_CORRECAO { get; set; }
        public string ENDO_DTVENCTO { get; set; }
        public string VIND_DTVENCTO { get; set; }
        public string ENDO_NUMBIL { get; set; }
        public string ENDO_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string ENDO_PODPUBL { get; set; }
        public string ENDO_TIPSEGU { get; set; }
        public string ENDO_VLCUSEMI { get; set; }
        public string VIND_VLCUSEMI { get; set; }
        public string ENDO_COD_USUARIO { get; set; }
        public string ENDO_CFPREFIX { get; set; }
        public string VIND_CFPREFIX { get; set; }
        public string ENDO_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPRESA { get; set; }

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


        public override EM0030B_V0ENDOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0030B_V0ENDOS();
            var i = 0;

            dta.ENDO_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ENDO_NRENDOS = result[i++].Value?.ToString();
            dta.ENDO_CODSUBES = result[i++].Value?.ToString();
            dta.ENDO_FONTE = result[i++].Value?.ToString();
            dta.ENDO_NRPROPOS = result[i++].Value?.ToString();
            dta.ENDO_ORGAO = result[i++].Value?.ToString();
            dta.ENDO_RAMO = result[i++].Value?.ToString();
            dta.ENDO_DATPRO = result[i++].Value?.ToString();
            dta.ENDO_DT_LIBERACAO = result[i++].Value?.ToString();
            dta.ENDO_DTEMIS = result[i++].Value?.ToString();
            dta.ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.ENDO_DTTERVIG = result[i++].Value?.ToString();
            dta.ENDO_PCENTRAD = result[i++].Value?.ToString();
            dta.ENDO_PCADICIO = result[i++].Value?.ToString();
            dta.ENDO_PCDESCON = result[i++].Value?.ToString();
            dta.ENDO_PRESTA1 = result[i++].Value?.ToString();
            dta.ENDO_QTPARCEL = result[i++].Value?.ToString();
            dta.ENDO_COD_MOEDA_PRM = result[i++].Value?.ToString();
            dta.ENDO_NRRCAP = result[i++].Value?.ToString();
            dta.ENDO_VLRCAP = result[i++].Value?.ToString();
            dta.ENDO_DATARCAP = result[i++].Value?.ToString();
            dta.ENDO_DATARCAP_I = string.IsNullOrWhiteSpace(dta.ENDO_DATARCAP) ? "-1" : "0";
            dta.ENDO_TIPO_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDO_BCORCAP = result[i++].Value?.ToString();
            dta.ENDO_AGERCAP = result[i++].Value?.ToString();
            dta.ENDO_BCOCOBR = result[i++].Value?.ToString();
            dta.ENDO_AGECOBR = result[i++].Value?.ToString();
            dta.ENDO_ISENTA_CUSTO = result[i++].Value?.ToString();
            dta.ENDO_ISECUSTO_I = string.IsNullOrWhiteSpace(dta.ENDO_ISENTA_CUSTO) ? "-1" : "0";
            dta.ENDO_TIPO_APOL = result[i++].Value?.ToString();
            dta.ENDO_QTITENS = result[i++].Value?.ToString();
            dta.ENDO_CORRECAO = result[i++].Value?.ToString();
            dta.ENDO_DTVENCTO = result[i++].Value?.ToString();
            dta.VIND_DTVENCTO = string.IsNullOrWhiteSpace(dta.ENDO_DTVENCTO) ? "-1" : "0";
            dta.ENDO_NUMBIL = result[i++].Value?.ToString();
            dta.ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.ENDO_CODPRODU) ? "-1" : "0";
            dta.ENDO_PODPUBL = result[i++].Value?.ToString();
            dta.ENDO_TIPSEGU = result[i++].Value?.ToString();
            dta.ENDO_VLCUSEMI = result[i++].Value?.ToString();
            dta.VIND_VLCUSEMI = string.IsNullOrWhiteSpace(dta.ENDO_VLCUSEMI) ? "-1" : "0";
            dta.ENDO_COD_USUARIO = result[i++].Value?.ToString();
            dta.ENDO_CFPREFIX = result[i++].Value?.ToString();
            dta.VIND_CFPREFIX = string.IsNullOrWhiteSpace(dta.ENDO_CFPREFIX) ? "-1" : "0";
            dta.ENDO_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMPRESA = string.IsNullOrWhiteSpace(dta.ENDO_COD_EMPRESA) ? "-1" : "0";

            return dta;
        }

    }
}