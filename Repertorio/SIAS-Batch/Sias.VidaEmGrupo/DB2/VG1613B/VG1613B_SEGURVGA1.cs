using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class VG1613B_SEGURVGA1 : QueryBasis<VG1613B_SEGURVGA1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1613B_SEGURVGA1() { IsCursor = true; }

        public VG1613B_SEGURVGA1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CLIENTES_COD_CLIENTE { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_TIPO_SEGURADO { get; set; }
        public string SEGURVGA_PCT_CONJUGE_VG { get; set; }
        public string SEGURVGA_PCT_CONJUGE_AP { get; set; }
        public string SEGURVGA_TAXA_AP_MORACID { get; set; }
        public string SEGURVGA_TAXA_AP_INVPERM { get; set; }
        public string SEGURVGA_TAXA_AP_AMDS { get; set; }
        public string SEGURVGA_TAXA_AP_DH { get; set; }
        public string SEGURVGA_TAXA_AP_DIT { get; set; }
        public string SEGURVGA_TAXA_AP { get; set; }
        public string SEGURVGA_TAXA_VG { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_SIT_REGISTRO { get; set; }

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


        public override VG1613B_SEGURVGA1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1613B_SEGURVGA1();
            var i = 0;

            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_TIPO_SEGURADO = result[i++].Value?.ToString();
            dta.SEGURVGA_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.SEGURVGA_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_AP = result[i++].Value?.ToString();
            dta.SEGURVGA_TAXA_VG = result[i++].Value?.ToString();
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SEGURVGA_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}