using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class VA2601B_CFONE : QueryBasis<VA2601B_CFONE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2601B_CFONE() { IsCursor = true; }

        public VA2601B_CFONE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPESSOA_TELEFONE_TIPO_FONE { get; set; }
        public string DCLPESSOA_TELEFONE_DDD { get; set; }
        public string DCLPESSOA_TELEFONE_NUM_FONE { get; set; }

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


        public override VA2601B_CFONE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2601B_CFONE();
            var i = 0;

            dta.DCLPESSOA_TELEFONE_TIPO_FONE = result[i++].Value?.ToString();
            dta.DCLPESSOA_TELEFONE_DDD = result[i++].Value?.ToString();
            dta.DCLPESSOA_TELEFONE_NUM_FONE = result[i++].Value?.ToString();

            return dta;
        }

    }
}