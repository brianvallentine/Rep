using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class AC0812B_V1COSGHISTP : QueryBasis<AC0812B_V1COSGHISTP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0812B_V1COSGHISTP() { IsCursor = true; }

        public AC0812B_V1COSGHISTP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1CHIS_COD_EMPR { get; set; }
        public string V1CHIS_CONGENER { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_NUM_ENDS { get; set; }
        public string V1CHIS_NRPARCEL { get; set; }
        public string V1CHIS_OCORHIST { get; set; }
        public string V1CHIS_OPERACAO { get; set; }
        public string V1CHIS_TIP_SEGU { get; set; }
        public string V1CHIS_PRM_TARF { get; set; }
        public string V1CHIS_VAL_DESC { get; set; }
        public string V1CHIS_VLPRMLIQ { get; set; }
        public string V1CHIS_VLADIFRA { get; set; }
        public string V1CHIS_VLCOMISS { get; set; }
        public string V1CHIS_VLPRMTOT { get; set; }
        public string V1CHIS_DAT_MOVT { get; set; }
        public string V1CHIS_DTQITBCO { get; set; }
        public string VIND_DAT_QTBC { get; set; }
        public string V1CHIS_NUM_OCOR { get; set; }
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


        public override AC0812B_V1COSGHISTP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0812B_V1COSGHISTP();
            var i = 0;

            dta.V1CHIS_COD_EMPR = result[i++].Value?.ToString();
            dta.V1CHIS_CONGENER = result[i++].Value?.ToString();
            dta.V1CHIS_NUM_APOL = result[i++].Value?.ToString();
            dta.V1CHIS_NUM_ENDS = result[i++].Value?.ToString();
            dta.V1CHIS_NRPARCEL = result[i++].Value?.ToString();
            dta.V1CHIS_OCORHIST = result[i++].Value?.ToString();
            dta.V1CHIS_OPERACAO = result[i++].Value?.ToString();
            dta.V1CHIS_TIP_SEGU = result[i++].Value?.ToString();
            dta.V1CHIS_PRM_TARF = result[i++].Value?.ToString();
            dta.V1CHIS_VAL_DESC = result[i++].Value?.ToString();
            dta.V1CHIS_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1CHIS_VLADIFRA = result[i++].Value?.ToString();
            dta.V1CHIS_VLCOMISS = result[i++].Value?.ToString();
            dta.V1CHIS_VLPRMTOT = result[i++].Value?.ToString();
            dta.V1CHIS_DAT_MOVT = result[i++].Value?.ToString();
            dta.V1CHIS_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DAT_QTBC = string.IsNullOrWhiteSpace(dta.V1CHIS_DTQITBCO) ? "-1" : "0";
            dta.V1CHIS_NUM_OCOR = result[i++].Value?.ToString();
            dta.VIND_NUM_OCOR = string.IsNullOrWhiteSpace(dta.V1CHIS_NUM_OCOR) ? "-1" : "0";

            return dta;
        }

    }
}