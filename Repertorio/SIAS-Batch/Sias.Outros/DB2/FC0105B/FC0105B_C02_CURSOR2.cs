using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0105B
{
    public class FC0105B_C02_CURSOR2 : QueryBasis<FC0105B_C02_CURSOR2>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FC0105B_C02_CURSOR2() { IsCursor = true; }

        public FC0105B_C02_CURSOR2(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FCPROPOS_NUM_PROPOSTA { get; set; }
        public string FCPROPOS_NUM_NSA { get; set; }
        public string FCTITULO_NUM_PLANO { get; set; }
        public string FCTITULO_NUM_SERIE { get; set; }
        public string FCTITULO_NUM_TITULO { get; set; }
        public string FCTITULO_IDE_TITULAR { get; set; }
        public string FCTITULO_VLR_MENSALIDADE { get; set; }

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


        public override FC0105B_C02_CURSOR2 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FC0105B_C02_CURSOR2();
            var i = 0;

            dta.FCPROPOS_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.FCPROPOS_NUM_NSA = result[i++].Value?.ToString();
            dta.FCTITULO_NUM_PLANO = result[i++].Value?.ToString();
            dta.FCTITULO_NUM_SERIE = result[i++].Value?.ToString();
            dta.FCTITULO_NUM_TITULO = result[i++].Value?.ToString();
            dta.FCTITULO_IDE_TITULAR = result[i++].Value?.ToString();
            dta.FCTITULO_VLR_MENSALIDADE = result[i++].Value?.ToString();

            return dta;
        }

    }
}