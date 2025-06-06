using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0822_05_INICIO_DB_UPDATE_1_Update1 : QueryBasis<P0822_05_INICIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_CRITICA_PROPOSTA
				SET STA_CRITICA =  '{this.VG103_STA_CRITICA}'
				,DES_COMPLEMENTAR =  {FieldThreatment((this.WH_VG103IDES_COMPLEMENTAR?.ToInt() == -1 ? null : $"{this.VG103_DES_COMPLEMENTAR}"))}
				,DTH_CADASTRAMENTO =  '{this.VG103_DTH_CADASTRAMENTO}'
				,COD_USUARIO =  '{this.VG103_COD_USUARIO}'
				,NOM_PROGRAMA =  '{this.VG103_NOM_PROGRAMA}'
				WHERE  NUM_CERTIFICADO =  '{this.VG103_NUM_CERTIFICADO}'
				AND SEQ_CRITICA =  '{this.VG103_SEQ_CRITICA}'";

            return query;
        }
        public string VG103_DES_COMPLEMENTAR { get; set; }
        public string WH_VG103IDES_COMPLEMENTAR { get; set; }
        public string VG103_DTH_CADASTRAMENTO { get; set; }
        public string VG103_NOM_PROGRAMA { get; set; }
        public string VG103_STA_CRITICA { get; set; }
        public string VG103_COD_USUARIO { get; set; }
        public string VG103_NUM_CERTIFICADO { get; set; }
        public string VG103_SEQ_CRITICA { get; set; }

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