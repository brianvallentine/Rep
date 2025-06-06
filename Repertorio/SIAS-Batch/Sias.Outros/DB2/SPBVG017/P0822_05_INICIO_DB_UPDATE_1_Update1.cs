using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG017
{
    public class P0822_05_INICIO_DB_UPDATE_1_Update1 : QueryBasis<P0822_05_INICIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_DPS_PROPOSTA
				SET SEQ_PRODUTO_DPS =  '{this.VG143_SEQ_PRODUTO_DPS}'
				,STA_DPS_PROPOSTA =  '{this.VG143_STA_DPS_PROPOSTA}'
				,IND_TP_PESSOA =  '{this.VG143_IND_TP_PESSOA}'
				,IND_TP_SEGURADO =  '{this.VG143_IND_TP_SEGURADO}'
				,NUM_CERTIFICADO =  '{this.VG143_NUM_CERTIFICADO}'
				,VLR_IS =  '{this.VG143_VLR_IS}'
				,VLR_ACUMULO_IS =  '{this.VG143_VLR_ACUMULO_IS}'
				,COD_USUARIO =  '{this.VG143_COD_USUARIO}'
				,NOM_PROGRAMA =  '{this.VG143_NOM_PROGRAMA}'
				,DTH_CADASTRAMENTO =  '{this.VG143_DTH_CADASTRAMENTO}'
				WHERE  NUM_PROPOSTA =  '{this.VG143_NUM_PROPOSTA}'
				AND NUM_CPF_CNPJ =  '{this.VG143_NUM_CPF_CNPJ}'";

            return query;
        }
        public string VG143_DTH_CADASTRAMENTO { get; set; }
        public string VG143_STA_DPS_PROPOSTA { get; set; }
        public string VG143_SEQ_PRODUTO_DPS { get; set; }
        public string VG143_IND_TP_SEGURADO { get; set; }
        public string VG143_NUM_CERTIFICADO { get; set; }
        public string VG143_VLR_ACUMULO_IS { get; set; }
        public string VG143_IND_TP_PESSOA { get; set; }
        public string VG143_NOM_PROGRAMA { get; set; }
        public string VG143_COD_USUARIO { get; set; }
        public string VG143_VLR_IS { get; set; }
        public string VG143_NUM_PROPOSTA { get; set; }
        public string VG143_NUM_CPF_CNPJ { get; set; }

        public static void Execute(P0822_05_INICIO_DB_UPDATE_1_Update1 p0822_05_INICIO_DB_UPDATE_1_Update1)
        {
            var ths = p0822_05_INICIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P0822_05_INICIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}