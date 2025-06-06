using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class VP0437B_CMSG : QueryBasis<VP0437B_CMSG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0437B_CMSG() { IsCursor = true; }

        public VP0437B_CMSG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string COBMENVG_NUM_APOLICE { get; set; }
        public string COBMENVG_CODSUBES { get; set; }
        public string COBMENVG_COD_OPERACAO { get; set; }
        public string COBMENVG_JDE { get; set; }
        public string COBMENVG_JDL { get; set; }

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


        public override VP0437B_CMSG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0437B_CMSG();
            var i = 0;

            dta.COBMENVG_NUM_APOLICE = result[i++].Value?.ToString();
            dta.COBMENVG_CODSUBES = result[i++].Value?.ToString();
            dta.COBMENVG_COD_OPERACAO = result[i++].Value?.ToString();
            dta.COBMENVG_JDE = result[i++].Value?.ToString();
            dta.COBMENVG_JDL = result[i++].Value?.ToString();

            return dta;
        }

    }
}