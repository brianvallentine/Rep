using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1617B
{
    public class R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1 : QueryBasis<R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PF_PROC_PROPOSTA
            VALUES (:PF087-SIGLA-ARQUIVO ,
            :PF087-SISTEMA-ORIGEM ,
            :PF087-NSAS-SIVPF ,
            :PF087-NUM-PROPOSTA ,
            :PF087-SEQ-OCORRENCIA ,
            :PF087-NUM-DET-ARQ-PROPOSTA ,
            :PF087-NUM-ERRO-PROPOSTA ,
            :PF087-NUM-APOLICE-VINCULADA ,
            :PF087-NUM-LINHA-ARQUIVO ,
            :PF087-DES-CONTEUDO ,
            :PF087-STA-PROCESSAMENTO ,
            :PF087-COD-USUARIO ,
            CURRENT_TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PF_PROC_PROPOSTA VALUES ({FieldThreatment(this.PF087_SIGLA_ARQUIVO)} , {FieldThreatment(this.PF087_SISTEMA_ORIGEM)} , {FieldThreatment(this.PF087_NSAS_SIVPF)} , {FieldThreatment(this.PF087_NUM_PROPOSTA)} , {FieldThreatment(this.PF087_SEQ_OCORRENCIA)} , {FieldThreatment(this.PF087_NUM_DET_ARQ_PROPOSTA)} , {FieldThreatment(this.PF087_NUM_ERRO_PROPOSTA)} , {FieldThreatment(this.PF087_NUM_APOLICE_VINCULADA)} , {FieldThreatment(this.PF087_NUM_LINHA_ARQUIVO)} , {FieldThreatment(this.PF087_DES_CONTEUDO)} , {FieldThreatment(this.PF087_STA_PROCESSAMENTO)} , {FieldThreatment(this.PF087_COD_USUARIO)} , CURRENT_TIMESTAMP )";

            return query;
        }
        public string PF087_SIGLA_ARQUIVO { get; set; }
        public string PF087_SISTEMA_ORIGEM { get; set; }
        public string PF087_NSAS_SIVPF { get; set; }
        public string PF087_NUM_PROPOSTA { get; set; }
        public string PF087_SEQ_OCORRENCIA { get; set; }
        public string PF087_NUM_DET_ARQ_PROPOSTA { get; set; }
        public string PF087_NUM_ERRO_PROPOSTA { get; set; }
        public string PF087_NUM_APOLICE_VINCULADA { get; set; }
        public string PF087_NUM_LINHA_ARQUIVO { get; set; }
        public string PF087_DES_CONTEUDO { get; set; }
        public string PF087_STA_PROCESSAMENTO { get; set; }
        public string PF087_COD_USUARIO { get; set; }

        public static void Execute(R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1 r0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1)
        {
            var ths = r0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}