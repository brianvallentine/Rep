using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class EM0120B_V1PARCELA : QueryBasis<EM0120B_V1PARCELA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0120B_V1PARCELA() { IsCursor = true; }

        public EM0120B_V1PARCELA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_DACPARC { get; set; }
        public string V1PARC_FONTE { get; set; }
        public string V1PARC_NRTIT { get; set; }
        public string V1PARC_OCORHIST { get; set; }
        public string V1PARC_QTDDOC { get; set; }
        public string V1PARC_SITUACAO { get; set; }
        public string V1PARC_COD_EMP { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V1ENDO_DTEMIS { get; set; }
        public string V1ENDO_DTINIVIG { get; set; }
        public string V1ENDO_DTTERVIG { get; set; }
        public string V1ENDO_BCORCAP { get; set; }
        public string V1ENDO_AGERCAP { get; set; }
        public string V1ENDO_DACRCAP { get; set; }
        public string V1ENDO_BCOCOBR { get; set; }
        public string V1ENDO_AGECOBR { get; set; }
        public string V1ENDO_DACCOBR { get; set; }
        public string V1ENDO_QTPARCEL { get; set; }
        public string V1ENDO_ORGAO { get; set; }
        public string V1ENDO_RAMO { get; set; }
        public string V1ENDO_CODPRODU { get; set; }
        public string VIND_COD_PRODU { get; set; }
        public string V1HISP_PRM_TAR { get; set; }
        public string V1HISP_VAL_DESC { get; set; }
        public string V1HISP_VLPRMLIQ { get; set; }
        public string V1HISP_VLADIFRA { get; set; }
        public string V1HISP_VLCUSEMI { get; set; }
        public string V1HISP_VLIOCC { get; set; }
        public string V1HISP_VLPRMTOT { get; set; }
        public string V1HISP_VLPREMIO { get; set; }
        public string V1HISP_DTVENCTO { get; set; }

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


        public override EM0120B_V1PARCELA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0120B_V1PARCELA();
            var i = 0;

            dta.V1PARC_NUM_APOL = result[i++].Value?.ToString();
            dta.V1PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V1PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V1PARC_DACPARC = result[i++].Value?.ToString();
            dta.V1PARC_FONTE = result[i++].Value?.ToString();
            dta.V1PARC_NRTIT = result[i++].Value?.ToString();
            dta.V1PARC_OCORHIST = result[i++].Value?.ToString();
            dta.V1PARC_QTDDOC = result[i++].Value?.ToString();
            dta.V1PARC_SITUACAO = result[i++].Value?.ToString();
            dta.V1PARC_COD_EMP = result[i++].Value?.ToString();
            dta.VIND_COD_EMP = string.IsNullOrWhiteSpace(dta.V1PARC_COD_EMP) ? "-1" : "0";
            dta.V1ENDO_DTEMIS = result[i++].Value?.ToString();
            dta.V1ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V1ENDO_DTTERVIG = result[i++].Value?.ToString();
            dta.V1ENDO_BCORCAP = result[i++].Value?.ToString();
            dta.V1ENDO_AGERCAP = result[i++].Value?.ToString();
            dta.V1ENDO_DACRCAP = result[i++].Value?.ToString();
            dta.V1ENDO_BCOCOBR = result[i++].Value?.ToString();
            dta.V1ENDO_AGECOBR = result[i++].Value?.ToString();
            dta.V1ENDO_DACCOBR = result[i++].Value?.ToString();
            dta.V1ENDO_QTPARCEL = result[i++].Value?.ToString();
            dta.V1ENDO_ORGAO = result[i++].Value?.ToString();
            dta.V1ENDO_RAMO = result[i++].Value?.ToString();
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_COD_PRODU = string.IsNullOrWhiteSpace(dta.V1ENDO_CODPRODU) ? "-1" : "0";
            dta.V1HISP_PRM_TAR = result[i++].Value?.ToString();
            dta.V1HISP_VAL_DESC = result[i++].Value?.ToString();
            dta.V1HISP_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1HISP_VLADIFRA = result[i++].Value?.ToString();
            dta.V1HISP_VLCUSEMI = result[i++].Value?.ToString();
            dta.V1HISP_VLIOCC = result[i++].Value?.ToString();
            dta.V1HISP_VLPRMTOT = result[i++].Value?.ToString();
            dta.V1HISP_VLPREMIO = result[i++].Value?.ToString();
            dta.V1HISP_DTVENCTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}