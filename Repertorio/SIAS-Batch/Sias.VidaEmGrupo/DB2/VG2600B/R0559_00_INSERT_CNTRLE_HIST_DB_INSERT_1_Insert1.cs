using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1 : QueryBasis<R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PF_PROC_PROPOSTA_HIST
            VALUES (:PF087-SIGLA-ARQUIVO ,
            :PF087-SISTEMA-ORIGEM ,
            :PF087-NSAS-SIVPF ,
            :PF087-NUM-PROPOSTA ,
            :PF087-SEQ-OCORRENCIA ,
            :PF090-SEQ-OCORR-HIST ,
            :PF087-STA-PROCESSAMENTO ,
            :PF087-COD-USUARIO ,
            CURRENT_TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PF_PROC_PROPOSTA_HIST VALUES ({FieldThreatment(this.PF087_SIGLA_ARQUIVO)} , {FieldThreatment(this.PF087_SISTEMA_ORIGEM)} , {FieldThreatment(this.PF087_NSAS_SIVPF)} , {FieldThreatment(this.PF087_NUM_PROPOSTA)} , {FieldThreatment(this.PF087_SEQ_OCORRENCIA)} , {FieldThreatment(this.PF090_SEQ_OCORR_HIST)} , {FieldThreatment(this.PF087_STA_PROCESSAMENTO)} , {FieldThreatment(this.PF087_COD_USUARIO)} , CURRENT_TIMESTAMP )";

            return query;
        }
        public string PF087_SIGLA_ARQUIVO { get; set; }
        public string PF087_SISTEMA_ORIGEM { get; set; }
        public string PF087_NSAS_SIVPF { get; set; }
        public string PF087_NUM_PROPOSTA { get; set; }
        public string PF087_SEQ_OCORRENCIA { get; set; }
        public string PF090_SEQ_OCORR_HIST { get; set; }
        public string PF087_STA_PROCESSAMENTO { get; set; }
        public string PF087_COD_USUARIO { get; set; }

        public static void Execute(R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1 r0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1)
        {
            var ths = r0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}