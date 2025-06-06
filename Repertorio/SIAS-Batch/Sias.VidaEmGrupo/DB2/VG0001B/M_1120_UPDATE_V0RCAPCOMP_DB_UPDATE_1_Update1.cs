using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 : QueryBasis<M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RCAP_COMPLEMENTAR
				SET SIT_REGISTRO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_FONTE =  '{this.RCAPCOMP_COD_FONTE}'
				AND NUM_RCAP =  '{this.RCAPCOMP_NUM_RCAP}'
				AND NUM_RCAP_COMPLEMEN =  '{this.RCAPCOMP_NUM_RCAP_COMPLEMEN}'
				AND COD_OPERACAO =  '{this.RCAPCOMP_COD_OPERACAO}'
				AND DATA_MOVIMENTO =  '{this.RCAPCOMP_DATA_MOVIMENTO}'
				AND HORA_OPERACAO =  '{this.RCAPCOMP_HORA_OPERACAO}'";

            return query;
        }
        public string RCAPCOMP_NUM_RCAP_COMPLEMEN { get; set; }
        public string RCAPCOMP_DATA_MOVIMENTO { get; set; }
        public string RCAPCOMP_HORA_OPERACAO { get; set; }
        public string RCAPCOMP_COD_OPERACAO { get; set; }
        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }

        public static void Execute(M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 m_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1)
        {
            var ths = m_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}