using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class VA2601B_CRISCO : QueryBasis<VA2601B_CRISCO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2601B_CRISCO() { IsCursor = true; }

        public VA2601B_CRISCO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPVA_NRCERTIF { get; set; }

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


        public override VA2601B_CRISCO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2601B_CRISCO();
            var i = 0;

            dta.PROPVA_NRCERTIF = result[i++].Value?.ToString();

            return dta;
        }

    }
}