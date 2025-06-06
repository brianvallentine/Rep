using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class VG0711S_CAREN491 : QueryBasis<VG0711S_CAREN491>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0711S_CAREN491() { IsCursor = true; }

        public VG0711S_CAREN491(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGARANTI_NUM_GARANTIA { get; set; }
        public string VG091_DES_COB_CARENCIA { get; set; }

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


        public override VG0711S_CAREN491 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0711S_CAREN491();
            var i = 0;

            dta.VGARANTI_NUM_GARANTIA = result[i++].Value?.ToString();
            dta.VG091_DES_COB_CARENCIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}