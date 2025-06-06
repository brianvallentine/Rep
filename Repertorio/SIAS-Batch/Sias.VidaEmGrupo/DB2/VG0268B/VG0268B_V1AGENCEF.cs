using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0268B
{
    public class VG0268B_V1AGENCEF : QueryBasis<VG0268B_V1AGENCEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0268B_V1AGENCEF() { IsCursor = true; }

        public VG0268B_V1AGENCEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1MCEF_COD_FONTE { get; set; }
        public string V1FONT_NOMEFTE { get; set; }
        public string V1FONT_ENDERFTE { get; set; }
        public string V1FONT_BAIRRO { get; set; }
        public string V1FONT_CIDADE { get; set; }
        public string V1FONT_CEP { get; set; }
        public string V1FONT_UF { get; set; }

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


        public override VG0268B_V1AGENCEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0268B_V1AGENCEF();
            var i = 0;

            dta.V1MCEF_COD_FONTE = result[i++].Value?.ToString();
            dta.V1FONT_NOMEFTE = result[i++].Value?.ToString();
            dta.V1FONT_ENDERFTE = result[i++].Value?.ToString();
            dta.V1FONT_BAIRRO = result[i++].Value?.ToString();
            dta.V1FONT_CIDADE = result[i++].Value?.ToString();
            dta.V1FONT_CEP = result[i++].Value?.ToString();
            dta.V1FONT_UF = result[i++].Value?.ToString();

            return dta;
        }

    }
}