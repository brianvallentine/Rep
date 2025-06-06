using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class AC0816B_V0RELATORIOS : QueryBasis<AC0816B_V0RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0816B_V0RELATORIOS() { IsCursor = true; }

        public AC0816B_V0RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0RELA_COD_USU { get; set; }
        public string V0RELA_DATA_SOL { get; set; }
        public string V0RELA_IDSISTEM { get; set; }
        public string V0RELA_CODRELAT { get; set; }
        public string V0RELA_PERI_INI { get; set; }
        public string V0RELA_PERI_FIN { get; set; }
        public string V0RELA_DATA_REF { get; set; }
        public string V0RELA_CONGENER { get; set; }
        public string V0RELA_CODUNIMO { get; set; }
        public string V0RELA_CORRECAO { get; set; }
        public string V0RELA_COD_EMPR { get; set; }

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


        public override AC0816B_V0RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0816B_V0RELATORIOS();
            var i = 0;

            dta.V0RELA_COD_USU = result[i++].Value?.ToString();
            dta.V0RELA_DATA_SOL = result[i++].Value?.ToString();
            dta.V0RELA_IDSISTEM = result[i++].Value?.ToString();
            dta.V0RELA_CODRELAT = result[i++].Value?.ToString();
            dta.V0RELA_PERI_INI = result[i++].Value?.ToString();
            dta.V0RELA_PERI_FIN = result[i++].Value?.ToString();
            dta.V0RELA_DATA_REF = result[i++].Value?.ToString();
            dta.V0RELA_CONGENER = result[i++].Value?.ToString();
            dta.V0RELA_CODUNIMO = result[i++].Value?.ToString();
            dta.V0RELA_CORRECAO = result[i++].Value?.ToString();
            dta.V0RELA_COD_EMPR = result[i++].Value?.ToString();

            return dta;
        }

    }
}