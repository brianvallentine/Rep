using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 : QueryBasis<R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.COBER_HIST_VIDAZUL
				SET DATA_VENCIMENTO =  '{this.WHOST_DATA_CRED}',
				PRM_TOTAL =  '{this.WHOST_NEW_PRM}',
				SIT_REGISTRO =  '{this.COBHISVI_SIT_REGISTRO}',
				COD_OPERACAO =  '{this.COBHISVI_COD_OPERACAO}',
				OCORR_HISTORICO =  '{this.COBHISVI_OCORR_HISTORICO}',
				COD_DEVOLUCAO =  '{this.RELATORI_COD_OPERACAO}'
				WHERE  NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.RELATORI_NUM_PARCELA}'";

            return query;
        }
        public string COBHISVI_OCORR_HISTORICO { get; set; }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string COBHISVI_COD_OPERACAO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }
        public string WHOST_DATA_CRED { get; set; }
        public string WHOST_NEW_PRM { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static void Execute(R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 r2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1)
        {
            var ths = r2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}