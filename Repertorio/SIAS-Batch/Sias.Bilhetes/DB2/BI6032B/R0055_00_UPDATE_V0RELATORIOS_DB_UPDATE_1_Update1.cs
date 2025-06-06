using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6032B
{
    public class R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO =  '{this.V0RELAT_SITUACAO}',
				QUANTIDADE =  '{this.V0RELAT_QUANTIDADE}'
				WHERE  CODRELAT =  '{this.V0RELAT_CODRELAT}'
				AND SITUACAO = '0'
				AND NRTIT =  '{this.V0RELAT_NRTIT}'
				AND NUM_APOLICE =  '{this.V0RELAT_NUM_APOLICE}'";

            return query;
        }
        public string V0RELAT_QUANTIDADE { get; set; }
        public string V0RELAT_SITUACAO { get; set; }
        public string V0RELAT_NUM_APOLICE { get; set; }
        public string V0RELAT_CODRELAT { get; set; }
        public string V0RELAT_NRTIT { get; set; }

        public static void Execute(R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 r0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}