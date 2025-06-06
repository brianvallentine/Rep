using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1 : QueryBasis<R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTABILVA
				SET SITUACAO = '3' ,
				NRENDOS = 0 ,
				DTFATUR = NULL
				WHERE 
				NUM_APOLICE =  '{this.V0ENDO_NUM_APOLICE}'
				AND CODSUBES =  '{this.V0ENDO_CODSUBES}'
				AND FONTE =  '{this.V0ENDO_FONTE}'
				AND NRENDOS =  '{this.V0ENDO_NRENDOS}'
				AND DTFATUR =  '{this.V1SIST_DTMOVABE}'
				AND NRPARCEL =  '{this.WHOST_NRPARCEL}'
				AND CODOPER �= 1000";

            return query;
        }
        public string V0ENDO_NUM_APOLICE { get; set; }
        public string V0ENDO_CODSUBES { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0ENDO_NRENDOS { get; set; }
        public string WHOST_NRPARCEL { get; set; }
        public string V0ENDO_FONTE { get; set; }

        public static void Execute(R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1 r1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1)
        {
            var ths = r1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}