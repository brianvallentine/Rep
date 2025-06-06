using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG013
{
    public class P0210_05_INICIO_DB_UPDATE_1_Update1 : QueryBasis<P0210_05_INICIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_ACOPLADO
				SET STA_ACOPLADO =  '{this.VG135_STA_ACOPLADO}'
				, VLR_TITULO =  '{this.VG135_VLR_TITULO}'
				, DTA_MOVIMENTO =  '{this.VG135_DTA_MOVIMENTO}'
				, DTH_CADASTRAMENTO =  '{this.VG135_DTH_CADASTRAMENTO}'
				, COD_USUARIO =  '{this.VG135_COD_USUARIO}'
				, NOM_PROGRAMA =  '{this.VG135_NOM_PROGRAMA}'
				WHERE  IDE_SISTEMA =  '{this.VG135_IDE_SISTEMA}'
				AND NUM_CERTIFICADO =  '{this.VG135_NUM_CERTIFICADO}'
				AND COD_PRODUTO =  '{this.VG135_COD_PRODUTO}'
				AND COD_PLANO =  '{this.VG135_COD_PLANO}'";

            return query;
        }
        public string VG135_DTH_CADASTRAMENTO { get; set; }
        public string VG135_DTA_MOVIMENTO { get; set; }
        public string VG135_STA_ACOPLADO { get; set; }
        public string VG135_NOM_PROGRAMA { get; set; }
        public string VG135_COD_USUARIO { get; set; }
        public string VG135_VLR_TITULO { get; set; }
        public string VG135_NUM_CERTIFICADO { get; set; }
        public string VG135_IDE_SISTEMA { get; set; }
        public string VG135_COD_PRODUTO { get; set; }
        public string VG135_COD_PLANO { get; set; }

        public static void Execute(P0210_05_INICIO_DB_UPDATE_1_Update1 p0210_05_INICIO_DB_UPDATE_1_Update1)
        {
            var ths = p0210_05_INICIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P0210_05_INICIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}