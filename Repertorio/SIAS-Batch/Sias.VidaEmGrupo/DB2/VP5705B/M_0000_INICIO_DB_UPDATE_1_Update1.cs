using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP5705B
{
    public class M_0000_INICIO_DB_UPDATE_1_Update1 : QueryBasis<M_0000_INICIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVIMENTO
				SET SIT_REGISTRO = '3'
				WHERE  DATA_INCLUSAO =  '{this.SQL_DTMOVABE}'
				AND SIT_REGISTRO IN ( '0' , '1' )
				AND NUM_APOLICE IN (109300000559, 3009300000559)
				AND COD_AGENCIADOR NOT IN (0,999105)
				AND ((COD_OPERACAO >= 0100 AND
				COD_OPERACAO <= 0199) OR
				(COD_OPERACAO >= 0800 AND
				COD_OPERACAO <= 0809))";

            return query;
        }
        public string SQL_DTMOVABE { get; set; }

        public static void Execute(M_0000_INICIO_DB_UPDATE_1_Update1 m_0000_INICIO_DB_UPDATE_1_Update1)
        {
            var ths = m_0000_INICIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0000_INICIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}