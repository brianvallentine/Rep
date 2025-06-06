using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI3605B
{
    public class BI3605B_BILHETE_ERROS : QueryBasis<BI3605B_BILHETE_ERROS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI3605B_BILHETE_ERROS() { IsCursor = true; }

        public BI3605B_BILHETE_ERROS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string ERROSBIL_NUM_BILHETE { get; set; }
        public string ERROSBIL_COD_ERRO { get; set; }
        public string CODERRBI_COD_ERRO_SIVPF { get; set; }

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


        public override BI3605B_BILHETE_ERROS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI3605B_BILHETE_ERROS();
            var i = 0;

            dta.ERROSBIL_NUM_BILHETE = result[i++].Value?.ToString();
            dta.ERROSBIL_COD_ERRO = result[i++].Value?.ToString();
            dta.CODERRBI_COD_ERRO_SIVPF = result[i++].Value?.ToString();

            return dta;
        }

    }
}