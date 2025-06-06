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
    public class VG0100B_V1SUBGRUPO : QueryBasis<VG0100B_V1SUBGRUPO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0100B_V1SUBGRUPO() { IsCursor = true; }

        public VG0100B_V1SUBGRUPO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1SUBG_TIPO_FAT { get; set; }
        public string V1SUBG_NUM_APOL { get; set; }
        public string V1SUBG_COD_SUBG { get; set; }
        public string V1SUBG_COD_FONTE { get; set; }
        public string V1SUBG_BCO_COB { get; set; }
        public string V1SUBG_AGE_COB { get; set; }
        public string V1SUBG_DAC_COB { get; set; }
        public string V1SUBG_END_COB { get; set; }
        public string V1SUBG_PERI_FATUR { get; set; }
        public string V1SUBG_IND_IOF { get; set; }

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


        public override VG0100B_V1SUBGRUPO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0100B_V1SUBGRUPO();
            var i = 0;

            dta.V1SUBG_TIPO_FAT = result[i++].Value?.ToString();
            dta.V1SUBG_NUM_APOL = result[i++].Value?.ToString();
            dta.V1SUBG_COD_SUBG = result[i++].Value?.ToString();
            dta.V1SUBG_COD_FONTE = result[i++].Value?.ToString();
            dta.V1SUBG_BCO_COB = result[i++].Value?.ToString();
            dta.V1SUBG_AGE_COB = result[i++].Value?.ToString();
            dta.V1SUBG_DAC_COB = result[i++].Value?.ToString();
            dta.V1SUBG_END_COB = result[i++].Value?.ToString();
            dta.V1SUBG_PERI_FATUR = result[i++].Value?.ToString();
            dta.V1SUBG_IND_IOF = result[i++].Value?.ToString();

            return dta;
        }

    }
}