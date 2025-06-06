using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG5001B
{
    public class VG5001B_SEGURAVG : QueryBasis<VG5001B_SEGURAVG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG5001B_SEGURAVG() { IsCursor = true; }

        public VG5001B_SEGURAVG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SNUM_CERTIFICADO { get; set; }

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


        public override VG5001B_SEGURAVG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG5001B_SEGURAVG();
            var i = 0;

            dta.SNUM_CERTIFICADO = result[i++].Value?.ToString();

            return dta;
        }

    }
}