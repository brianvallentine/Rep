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
    public class R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1 : QueryBasis<R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ENDOSSOS
				SET OCORR_ENDERECO =  '{this.ENDERECO_OCORR_ENDERECO}'
				WHERE NUM_APOLICE =  '{this.SUBGVGAP_NUM_APOLICE}'
				AND NUM_ENDOSSO = 0";

            return query;
        }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static void Execute(R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1 r8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1)
        {
            var ths = r8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}