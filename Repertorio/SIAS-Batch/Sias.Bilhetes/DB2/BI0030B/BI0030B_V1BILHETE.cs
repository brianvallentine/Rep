using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0030B
{
    public class BI0030B_V1BILHETE : QueryBasis<BI0030B_V1BILHETE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0030B_V1BILHETE() { IsCursor = true; }

        public BI0030B_V1BILHETE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1BILH_NUMBIL { get; set; }
        public string V1BILH_AGENCIA { get; set; }
        public string V1BILH_OPERACAO { get; set; }
        public string V1BILH_NUMCTA { get; set; }
        public string V1BILH_DIGCTA { get; set; }
        public string V1BILH_AGENCIA_DEB { get; set; }
        public string V1BILH_OPERACAO_DEB { get; set; }
        public string V1BILH_NUMCTA_DEB { get; set; }
        public string V1BILH_DIGCTA_DEB { get; set; }
        public string V1BILH_DTQITBCO { get; set; }
        public string V1BILH_VLRCAP { get; set; }
        public string V1BILH_NUM_APOL_ANT { get; set; }
        public string V1BILH_RAMO { get; set; }
        public string V1BILH_SITUACAO { get; set; }

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


        public override BI0030B_V1BILHETE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0030B_V1BILHETE();
            var i = 0;

            dta.V1BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V1BILH_AGENCIA = result[i++].Value?.ToString();
            dta.V1BILH_OPERACAO = result[i++].Value?.ToString();
            dta.V1BILH_NUMCTA = result[i++].Value?.ToString();
            dta.V1BILH_DIGCTA = result[i++].Value?.ToString();
            dta.V1BILH_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.V1BILH_OPERACAO_DEB = result[i++].Value?.ToString();
            dta.V1BILH_NUMCTA_DEB = result[i++].Value?.ToString();
            dta.V1BILH_DIGCTA_DEB = result[i++].Value?.ToString();
            dta.V1BILH_DTQITBCO = result[i++].Value?.ToString();
            dta.V1BILH_VLRCAP = result[i++].Value?.ToString();
            dta.V1BILH_NUM_APOL_ANT = result[i++].Value?.ToString();
            dta.V1BILH_RAMO = result[i++].Value?.ToString();
            dta.V1BILH_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}