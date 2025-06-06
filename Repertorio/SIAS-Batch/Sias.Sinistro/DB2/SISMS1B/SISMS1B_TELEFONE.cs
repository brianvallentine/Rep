using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISMS1B
{
    public class SISMS1B_TELEFONE : QueryBasis<SISMS1B_TELEFONE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SISMS1B_TELEFONE() { IsCursor = true; }

        public SISMS1B_TELEFONE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string OD004_NUM_PESSOA { get; set; }
        public string IND_NULL1 { get; set; }
        public string OD004_SEQ_TELEFONE { get; set; }
        public string IND_NULL2 { get; set; }
        public string OD004_NUM_DDI { get; set; }
        public string IND_NULL3 { get; set; }
        public string OD004_NUM_DDD { get; set; }
        public string IND_NULL4 { get; set; }
        public string OD004_COD_TELEFONE { get; set; }
        public string IND_NULL5 { get; set; }

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


        public override SISMS1B_TELEFONE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SISMS1B_TELEFONE();
            var i = 0;

            dta.OD004_NUM_PESSOA = result[i++].Value?.ToString();
            dta.IND_NULL1 = string.IsNullOrWhiteSpace(dta.OD004_NUM_PESSOA) ? "-1" : "0";
            dta.OD004_SEQ_TELEFONE = result[i++].Value?.ToString();
            dta.IND_NULL2 = string.IsNullOrWhiteSpace(dta.OD004_SEQ_TELEFONE) ? "-1" : "0";
            dta.OD004_NUM_DDI = result[i++].Value?.ToString();
            dta.IND_NULL3 = string.IsNullOrWhiteSpace(dta.OD004_NUM_DDI) ? "-1" : "0";
            dta.OD004_NUM_DDD = result[i++].Value?.ToString();
            dta.IND_NULL4 = string.IsNullOrWhiteSpace(dta.OD004_NUM_DDD) ? "-1" : "0";
            dta.OD004_COD_TELEFONE = result[i++].Value?.ToString();
            dta.IND_NULL5 = string.IsNullOrWhiteSpace(dta.OD004_COD_TELEFONE) ? "-1" : "0";

            return dta;
        }

    }
}