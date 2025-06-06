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
    public class VG0816B_CPLCOM : QueryBasis<VG0816B_CPLCOM>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0816B_CPLCOM() { IsCursor = true; }

        public VG0816B_CPLCOM(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PLCO_CODPDT { get; set; }

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


        public override VG0816B_CPLCOM OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0816B_CPLCOM();
            var i = 0;

            dta.V0PLCO_CODPDT = result[i++].Value?.ToString();

            return dta;
        }

    }
}