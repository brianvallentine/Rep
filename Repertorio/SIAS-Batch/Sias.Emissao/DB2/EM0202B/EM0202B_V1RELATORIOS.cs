using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class EM0202B_V1RELATORIOS : QueryBasis<EM0202B_V1RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0202B_V1RELATORIOS() { IsCursor = true; }

        public EM0202B_V1RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1RELA_NUM_APOL { get; set; }
        public string V1RELA_NRENDOS { get; set; }
        public string V1RELA_ORGAO { get; set; }
        public string V1RELA_RAMO { get; set; }
        public string V1RELA_FONTE { get; set; }
        public string V1RELA_CODPDT { get; set; }

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


        public override EM0202B_V1RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0202B_V1RELATORIOS();
            var i = 0;

            dta.V1RELA_NUM_APOL = result[i++].Value?.ToString();
            dta.V1RELA_NRENDOS = result[i++].Value?.ToString();
            dta.V1RELA_ORGAO = result[i++].Value?.ToString();
            dta.V1RELA_RAMO = result[i++].Value?.ToString();
            dta.V1RELA_FONTE = result[i++].Value?.ToString();
            dta.V1RELA_CODPDT = result[i++].Value?.ToString();

            return dta;
        }

    }
}