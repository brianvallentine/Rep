using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0130B
{
    public class M_700_000_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<M_700_000_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODRELAT = 'VG0130B'
				AND IDSISTEM = 'VG'
				AND SITUACAO = '0'
				AND NUM_APOLICE <> 97010000889
				AND NUM_APOLICE =  '{this.R_NUM_APOLICE}'
				AND CODSUBES =  '{this.R_CODSUBES}'";

            return query;
        }
        public string R_NUM_APOLICE { get; set; }
        public string R_CODSUBES { get; set; }

        public static void Execute(M_700_000_UPDATE_DB_UPDATE_1_Update1 m_700_000_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = m_700_000_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_700_000_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}