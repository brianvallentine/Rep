using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0016B
{
    public class VG0016B_ACOPLADO : QueryBasis<VG0016B_ACOPLADO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0016B_ACOPLADO() { IsCursor = true; }

        public VG0016B_ACOPLADO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_IDE_SISTEMA { get; set; }
        public string WS_COD_DOC_PARCEIRO_P { get; set; }
        public string WS_COD_PRODUTO { get; set; }
        public string WS_COD_PLANO { get; set; }

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


        public override VG0016B_ACOPLADO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0016B_ACOPLADO();
            var i = 0;

            dta.WS_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.WS_COD_DOC_PARCEIRO_P = result[i++].Value?.ToString();
            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.WS_COD_PLANO = result[i++].Value?.ToString();

            return dta;
        }

    }
}