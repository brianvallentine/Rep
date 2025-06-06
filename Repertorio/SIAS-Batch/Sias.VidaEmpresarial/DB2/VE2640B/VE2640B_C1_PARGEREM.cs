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
    public class VE2640B_C1_PARGEREM : QueryBasis<VE2640B_C1_PARGEREM>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE2640B_C1_PARGEREM() { IsCursor = true; }

        public VE2640B_C1_PARGEREM(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string H_APOLICES_RAMO_EMISSOR { get; set; }
        public string PARGEREM_DIA_FATURAMENTO { get; set; }
        public string PARGEREM_COD_CORRETOR { get; set; }
        public string PARGEREM_PCCOMCOR { get; set; }
        public string PARGEREM_COD_MOEDA_FAT { get; set; }

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


        public override VE2640B_C1_PARGEREM OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE2640B_C1_PARGEREM();
            var i = 0;

            dta.H_APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.PARGEREM_DIA_FATURAMENTO = result[i++].Value?.ToString();
            dta.PARGEREM_COD_CORRETOR = result[i++].Value?.ToString();
            dta.PARGEREM_PCCOMCOR = result[i++].Value?.ToString();
            dta.PARGEREM_COD_MOEDA_FAT = result[i++].Value?.ToString();

            return dta;
        }

    }
}