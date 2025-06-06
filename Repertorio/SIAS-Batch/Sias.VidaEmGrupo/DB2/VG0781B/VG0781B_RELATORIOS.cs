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
    public class VG0781B_RELATORIOS : QueryBasis<VG0781B_RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0781B_RELATORIOS() { IsCursor = true; }

        public VG0781B_RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1RELATORIOS_DATA1 { get; set; }
        public string V1RELATORIOS_DATA2 { get; set; }
        public string V1RELATORIOS_APOLICE { get; set; }
        public string V1RELATORIOS_CODSUBES1 { get; set; }

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


        public override VG0781B_RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0781B_RELATORIOS();
            var i = 0;

            dta.V1RELATORIOS_DATA1 = result[i++].Value?.ToString();
            dta.V1RELATORIOS_DATA2 = result[i++].Value?.ToString();
            dta.V1RELATORIOS_APOLICE = result[i++].Value?.ToString();
            dta.V1RELATORIOS_CODSUBES1 = result[i++].Value?.ToString();

            return dta;
        }

    }
}