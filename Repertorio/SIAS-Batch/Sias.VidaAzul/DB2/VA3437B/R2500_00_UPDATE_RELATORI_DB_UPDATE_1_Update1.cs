using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 : QueryBasis<R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_RELATORIO =  '{this.WHOST_CODRELAT}'
				AND SIT_REGISTRO = '0'
				AND COD_OPERACAO IN (2,6,10)
				AND NUM_PARCELA = 2
				AND NUM_CERTIFICADO =  '{this.WHOST_NRCERTIF}'";

            return query;
        }
        public string WHOST_CODRELAT { get; set; }
        public string WHOST_NRCERTIF { get; set; }

        public static void Execute(R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 r2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1)
        {
            var ths = r2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}