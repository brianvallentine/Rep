using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class VE0414B_CADIC : QueryBasis<VE0414B_CADIC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0414B_CADIC() { IsCursor = true; }

        public VE0414B_CADIC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGARANTI_NUM_GARANTIA { get; set; }
        public string VGARANTI_DES_GARANTIA { get; set; }

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


        public override VE0414B_CADIC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0414B_CADIC();
            var i = 0;

            dta.VGARANTI_NUM_GARANTIA = result[i++].Value?.ToString();
            dta.VGARANTI_DES_GARANTIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}