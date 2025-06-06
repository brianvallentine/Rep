using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0134B
{
    public class R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1 : QueryBasis<R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET DTPROXVEN = DATE( '{this.WS_DATA_REFERENCIA}')
				+  {this.HOST_QTD_ANOS} MONTHS
				+ 01 MONTH
				, DATA_VENCIMENTO = DATE( '{this.WS_DATA_AUX}')
				+  {this.HOST_QTD_ANOS} MONTHS
				+ 01 MONTH
				, COD_USUARIO = 'VG0134B'
				, TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'";

            return query;
        }
        public string WS_DATA_REFERENCIA { get; set; }
        public string HOST_QTD_ANOS { get; set; }
        public string WS_DATA_AUX { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1 r1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1)
        {
            var ths = r1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}