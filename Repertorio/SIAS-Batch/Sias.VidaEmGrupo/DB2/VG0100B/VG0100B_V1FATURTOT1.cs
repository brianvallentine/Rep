using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class VG0100B_V1FATURTOT1 : QueryBasis<VG0100B_V1FATURTOT1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0100B_V1FATURTOT1() { IsCursor = true; }

        public VG0100B_V1FATURTOT1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1FATT_NUM_APOL { get; set; }
        public string V1FATT_COD_SUBG { get; set; }
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
        public string V1FATT_SIT_REG { get; set; }
        public string V1FATT_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }

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


        public override VG0100B_V1FATURTOT1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0100B_V1FATURTOT1();
            var i = 0;

            dta.V1FATT_NUM_APOL = result[i++].Value?.ToString();
            dta.V1FATT_COD_SUBG = result[i++].Value?.ToString();
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
            dta.V1FATT_SIT_REG = result[i++].Value?.ToString();
            dta.V1FATT_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMP = string.IsNullOrWhiteSpace(dta.V1FATT_COD_EMPRESA) ? "-1" : "0";

            return dta;
        }

    }
}