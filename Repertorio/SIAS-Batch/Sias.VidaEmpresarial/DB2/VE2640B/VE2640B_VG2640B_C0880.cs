using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class VE2640B_VG2640B_C0880 : QueryBasis<VE2640B_VG2640B_C0880>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE2640B_VG2640B_C0880() { IsCursor = true; }

        public VE2640B_VG2640B_C0880(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG033_NUM_ACESSORIO { get; set; }
        public string VG033_DES_ACESSORIO { get; set; }
        public string VGARANTI_NUM_GARANTIA { get; set; }

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


        public override VE2640B_VG2640B_C0880 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE2640B_VG2640B_C0880();
            var i = 0;

            dta.VG033_NUM_ACESSORIO = result[i++].Value?.ToString();
            dta.VG033_DES_ACESSORIO = result[i++].Value?.ToString();
            dta.VGARANTI_NUM_GARANTIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}