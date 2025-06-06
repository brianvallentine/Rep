using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2853B
{
    public class VG2853B_CATRASO : QueryBasis<VG2853B_CATRASO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG2853B_CATRASO() { IsCursor = true; }

        public VG2853B_CATRASO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HOST_PARCELA_ATRASO { get; set; }

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


        public override VG2853B_CATRASO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG2853B_CATRASO();
            var i = 0;

            dta.HOST_PARCELA_ATRASO = result[i++].Value?.ToString();

            return dta;
        }

    }
}