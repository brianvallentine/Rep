using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class SI0031B_CARDEST : QueryBasis<SI0031B_CARDEST>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0031B_CARDEST() { IsCursor = true; }

        public SI0031B_CARDEST(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GERECADE_COD_DESTINATARIO { get; set; }
        public string GERECADE_IND_DEST_PRINC { get; set; }
        public string GEDESTIN_NOME_DESTINATARIO { get; set; }

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


        public override SI0031B_CARDEST OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0031B_CARDEST();
            var i = 0;

            dta.GERECADE_COD_DESTINATARIO = result[i++].Value?.ToString();
            dta.GERECADE_IND_DEST_PRINC = result[i++].Value?.ToString();
            dta.GEDESTIN_NOME_DESTINATARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}