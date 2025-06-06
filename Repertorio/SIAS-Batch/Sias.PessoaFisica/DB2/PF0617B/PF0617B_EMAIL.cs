using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class PF0617B_EMAIL : QueryBasis<PF0617B_EMAIL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0617B_EMAIL() { IsCursor = true; }

        public PF0617B_EMAIL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPESSOA_EMAIL_COD_PESSOA { get; set; }
        public string DCLPESSOA_EMAIL_SEQ_EMAIL { get; set; }
        public string DCLPESSOA_EMAIL_EMAIL { get; set; }
        public string DCLPESSOA_EMAIL_SITUACAO_EMAIL { get; set; }

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


        public override PF0617B_EMAIL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0617B_EMAIL();
            var i = 0;

            dta.DCLPESSOA_EMAIL_COD_PESSOA = result[i++].Value?.ToString();
            dta.DCLPESSOA_EMAIL_SEQ_EMAIL = result[i++].Value?.ToString();
            dta.DCLPESSOA_EMAIL_EMAIL = result[i++].Value?.ToString();
            dta.DCLPESSOA_EMAIL_SITUACAO_EMAIL = result[i++].Value?.ToString();

            return dta;
        }

    }
}