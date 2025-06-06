using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG5706B
{
    public class M_1300_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<M_1300_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COMISSOES_VP
				SET SITUACAO =  '{this.SQL_SITUACAO}',
				DATA_COMISSAO =  '{this.SQL_DTMOVABE}',
				COD_USUARIO = 'VG5706B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.SQL_NUM_CERT}'
				AND NUM_PARCELA =  '{this.SQL_NRPARCEL}'
				AND COD_OPERACAO =  '{this.SQL_COD_OPERAC}'
				AND DATA_MOVIMENTO =  '{this.SQL_DTMOVTO}'
				AND SITUACAO = '0'";

            return query;
        }
        public string SQL_SITUACAO { get; set; }
        public string SQL_DTMOVABE { get; set; }
        public string SQL_COD_OPERAC { get; set; }
        public string SQL_NUM_CERT { get; set; }
        public string SQL_NRPARCEL { get; set; }
        public string SQL_DTMOVTO { get; set; }

        public static void Execute(M_1300_UPDATE_DB_UPDATE_1_Update1 m_1300_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = m_1300_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1300_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}