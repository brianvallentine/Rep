using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0781B
{
    public class VG0781B_ENDOSSO : QueryBasis<VG0781B_ENDOSSO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0781B_ENDOSSO() { IsCursor = true; }

        public VG0781B_ENDOSSO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0APOLICE_ENDOSSO { get; set; }
        public string V0ENDOPARC_DTINIVIG { get; set; }
        public string V0ENDOPARC_CODSUBES { get; set; }
        public string V0ENDOPARC_NRENDOS { get; set; }
        public string V0ENDOPARC_DTEMIS { get; set; }

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


        public override VG0781B_ENDOSSO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0781B_ENDOSSO();
            var i = 0;

            dta.V0APOLICE_ENDOSSO = result[i++].Value?.ToString();
            dta.V0ENDOPARC_DTINIVIG = result[i++].Value?.ToString();
            dta.V0ENDOPARC_CODSUBES = result[i++].Value?.ToString();
            dta.V0ENDOPARC_NRENDOS = result[i++].Value?.ToString();
            dta.V0ENDOPARC_DTEMIS = result[i++].Value?.ToString();

            return dta;
        }

    }
}