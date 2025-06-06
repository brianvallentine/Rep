using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0282B
{
    public class VG0282B_V1RELATORIOS : QueryBasis<VG0282B_V1RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0282B_V1RELATORIOS() { IsCursor = true; }

        public VG0282B_V1RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1RELA_NUM_APOL { get; set; }
        public string V1RELA_CODSUBES { get; set; }
        public string V1RELA_CODUNIMO { get; set; }
        public string V1RELA_PERI_INI { get; set; }
        public string V1RELA_PERI_FIN { get; set; }

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


        public override VG0282B_V1RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0282B_V1RELATORIOS();
            var i = 0;

            dta.V1RELA_NUM_APOL = result[i++].Value?.ToString();
            dta.V1RELA_CODSUBES = result[i++].Value?.ToString();
            dta.V1RELA_CODUNIMO = result[i++].Value?.ToString();
            dta.V1RELA_PERI_INI = result[i++].Value?.ToString();
            dta.V1RELA_PERI_FIN = result[i++].Value?.ToString();

            return dta;
        }

    }
}