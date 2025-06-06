using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class VG0816B_CDIFPA : QueryBasis<VG0816B_CDIFPA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0816B_CDIFPA() { IsCursor = true; }

        public VG0816B_CDIFPA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0DIFPA_NRPARCELDIF { get; set; }
        public string V0DIFPA_DTVENCTO { get; set; }

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


        public override VG0816B_CDIFPA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0816B_CDIFPA();
            var i = 0;

            dta.V0DIFPA_NRPARCELDIF = result[i++].Value?.ToString();
            dta.V0DIFPA_DTVENCTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}