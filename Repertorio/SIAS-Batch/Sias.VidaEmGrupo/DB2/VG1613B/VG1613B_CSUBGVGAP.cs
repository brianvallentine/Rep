using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class VG1613B_CSUBGVGAP : QueryBasis<VG1613B_CSUBGVGAP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1613B_CSUBGVGAP() { IsCursor = true; }

        public VG1613B_CSUBGVGAP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SUBGVGAP_NUM_APOLICE { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }

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


        public override VG1613B_CSUBGVGAP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1613B_CSUBGVGAP();
            var i = 0;

            dta.SUBGVGAP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();

            return dta;
        }

    }
}