using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0230B
{
    public class R1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 : QueryBasis<R1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE  IDE_SISTEMA = 'BI'
				AND COD_RELATORIO = 'BI0230B1'
				AND SIT_REGISTRO = '0'";

            return query;
        }

        public static void Execute(R1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 r1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1)
        {
            var ths = r1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}