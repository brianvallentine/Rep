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
    public class VG0100B_V1SOLICFAT : QueryBasis<VG0100B_V1SOLICFAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0100B_V1SOLICFAT() { IsCursor = true; }

        public VG0100B_V1SOLICFAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1SOLF_NUM_APOL { get; set; }
        public string V1SOLF_COD_SUBG { get; set; }
        public string V1SOLF_NUM_FAT { get; set; }
        public string V1SOLF_NUM_RCAP { get; set; }
        public string V1SOLF_VAL_RCAP { get; set; }
        public string V1SOLF_COD_OPER { get; set; }
        public string V1SOLF_SIT_REG { get; set; }
        public string V1SOLF_DATA_RCAP { get; set; }
        public string V1SOLF_DATA_RCAP_I { get; set; }
        public string V1SOLF_DATA_VENC { get; set; }
        public string V1SOLF_DATA_VENC_I { get; set; }
        public string V1SOLF_DATA_SOLI { get; set; }
        public string V1SOLF_DATA_SOLI_I { get; set; }
        public string V1SOLF_COD_USUAR { get; set; }

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


        public override VG0100B_V1SOLICFAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0100B_V1SOLICFAT();
            var i = 0;

            dta.V1SOLF_NUM_APOL = result[i++].Value?.ToString();
            dta.V1SOLF_COD_SUBG = result[i++].Value?.ToString();
            dta.V1SOLF_NUM_FAT = result[i++].Value?.ToString();
            dta.V1SOLF_NUM_RCAP = result[i++].Value?.ToString();
            dta.V1SOLF_VAL_RCAP = result[i++].Value?.ToString();
            dta.V1SOLF_COD_OPER = result[i++].Value?.ToString();
            dta.V1SOLF_SIT_REG = result[i++].Value?.ToString();
            dta.V1SOLF_DATA_RCAP = result[i++].Value?.ToString();
            dta.V1SOLF_DATA_RCAP_I = string.IsNullOrWhiteSpace(dta.V1SOLF_DATA_RCAP) ? "-1" : "0";
            dta.V1SOLF_DATA_VENC = result[i++].Value?.ToString();
            dta.V1SOLF_DATA_VENC_I = string.IsNullOrWhiteSpace(dta.V1SOLF_DATA_VENC) ? "-1" : "0";
            dta.V1SOLF_DATA_SOLI = result[i++].Value?.ToString();
            dta.V1SOLF_DATA_SOLI_I = string.IsNullOrWhiteSpace(dta.V1SOLF_DATA_SOLI) ? "-1" : "0";
            dta.V1SOLF_COD_USUAR = result[i++].Value?.ToString();

            return dta;
        }

    }
}