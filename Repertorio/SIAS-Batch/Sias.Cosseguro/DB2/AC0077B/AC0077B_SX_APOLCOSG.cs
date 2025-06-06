using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0077B
{
    public class AC0077B_SX_APOLCOSG : QueryBasis<AC0077B_SX_APOLCOSG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0077B_SX_APOLCOSG() { IsCursor = true; }

        public AC0077B_SX_APOLCOSG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SX010_NUM_APOLICE { get; set; }
        public string SX118_COD_CONGENERE { get; set; }
        public string SX118_PCT_PARTICIPACAO { get; set; }

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


        public override AC0077B_SX_APOLCOSG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0077B_SX_APOLCOSG();
            var i = 0;

            dta.SX010_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SX118_COD_CONGENERE = result[i++].Value?.ToString();
            dta.SX118_PCT_PARTICIPACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}