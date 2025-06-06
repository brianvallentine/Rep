using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class VG0031B_V1ENDOSSO : QueryBasis<VG0031B_V1ENDOSSO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0031B_V1ENDOSSO() { IsCursor = true; }

        public VG0031B_V1ENDOSSO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1ENDO_NUM_APOL { get; set; }
        public string V1ENDO_NRENDOS { get; set; }
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


        public override VG0031B_V1ENDOSSO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0031B_V1ENDOSSO();
            var i = 0;

            dta.V1ENDO_NUM_APOL = result[i++].Value?.ToString();
            dta.V1ENDO_NRENDOS = result[i++].Value?.ToString();
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

            return dta;
        }

    }
}