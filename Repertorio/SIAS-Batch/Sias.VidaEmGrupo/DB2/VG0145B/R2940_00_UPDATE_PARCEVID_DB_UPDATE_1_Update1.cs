using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0145B
{
    public class R2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1 : QueryBasis<R2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL T1
				SET T1.SIT_REGISTRO = '1'
				WHERE  T1.SIT_REGISTRO = 'V'
				AND T1.NUM_CERTIFICADO IN
				(SELECT T10.NUM_CERTIFICADO
				FROM SEGUROS.PROPOSTAS_VA T10
				WHERE  T10.NUM_APOLICE =  '{this.PROPOVA_NUM_APOLICE}'
				AND T10.DTPROXVEN = '9999-12-31' )";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static void Execute(R2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1 r2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1)
        {
            var ths = r2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2940_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}