using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0004B
{
    public class M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1 : QueryBasis<M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_CONT_PARCELVA
				SET COD_OPERACAO =
				 '{this.HISCONPA_COD_OPERACAO}',
				SIT_REGISTRO =
				 '{this.ENDOSSOS_SIT_REGISTRO}',
				DATA_MOVIMENTO =
				 '{this.PARCEHIS_DATA_QUITACAO}',
				TIMESTAMP =
				CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =
				 '{this.HISCONPA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =
				 '{this.HISCONPA_NUM_PARCELA}'
				AND NUM_TITULO =
				 '{this.HISCONPA_NUM_TITULO}'
				AND NUM_ENDOSSO > 1";

            return query;
        }
        public string PARCEHIS_DATA_QUITACAO { get; set; }
        public string HISCONPA_COD_OPERACAO { get; set; }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }

        public static void Execute(M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1 m_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1)
        {
            var ths = m_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}