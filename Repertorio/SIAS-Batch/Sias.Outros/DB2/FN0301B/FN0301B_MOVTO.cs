using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class FN0301B_MOVTO : QueryBasis<FN0301B_MOVTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FN0301B_MOVTO() { IsCursor = true; }

        public FN0301B_MOVTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1HISP_NUMAPOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string V1ENDO_CODSUBES { get; set; }
        public string V1ENDO_DTINIVIG { get; set; }
        public string V1ENDO_DTTERVIG { get; set; }
        public string V1ENDO_SITUACAO { get; set; }

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


        public override FN0301B_MOVTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FN0301B_MOVTO();
            var i = 0;

            dta.V1HISP_NUMAPOL = result[i++].Value?.ToString();
            dta.V1HISP_NRENDOS = result[i++].Value?.ToString();
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.V1ENDO_CODSUBES = result[i++].Value?.ToString();
            dta.V1ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V1ENDO_DTTERVIG = result[i++].Value?.ToString();
            dta.V1ENDO_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}