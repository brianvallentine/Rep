using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 : QueryBasis<R1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AVISOS_SALDOS
				SET SALDO_ATUAL =
				(SALDO_ATUAL -  '{this.RCAPCOMP_VAL_RCAP}')
				WHERE  BCO_AVISO =  '{this.RCAPCOMP_BCO_AVISO}'
				AND AGE_AVISO =  '{this.RCAPCOMP_AGE_AVISO}'
				AND NUM_AVISO_CREDITO =  '{this.RCAPCOMP_NUM_AVISO_CREDITO}'";

            return query;
        }
        public string RCAPCOMP_VAL_RCAP { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }

        public static void Execute(R1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 r1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1)
        {
            var ths = r1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}