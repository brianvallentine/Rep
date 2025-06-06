using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0506B
{
    public class R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1 : QueryBasis<R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1>
    {

        private VA0506B_V0FUNDO CurrentOf { get; set; }

        public R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1(VA0506B_V0FUNDO currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.FUNDO_COMISSAO_VA
				SET SITUACAO =  '{this.FUNCOMVA_SITUACAO}'
				,NUM_MATRI_VENDEDOR =  '{this.FUNCOMVA_NUM_MATRI_VENDEDOR}'
				WHERE
				(
					SITUACAO = '0'
				)
				AND NUM_PARCELA {FieldThreatment(CurrentOf.FUNCOMVA_CODIGO_PRODUTO, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string FUNCOMVA_NUM_MATRI_VENDEDOR { get; set; }
        public string FUNCOMVA_SITUACAO { get; set; }

        public static void Execute(R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1 r1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1)
        {
            var ths = r1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}