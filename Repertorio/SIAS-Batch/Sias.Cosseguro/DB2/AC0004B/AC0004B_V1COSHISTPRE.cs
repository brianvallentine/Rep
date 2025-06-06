using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class AC0004B_V1COSHISTPRE : QueryBasis<AC0004B_V1COSHISTPRE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0004B_V1COSHISTPRE() { IsCursor = true; }

        public AC0004B_V1COSHISTPRE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1CHSP_COD_EMPR { get; set; }
        public string V1CHSP_CONGENER { get; set; }
        public string V1CHSP_NUM_APOL { get; set; }
        public string V1CHSP_NRENDOS { get; set; }
        public string V1CHSP_NRPARCEL { get; set; }
        public string V1CHSP_OCORHIST { get; set; }
        public string V1CHSP_OPERACAO { get; set; }
        public string V1CHSP_DTMOVTO { get; set; }
        public string V1CHSP_TIPSGU { get; set; }
        public string V1CHSP_PRM_TAR { get; set; }
        public string V1CHSP_VAL_DESC { get; set; }
        public string V1CHSP_VLPRMLIQ { get; set; }
        public string V1CHSP_VLADIFRA { get; set; }
        public string V1CHSP_VLCOMIS { get; set; }
        public string V1CHSP_VLPRMTOT { get; set; }
        public string V1CHSP_DTQITBCO { get; set; }
        public string VIND_DAT_QTBC { get; set; }
        public string V1CHSP_SIT_FINANC { get; set; }
        public string VIND_SIT_FINC { get; set; }
        public string V1CHSP_SIT_LIBREC { get; set; }
        public string VIND_SIT_LIBR { get; set; }
        public string V1CHSP_NUMOCOR { get; set; }
        public string VIND_NUM_OCOR { get; set; }

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


        public override AC0004B_V1COSHISTPRE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0004B_V1COSHISTPRE();
            var i = 0;

            dta.V1CHSP_COD_EMPR = result[i++].Value?.ToString();
            dta.V1CHSP_CONGENER = result[i++].Value?.ToString();
            dta.V1CHSP_NUM_APOL = result[i++].Value?.ToString();
            dta.V1CHSP_NRENDOS = result[i++].Value?.ToString();
            dta.V1CHSP_NRPARCEL = result[i++].Value?.ToString();
            dta.V1CHSP_OCORHIST = result[i++].Value?.ToString();
            dta.V1CHSP_OPERACAO = result[i++].Value?.ToString();
            dta.V1CHSP_DTMOVTO = result[i++].Value?.ToString();
            dta.V1CHSP_TIPSGU = result[i++].Value?.ToString();
            dta.V1CHSP_PRM_TAR = result[i++].Value?.ToString();
            dta.V1CHSP_VAL_DESC = result[i++].Value?.ToString();
            dta.V1CHSP_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1CHSP_VLADIFRA = result[i++].Value?.ToString();
            dta.V1CHSP_VLCOMIS = result[i++].Value?.ToString();
            dta.V1CHSP_VLPRMTOT = result[i++].Value?.ToString();
            dta.V1CHSP_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DAT_QTBC = string.IsNullOrWhiteSpace(dta.V1CHSP_DTQITBCO) ? "-1" : "0";
            dta.V1CHSP_SIT_FINANC = result[i++].Value?.ToString();
            dta.VIND_SIT_FINC = string.IsNullOrWhiteSpace(dta.V1CHSP_SIT_FINANC) ? "-1" : "0";
            dta.V1CHSP_SIT_LIBREC = result[i++].Value?.ToString();
            dta.VIND_SIT_LIBR = string.IsNullOrWhiteSpace(dta.V1CHSP_SIT_LIBREC) ? "-1" : "0";
            dta.V1CHSP_NUMOCOR = result[i++].Value?.ToString();
            dta.VIND_NUM_OCOR = string.IsNullOrWhiteSpace(dta.V1CHSP_NUMOCOR) ? "-1" : "0";

            return dta;
        }

    }
}