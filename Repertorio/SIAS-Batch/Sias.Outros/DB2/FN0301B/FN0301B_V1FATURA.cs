using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class FN0301B_V1FATURA : QueryBasis<FN0301B_V1FATURA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FN0301B_V1FATURA() { IsCursor = true; }

        public FN0301B_V1FATURA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1FATT_NUMAPOL { get; set; }
        public string V1FATT_CODSUBES { get; set; }
        public string V1FATT_NUM_FATUR { get; set; }
        public string V1FATT_COD_OPER { get; set; }
        public string V1FATT_QT_VIDA_VG { get; set; }
        public string V1FATT_QT_VIDA_AP { get; set; }
        public string V1FATT_IMP_MORNAT { get; set; }
        public string V1FATT_IMP_MORACI { get; set; }
        public string V1FATT_IMP_INVPER { get; set; }
        public string V1FATT_IMP_AMDS { get; set; }
        public string V1FATT_IMP_DH { get; set; }
        public string V1FATT_IMP_DIT { get; set; }
        public string V1FATT_PRM_VG { get; set; }
        public string V1FATT_PRM_AP { get; set; }

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


        public override FN0301B_V1FATURA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FN0301B_V1FATURA();
            var i = 0;

            dta.V1FATT_NUMAPOL = result[i++].Value?.ToString();
            dta.V1FATT_CODSUBES = result[i++].Value?.ToString();
            dta.V1FATT_NUM_FATUR = result[i++].Value?.ToString();
            dta.V1FATT_COD_OPER = result[i++].Value?.ToString();
            dta.V1FATT_QT_VIDA_VG = result[i++].Value?.ToString();
            dta.V1FATT_QT_VIDA_AP = result[i++].Value?.ToString();
            dta.V1FATT_IMP_MORNAT = result[i++].Value?.ToString();
            dta.V1FATT_IMP_MORACI = result[i++].Value?.ToString();
            dta.V1FATT_IMP_INVPER = result[i++].Value?.ToString();
            dta.V1FATT_IMP_AMDS = result[i++].Value?.ToString();
            dta.V1FATT_IMP_DH = result[i++].Value?.ToString();
            dta.V1FATT_IMP_DIT = result[i++].Value?.ToString();
            dta.V1FATT_PRM_VG = result[i++].Value?.ToString();
            dta.V1FATT_PRM_AP = result[i++].Value?.ToString();

            return dta;
        }

    }
}