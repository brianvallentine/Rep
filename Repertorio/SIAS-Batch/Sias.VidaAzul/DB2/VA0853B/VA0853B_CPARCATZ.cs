using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class VA0853B_CPARCATZ : QueryBasis<VA0853B_CPARCATZ>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0853B_CPARCATZ() { IsCursor = true; }

        public VA0853B_CPARCATZ(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_ATZ_NUM_TITULO { get; set; }
        public string WS_ATZ_NUM_PARCELA { get; set; }
        public string WS_ATZ_DT_VENCIMENTO { get; set; }
        public string WS_ATZ_VLR_DEBITO { get; set; }
        public string WS_ATZ_COD_RETORNO { get; set; }
        public string WS_ATZ_COD_MOTIVO { get; set; }
        public string WS_ATZ_OCORR_HISTCTA { get; set; }

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


        public override VA0853B_CPARCATZ OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0853B_CPARCATZ();
            var i = 0;

            dta.WS_ATZ_NUM_TITULO = result[i++].Value?.ToString();
            dta.WS_ATZ_NUM_PARCELA = result[i++].Value?.ToString();
            dta.WS_ATZ_DT_VENCIMENTO = result[i++].Value?.ToString();
            dta.WS_ATZ_VLR_DEBITO = result[i++].Value?.ToString();
            dta.WS_ATZ_COD_RETORNO = result[i++].Value?.ToString();
            dta.WS_ATZ_COD_MOTIVO = result[i++].Value?.ToString();
            dta.WS_ATZ_OCORR_HISTCTA = result[i++].Value?.ToString();

            return dta;
        }

    }
}