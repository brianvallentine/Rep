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
    public class M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1 : QueryBasis<M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_CONT_PARCELVA
				SET SIT_REGISTRO = '0'
				, PREMIO_VG =  '{this.HISCONPA_PREMIO_VG}'
				, PREMIO_AP =  '{this.HISCONPA_PREMIO_AP}'
				, COD_OPERACAO =  '{this.HISCONPA_COD_OPERACAO}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND NUM_PARCELA = 1";

            return query;
        }
        public string HISCONPA_COD_OPERACAO { get; set; }
        public string HISCONPA_PREMIO_VG { get; set; }
        public string HISCONPA_PREMIO_AP { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1 m_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1)
        {
            var ths = m_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}