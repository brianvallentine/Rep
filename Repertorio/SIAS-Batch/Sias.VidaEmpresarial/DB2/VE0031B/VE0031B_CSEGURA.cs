using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0031B
{
    public class VE0031B_CSEGURA : QueryBasis<VE0031B_CSEGURA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0031B_CSEGURA() { IsCursor = true; }

        public VE0031B_CSEGURA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_COD_FONTE { get; set; }

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


        public override VE0031B_CSEGURA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0031B_CSEGURA();
            var i = 0;

            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}