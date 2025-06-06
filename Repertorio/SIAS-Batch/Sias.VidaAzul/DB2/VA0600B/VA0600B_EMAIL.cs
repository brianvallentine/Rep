using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class VA0600B_EMAIL : QueryBasis<VA0600B_EMAIL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0600B_EMAIL() { IsCursor = true; }

        public VA0600B_EMAIL(bool justACursor)
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


        public override VA0600B_EMAIL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0600B_EMAIL();
            var i = 0;

            dta.DCLPESSOA_EMAIL_COD_PESSOA = result[i++].Value?.ToString();
            dta.DCLPESSOA_EMAIL_SEQ_EMAIL = result[i++].Value?.ToString();
            dta.DCLPESSOA_EMAIL_EMAIL = result[i++].Value?.ToString();
            dta.DCLPESSOA_EMAIL_SITUACAO_EMAIL = result[i++].Value?.ToString();

            return dta;
        }

    }
}