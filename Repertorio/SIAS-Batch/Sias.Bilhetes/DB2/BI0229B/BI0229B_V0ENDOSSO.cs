using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0229B
{
    public class BI0229B_V0ENDOSSO : QueryBasis<BI0229B_V0ENDOSSO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0229B_V0ENDOSSO() { IsCursor = true; }

        public BI0229B_V0ENDOSSO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string PARCEHIS_VAL_IOCC { get; set; }
        public string PARCEHIS_PRM_TOTAL { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_COD_SUBGRUPO { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_TIPO_ENDOSSO { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string APOLICES_NUM_BILHETE { get; set; }
        public string APOLICES_TIPO_SEGURO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }

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


        public override BI0229B_V0ENDOSSO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0229B_V0ENDOSSO();
            var i = 0;

            dta.PARCEHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_IOCC = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TOTAL = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_TIPO_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.APOLICES_NUM_BILHETE = result[i++].Value?.ToString();
            dta.APOLICES_TIPO_SEGURO = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}