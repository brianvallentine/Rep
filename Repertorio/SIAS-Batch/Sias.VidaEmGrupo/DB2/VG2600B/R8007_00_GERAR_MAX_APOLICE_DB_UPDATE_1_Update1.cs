using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1 : QueryBasis<R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_AES
				SET SEQ_APOLICE =  '{this.APOLICES_NUM_APOLICE}'
				WHERE ORGAO_EMISSOR =  '{this.FONTES_ORGAO_EMISSOR}'
				AND RAMO_EMISSOR =  '{this.RAMOCOMP_RAMO_EMISSOR}'";

            return query;
        }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string RAMOCOMP_RAMO_EMISSOR { get; set; }
        public string FONTES_ORGAO_EMISSOR { get; set; }

        public static void Execute(R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1 r8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1)
        {
            var ths = r8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}