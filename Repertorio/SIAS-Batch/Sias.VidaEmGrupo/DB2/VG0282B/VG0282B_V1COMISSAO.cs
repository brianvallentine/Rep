using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0282B
{
    public class VG0282B_V1COMISSAO : QueryBasis<VG0282B_V1COMISSAO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0282B_V1COMISSAO() { IsCursor = true; }

        public VG0282B_V1COMISSAO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1COMI_NRENDOS { get; set; }
        public string V1COMI_OPERACAO { get; set; }
        public string V1COMI_DTMOVTO { get; set; }
        public string VIND_DTMOVTO { get; set; }
        public string V1COMI_VLCOMIS { get; set; }
        public string V1COMI_DATCLO { get; set; }

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


        public override VG0282B_V1COMISSAO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0282B_V1COMISSAO();
            var i = 0;

            dta.V1COMI_NRENDOS = result[i++].Value?.ToString();
            dta.V1COMI_OPERACAO = result[i++].Value?.ToString();
            dta.V1COMI_DTMOVTO = result[i++].Value?.ToString();
            dta.VIND_DTMOVTO = string.IsNullOrWhiteSpace(dta.V1COMI_DTMOVTO) ? "-1" : "0";
            dta.V1COMI_VLCOMIS = result[i++].Value?.ToString();
            dta.V1COMI_DATCLO = result[i++].Value?.ToString();

            return dta;
        }

    }
}