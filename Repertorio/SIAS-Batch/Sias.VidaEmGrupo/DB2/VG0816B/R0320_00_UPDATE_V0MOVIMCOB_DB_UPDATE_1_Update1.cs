using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1 : QueryBasis<R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1>
    {

        private VG0816B_V0MOVIMCOB CurrentOf { get; set; }

        public R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1(VG0816B_V0MOVIMCOB currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET NUM_TITULO =  '{this.V0MOVC_NRTIT}'
				,NUM_PARCELA =  '{this.V0MOVC_NRPARCEL}'
				,SIT_REGISTRO =  '{this.V0MOVC_SITUACAO}'
				,NOME_SEGURADO =  '{this.V0MOVC_NOME}'
				WHERE
				(
					SIT_REGISTRO = ' ' AND TIPO_MOVIMENTO IN ( '2', '3' )
				)
				AND NUM_NOSSO_TITULO {FieldThreatment(CurrentOf.V0MOVC_COD_EMPRESA, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string V0MOVC_NRPARCEL { get; set; }
        public string V0MOVC_SITUACAO { get; set; }
        public string V0MOVC_NRTIT { get; set; }
        public string V0MOVC_NOME { get; set; }

        public static void Execute(R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1 r0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1)
        {
            var ths = r0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}