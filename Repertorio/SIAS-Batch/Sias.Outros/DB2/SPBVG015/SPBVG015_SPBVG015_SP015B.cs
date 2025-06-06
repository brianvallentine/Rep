using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG015
{
    public class SPBVG015_SPBVG015_SP015B : QueryBasis<SPBVG015_SPBVG015_SP015B>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SPBVG015_SPBVG015_SP015B() { IsCursor = true; }

        public SPBVG015_SPBVG015_SP015B(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG141_SEQ_DPS_ITEM { get; set; }
        public string VG141_VLR_NUMR_INICIAL { get; set; }
        public string VG141_VLR_NUMR_FINAL { get; set; }
        public string VG141_VLR_ALFA_INICIAL { get; set; }
        public string VG141_VLR_ALFA_FINAL { get; set; }
        public string VG141_COD_TP_COMPARACAO { get; set; }
        public string VG147_NOM_DPS_ITEM { get; set; }
        public string VG147_IND_TP_ITEM { get; set; }

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


        public override SPBVG015_SPBVG015_SP015B OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SPBVG015_SPBVG015_SP015B();
            var i = 0;

            dta.VG141_SEQ_DPS_ITEM = result[i++].Value?.ToString();
            dta.VG141_VLR_NUMR_INICIAL = result[i++].Value?.ToString();
            dta.VG141_VLR_NUMR_FINAL = result[i++].Value?.ToString();
            dta.VG141_VLR_ALFA_INICIAL = result[i++].Value?.ToString();
            dta.VG141_VLR_ALFA_FINAL = result[i++].Value?.ToString();
            dta.VG141_COD_TP_COMPARACAO = result[i++].Value?.ToString();
            dta.VG147_NOM_DPS_ITEM = result[i++].Value?.ToString();
            dta.VG147_IND_TP_ITEM = result[i++].Value?.ToString();

            return dta;
        }

    }
}