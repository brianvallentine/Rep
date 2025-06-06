using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0884B
{
    public class SI0884B_CURS01 : QueryBasis<SI0884B_CURS01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0884B_CURS01() { IsCursor = true; }

        public SI0884B_CURS01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SISINACO_COD_FONTE { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DATA_MOVTO_SINIACO { get; set; }
        public string SISINACO_NUM_OCORR_SINIACO { get; set; }
        public string SIMOVSIN_NATUREZA_SINISTRO { get; set; }
        public string SIMOVSIN_COD_SUBESTIPULANTE { get; set; }
        public string SIMOVSIN_NOME_SEGURADO { get; set; }

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


        public override SI0884B_CURS01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0884B_CURS01();
            var i = 0;

            dta.SISINACO_COD_FONTE = result[i++].Value?.ToString();
            dta.SISINACO_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SISINACO_DAC_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SISINACO_DATA_MOVTO_SINIACO = result[i++].Value?.ToString();
            dta.SISINACO_NUM_OCORR_SINIACO = result[i++].Value?.ToString();
            dta.SIMOVSIN_NATUREZA_SINISTRO = result[i++].Value?.ToString();
            dta.SIMOVSIN_COD_SUBESTIPULANTE = result[i++].Value?.ToString();
            dta.SIMOVSIN_NOME_SEGURADO = result[i++].Value?.ToString();

            return dta;
        }

    }
}