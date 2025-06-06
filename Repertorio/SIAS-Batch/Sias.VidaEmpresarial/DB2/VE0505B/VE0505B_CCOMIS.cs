using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0505B
{
    public class VE0505B_CCOMIS : QueryBasis<VE0505B_CCOMIS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0505B_CCOMIS() { IsCursor = true; }

        public VE0505B_CCOMIS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0COMI_NUM_APOLICE { get; set; }
        public string CODSUBES { get; set; }
        public string TIPCOM { get; set; }
        public string RAMO { get; set; }
        public string VALBAS { get; set; }
        public string VLCOMIS { get; set; }
        public string FONTE { get; set; }
        public string CODCLIEN { get; set; }
        public string CODOPER { get; set; }
        public string PCCOMCOR { get; set; }
        public string V0COMI_NRPARCEL { get; set; }

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


        public override VE0505B_CCOMIS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0505B_CCOMIS();
            var i = 0;

            dta.V0COMI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.CODSUBES = result[i++].Value?.ToString();
            dta.TIPCOM = result[i++].Value?.ToString();
            dta.RAMO = result[i++].Value?.ToString();
            dta.VALBAS = result[i++].Value?.ToString();
            dta.VLCOMIS = result[i++].Value?.ToString();
            dta.FONTE = result[i++].Value?.ToString();
            dta.CODCLIEN = result[i++].Value?.ToString();
            dta.CODOPER = result[i++].Value?.ToString();
            dta.PCCOMCOR = result[i++].Value?.ToString();
            dta.V0COMI_NRPARCEL = result[i++].Value?.ToString();

            return dta;
        }

    }
}