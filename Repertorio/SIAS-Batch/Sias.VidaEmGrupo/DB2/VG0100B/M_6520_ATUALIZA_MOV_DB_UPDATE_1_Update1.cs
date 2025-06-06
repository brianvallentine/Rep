using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1 : QueryBasis<M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0MOVIMENTO
				SET DATA_FATURA =  '{this.V0MOVI_DATA_FATURA}'
				WHERE  NUM_APOLICE =  '{this.W1SOLF_NUM_APOL}'
				AND COD_SUBGRUPO BETWEEN 1 AND 9999
				AND DATA_INCLUSAO IS NOT NULL
				AND DATA_REFERENCIA =  '{this.V1FATC_DATA_REFER}'";

            return query;
        }
        public string V0MOVI_DATA_FATURA { get; set; }
        public string V1FATC_DATA_REFER { get; set; }
        public string W1SOLF_NUM_APOL { get; set; }

        public static void Execute(M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1 m_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1)
        {
            var ths = m_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}