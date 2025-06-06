using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1 : QueryBasis<R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COBER_HIST_VIDAZUL
				SET SIT_REGISTRO = '2'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.PROPOVA_NUM_PARCELA}'
				AND NUM_TITULO <>  '{this.COBHISVI_NUM_TITULO}'";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }

        public static void Execute(R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1 r1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1)
        {
            var ths = r1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1215_00_CANCEL_HISTCOBVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}