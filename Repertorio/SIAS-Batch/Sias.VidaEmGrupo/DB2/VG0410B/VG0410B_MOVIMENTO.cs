using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0410B
{
    public class VG0410B_MOVIMENTO : QueryBasis<VG0410B_MOVIMENTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0410B_MOVIMENTO() { IsCursor = true; }

        public VG0410B_MOVIMENTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVTO_NUM_APOLICE { get; set; }
        public string MOVTO_COD_SUBES { get; set; }
        public string MOVTO_NUM_CERTIFIC { get; set; }
        public string MOVTO_COD_USUARIO { get; set; }
        public string MOVTO_COD_OPER { get; set; }

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


        public override VG0410B_MOVIMENTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0410B_MOVIMENTO();
            var i = 0;

            dta.MOVTO_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVTO_COD_SUBES = result[i++].Value?.ToString();
            dta.MOVTO_NUM_CERTIFIC = result[i++].Value?.ToString();
            dta.MOVTO_COD_USUARIO = result[i++].Value?.ToString();
            dta.MOVTO_COD_OPER = result[i++].Value?.ToString();

            return dta;
        }

    }
}