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
    public class R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1 : QueryBasis<R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SUBGRUPOS_VGAP
				SET OCORR_ENDERECO =  '{this.ENDERECO_OCORR_ENDERECO}',
				OCORR_END_COBRAN =  '{this.ENDERECO_OCORR_ENDERECO}'
				WHERE NUM_APOLICE =  '{this.SUBGVGAP_NUM_APOLICE}'
				AND COD_SUBGRUPO IN ( '{this.WS_SUBGRUPO_1}',  '{this.WS_SUBGRUPO_2}')";

            return query;
        }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }
        public string WS_SUBGRUPO_1 { get; set; }
        public string WS_SUBGRUPO_2 { get; set; }

        public static void Execute(R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1 r8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1)
        {
            var ths = r8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}