using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0125B
{
    public class VE0125B_C01_AGENCEF : QueryBasis<VE0125B_C01_AGENCEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0125B_C01_AGENCEF() { IsCursor = true; }

        public VE0125B_C01_AGENCEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLAGENCIAS_CEF_COD_AGENCIA { get; set; }
        public string DCLMALHA_CEF_MALHACEF_COD_FONTE { get; set; }

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


        public override VE0125B_C01_AGENCEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0125B_C01_AGENCEF();
            var i = 0;

            dta.DCLAGENCIAS_CEF_COD_AGENCIA = result[i++].Value?.ToString();
            dta.DCLMALHA_CEF_MALHACEF_COD_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}