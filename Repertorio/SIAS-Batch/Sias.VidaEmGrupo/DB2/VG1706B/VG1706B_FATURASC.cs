using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1706B
{
    public class VG1706B_FATURASC : QueryBasis<VG1706B_FATURASC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1706B_FATURASC() { IsCursor = true; }

        public VG1706B_FATURASC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }

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


        public override VG1706B_FATURASC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1706B_FATURASC();
            var i = 0;

            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_ENDOSSO = result[i++].Value?.ToString();

            return dta;
        }

    }
}