using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class SI0005B_DOCUMENTOS : QueryBasis<SI0005B_DOCUMENTOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0005B_DOCUMENTOS() { IsCursor = true; }

        public SI0005B_DOCUMENTOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SILOTDC2_COD_DOCUMENTO { get; set; }

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


        public override SI0005B_DOCUMENTOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0005B_DOCUMENTOS();
            var i = 0;

            dta.SILOTDC2_COD_DOCUMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}