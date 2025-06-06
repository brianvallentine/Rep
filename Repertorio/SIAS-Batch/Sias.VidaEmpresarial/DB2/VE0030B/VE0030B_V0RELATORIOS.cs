using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class VE0030B_V0RELATORIOS : QueryBasis<VE0030B_V0RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0030B_V0RELATORIOS() { IsCursor = true; }

        public VE0030B_V0RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1REL_COD_USUR { get; set; }
        public string V1REL_NUM_APOL { get; set; }
        public string V1REL_COD_SUBG { get; set; }
        public string V1REL_SIT_REGISTRO { get; set; }

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


        public override VE0030B_V0RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0030B_V0RELATORIOS();
            var i = 0;

            dta.V1REL_COD_USUR = result[i++].Value?.ToString();
            dta.V1REL_NUM_APOL = result[i++].Value?.ToString();
            dta.V1REL_COD_SUBG = result[i++].Value?.ToString();
            dta.V1REL_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}