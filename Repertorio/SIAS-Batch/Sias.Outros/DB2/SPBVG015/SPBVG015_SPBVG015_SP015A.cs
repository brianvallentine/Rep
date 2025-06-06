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
    public class SPBVG015_SPBVG015_SP015A : QueryBasis<SPBVG015_SPBVG015_SP015A>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SPBVG015_SPBVG015_SP015A() { IsCursor = true; }

        public SPBVG015_SPBVG015_SP015A(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG142_SEQ_PRODUTO_DPS { get; set; }
        public string VG142_COD_PRODUTO { get; set; }
        public string VG145_SEQ_DPS_REGRA { get; set; }
        public string VG145_NOM_DPS_REGRA { get; set; }
        public string VG145_IND_TP_REGRA { get; set; }

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


        public override SPBVG015_SPBVG015_SP015A OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SPBVG015_SPBVG015_SP015A();
            var i = 0;

            dta.VG142_SEQ_PRODUTO_DPS = result[i++].Value?.ToString();
            dta.VG142_COD_PRODUTO = result[i++].Value?.ToString();
            dta.VG145_SEQ_DPS_REGRA = result[i++].Value?.ToString();
            dta.VG145_NOM_DPS_REGRA = result[i++].Value?.ToString();
            dta.VG145_IND_TP_REGRA = result[i++].Value?.ToString();

            return dta;
        }

    }
}