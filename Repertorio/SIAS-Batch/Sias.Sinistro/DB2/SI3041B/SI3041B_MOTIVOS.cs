using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI3041B
{
    public class SI3041B_MOTIVOS : QueryBasis<SI3041B_MOTIVOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI3041B_MOTIVOS() { IsCursor = true; }

        public SI3041B_MOTIVOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SIMOTIVO_COD_TIPO_MOTIVO { get; set; }
        public string SIMOTIVO_NUM_MOTIVO { get; set; }
        public string SIMOTIVO_DES_MOTIVO { get; set; }

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


        public override SI3041B_MOTIVOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI3041B_MOTIVOS();
            var i = 0;

            dta.SIMOTIVO_COD_TIPO_MOTIVO = result[i++].Value?.ToString();
            dta.SIMOTIVO_NUM_MOTIVO = result[i++].Value?.ToString();
            dta.SIMOTIVO_DES_MOTIVO = result[i++].Value?.ToString();

            return dta;
        }

    }
}