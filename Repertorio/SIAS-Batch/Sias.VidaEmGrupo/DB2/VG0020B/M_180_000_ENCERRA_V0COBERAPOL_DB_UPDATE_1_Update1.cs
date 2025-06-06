using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0020B
{
    public class M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1 : QueryBasis<M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0COBERAPOL
				SET DATA_TERVIGENCIA =  '{this.SDATA_MOVIMENTO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE 
				NUM_APOLICE =  '{this.MNUM_APOLICE}'
				AND NRENDOS = 0
				AND NUM_ITEM =  '{this.SNUM_ITEM}'
				AND OCORHIST =  '{this.SOCORR_HISTORICO}'";

            return query;
        }
        public string SDATA_MOVIMENTO { get; set; }
        public string SOCORR_HISTORICO { get; set; }
        public string MNUM_APOLICE { get; set; }
        public string SNUM_ITEM { get; set; }

        public static void Execute(M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1 m_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1)
        {
            var ths = m_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}