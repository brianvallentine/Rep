using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105B
{
    public class VG0105B_MOVIMENTO : QueryBasis<VG0105B_MOVIMENTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0105B_MOVIMENTO() { IsCursor = true; }

        public VG0105B_MOVIMENTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MOVI_MORNATU_ANT { get; set; }
        public string V0MOVI_MORNATU_ATU { get; set; }
        public string V0MOVI_MORACID_ANT { get; set; }
        public string V0MOVI_MORACID_ATU { get; set; }
        public string V0MOVI_INVPERM_ANT { get; set; }
        public string V0MOVI_INVPERM_ATU { get; set; }
        public string V0MOVI_AMDS_ANT { get; set; }
        public string V0MOVI_AMDS_ATU { get; set; }
        public string V0MOVI_DH_ANT { get; set; }
        public string V0MOVI_DH_ATU { get; set; }
        public string V0MOVI_DIT_ANT { get; set; }
        public string V0MOVI_DIT_ATU { get; set; }
        public string V0MOVI_VG_ANT { get; set; }
        public string V0MOVI_VG_ATU { get; set; }
        public string V0MOVI_AP_ANT { get; set; }
        public string V0MOVI_AP_ATU { get; set; }
        public string V0MOVI_COD_OPER { get; set; }
        public string V0MOVI_DATA_MOVI { get; set; }

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


        public override VG0105B_MOVIMENTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0105B_MOVIMENTO();
            var i = 0;

            dta.V0MOVI_MORNATU_ANT = result[i++].Value?.ToString();
            dta.V0MOVI_MORNATU_ATU = result[i++].Value?.ToString();
            dta.V0MOVI_MORACID_ANT = result[i++].Value?.ToString();
            dta.V0MOVI_MORACID_ATU = result[i++].Value?.ToString();
            dta.V0MOVI_INVPERM_ANT = result[i++].Value?.ToString();
            dta.V0MOVI_INVPERM_ATU = result[i++].Value?.ToString();
            dta.V0MOVI_AMDS_ANT = result[i++].Value?.ToString();
            dta.V0MOVI_AMDS_ATU = result[i++].Value?.ToString();
            dta.V0MOVI_DH_ANT = result[i++].Value?.ToString();
            dta.V0MOVI_DH_ATU = result[i++].Value?.ToString();
            dta.V0MOVI_DIT_ANT = result[i++].Value?.ToString();
            dta.V0MOVI_DIT_ATU = result[i++].Value?.ToString();
            dta.V0MOVI_VG_ANT = result[i++].Value?.ToString();
            dta.V0MOVI_VG_ATU = result[i++].Value?.ToString();
            dta.V0MOVI_AP_ANT = result[i++].Value?.ToString();
            dta.V0MOVI_AP_ATU = result[i++].Value?.ToString();
            dta.V0MOVI_COD_OPER = result[i++].Value?.ToString();
            dta.V0MOVI_DATA_MOVI = result[i++].Value?.ToString();

            return dta;
        }

    }
}